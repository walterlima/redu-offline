using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ReduOffline
{
    public class ReduOAuth
    {        
        private String _access_token = "";
        private String _login = "";
        private XmlDocument _xml_user;

        private Dictionary<string, string> tokens = new Dictionary<string, string>();
        private Manager _OAuth = new Manager();

        public ReduOAuth()
        {
            this.verify_folders_exist();
            this.verify_xml_exists();
        }

        private void verify_folders_exist()
        {
            if (!Directory.Exists(Constants.XML_CONFIG_FOLDER))
            {
                Directory.CreateDirectory(Constants.XML_CONFIG_FOLDER);
            }
            if (!Directory.Exists(Constants.XML_USER_FOLDER))
            {
                Directory.CreateDirectory(Constants.XML_USER_FOLDER);
            }
            if (!Directory.Exists(Constants.XML_TIMELINE_FOLDER))
            {
                Directory.CreateDirectory(Constants.XML_TIMELINE_FOLDER);
            }
            if (!Directory.Exists(Constants.XML_AVAS_FOLDER))
            {
                Directory.CreateDirectory(Constants.XML_AVAS_FOLDER);                
            }
            
        }

        private void verify_xml_exists()
        {
            if (!File.Exists(Constants.XML_USER_CONFIG_FOLDER))
            {
                _xml_user = new XmlDocument();
                XmlNode declaration = _xml_user.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlNode root = _xml_user.CreateElement("user-control-file");
                _xml_user.AppendChild(declaration);
                _xml_user.AppendChild(root);
                _xml_user.Save(Constants.XML_USER_CONFIG_FOLDER);
            }
            else
            {
                _xml_user = new XmlDocument();
                _xml_user.Load(Constants.XML_USER_CONFIG_FOLDER);
            }
        }
        
        public bool demand_authorize(String login)
        {
            XmlNodeList node_list = _xml_user.GetElementsByTagName("user");
            _login = login;
            foreach (XmlNode node in node_list)
            {
                if(node.Attributes["login"].Value.Equals(login))
                {
                    _access_token = node["access-token"].InnerText.ToString();
                    break;
                }
            }
            if (!_access_token.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                _OAuth["consumer_key"] = Constants._consumerKey;
                _OAuth["consumer_secret"] = Constants._consumerSecret;
                System.Diagnostics.Process.Start(string.Format(Constants.AUTHORIZE_URL, Constants._consumerKey));
                return false;
            }
        }

        public void enter_authorization_pin(String pin)
        {
            HttpWebRequest _authorize_client = WebRequest.Create(string.Format(Constants.ACCESS_TOKEN_URL, pin, Constants._consumerKey, Constants._consumerSecret, Constants._grant_type)) as HttpWebRequest; //, _grant_type, _redirect_uri)) as HttpWebRequest;
            using (HttpWebResponse _authorize_reponse = _authorize_client.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(_authorize_reponse.GetResponseStream());
                string vals = reader.ReadToEnd();
                vals = vals.Replace("\"", "");
                vals = vals.Trim('{', '}', '"', ' ');
                foreach (string token in vals.Split(','))
                {
                    tokens.Add(token.Substring(0, token.IndexOf(":")), token.Substring(token.IndexOf(":") + 1, token.Length - token.IndexOf(":") - 1));
                }
            }
            add_new_user_acess_token(tokens);
        }

        private void add_new_user_acess_token(Dictionary<String, String> dic)
        {   
            //salvando access token do usuario
            XmlNode root = _xml_user.GetElementsByTagName("user-control-file")[0];
            XmlNode new_user = _xml_user.CreateElement("user");
            new_user.Attributes.Append(_xml_user.CreateAttribute("login")).Value = _login;
            XmlNode access_token = _xml_user.CreateElement("access-token");
            access_token.InnerText = dic["access_token"];
            new_user.AppendChild(access_token);
            XmlNode path_info = _xml_user.CreateElement("path-info");
            path_info.InnerText = Constants.XML_USER_FOLDER + _login + ".xml";
            new_user.AppendChild(path_info);
            root.AppendChild(new_user);
            _xml_user.Save(Constants.XML_USER_CONFIG_FOLDER);

        }

        public string get_access_token()
        {
            return _access_token;
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public bool isConnected()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

    }
}
