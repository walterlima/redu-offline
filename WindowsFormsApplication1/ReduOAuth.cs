/*
    Copyright 2013 Walter Ferreira de Lima Filho
    
    This file is part of ReduOffline.

    ReduOffline is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    ReduOffline is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with ReduOffline.  If not, see <http://www.gnu.org/licenses/>. 

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (!Directory.Exists(Constants.XML_USER_TIMELINE_FOLDER))
            {
                Directory.CreateDirectory(Constants.XML_USER_TIMELINE_FOLDER);
            }
            if (!Directory.Exists(Constants.XML_AVAS_FOLDER))
            {
                Directory.CreateDirectory(Constants.XML_AVAS_FOLDER);
            }
            if (!Directory.Exists(Constants.XML_COURSES_FOLDER))
            {
                Directory.CreateDirectory(Constants.XML_COURSES_FOLDER);
            }
            if (!Directory.Exists(Constants.XML_SPACES_FOLDER))
            {
                Directory.CreateDirectory(Constants.XML_SPACES_FOLDER);
            }
            if (!Directory.Exists(Constants.XML_SUBJECTS_FOLDER))
            {
                Directory.CreateDirectory(Constants.XML_SUBJECTS_FOLDER);
            }
            if (!Directory.Exists(Constants.XML_LECTURES_FOLDER))
            {
                Directory.CreateDirectory(Constants.XML_LECTURES_FOLDER);
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
            if (!File.Exists(Constants.XML_CONFIG_PATH))
            {
                XmlDocument xml_app_config = new XmlDocument();
                XmlNode declaration = xml_app_config.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlNode root = xml_app_config.CreateElement("app-config-file");
                XmlNode pending_activities_id = xml_app_config.CreateElement("peding-activities-id");
                XmlNode value = xml_app_config.CreateElement("value");
                value.InnerText = "-1";
                pending_activities_id.AppendChild(value);
                root.AppendChild(pending_activities_id);
                xml_app_config.AppendChild(declaration);
                xml_app_config.AppendChild(root);
                xml_app_config.Save(Constants.XML_CONFIG_PATH);
            }
        }
        
        public void demand_authorize(String login)
        {            
            System.Diagnostics.Process.Start(string.Format(Constants.AUTHORIZE_URL, Constants._consumerKey));
        }

        /// <summary>
        /// Consults if a given user has already authorized the login in Redu
        /// </summary>
        /// <param name="login"></param>
        /// <returns>True if it has authorized, False otherwise</returns>
        public bool has_user_authorized(string login)
        {
            XmlNodeList node_list = _xml_user.GetElementsByTagName("user");
            string _test_access_token = string.Empty;
            _login = login;

            foreach (XmlNode node in node_list)
            {
                if (node.Attributes["login"].Value.Equals(login))
                {
                    _test_access_token = node["access-token"].InnerText.ToString();
                    break;
                }
            }
            _access_token = _test_access_token;
            return !_test_access_token.Equals(string.Empty);            
        }

        public bool user_has_data(string login)
        {
            bool retorno = File.Exists(string.Format(Constants.XML_USER_PATH,  login));
            return retorno;
        }

        public bool enter_authorization_pin(String pin)
        {
            HttpWebRequest _authorize_client = WebRequest.Create(string.Format(Constants.ACCESS_TOKEN_URL, pin, Constants._consumerKey, Constants._consumerSecret, Constants._grant_type)) as HttpWebRequest; //, _grant_type, _redirect_uri)) as HttpWebRequest;
            HttpWebResponse _authorize_reponse = _authorize_client.GetResponse() as HttpWebResponse;
            if (_authorize_reponse != null)
            {
                using (_authorize_reponse)
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
                return true;
            }
            else
                return false;
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
            _access_token = dic["access_token"];

        }

        public string get_access_token()
        {
            return _access_token;
        }       

    }
}
