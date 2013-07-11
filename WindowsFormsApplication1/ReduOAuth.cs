using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth;
using System.Net;

namespace ReduOffline
{
    class ReduOAuth
    {
        private String _consumerKey = "iXL5orXjX9VOP6DW7c9xvqJ74kkMNh7mFQcCB0Rp";
        private String _consumerSecret = "depNX2Ypp1bpFG7x5BeBGxNc9QRHN4metGuCBR35";
        private static String REQUEST_URL = "http://www.redu.com.br/oauth/request_token";
        private static String AUTHORIZE_URL = "http://www.redu.com.br/oauth/authorize?oauth_token=";
        private static String ACCESS_TOKEN_URL = "http://www.redu.com.br/oauth/access_token";
        private OAuthResponse _accessToken = null;
     

        private Manager OAuth = new Manager();

        public void demand_authorize()
        {
            OAuth["consumer_key"] = _consumerKey;
            OAuth["consumer_secret"] = _consumerSecret;

            OAuthResponse requestToken = OAuth.AcquireRequestToken(REQUEST_URL, "POST");

            System.Diagnostics.Process.Start(AUTHORIZE_URL + OAuth["token"]);
        }

        public void enter_authorization_pin(String pin)
        {
            _accessToken = OAuth.AcquireAccessToken(ACCESS_TOKEN_URL, "POST", pin);
        }

        public string get(Uri requestUri, string authHeader)
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException("requesteUri");
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

            request.Method = "GET";
            request.ServicePoint.Expect100Continue = false;
            request.ContentType = "x-www-form-unlencoded";

            request.Headers["Authorization"] = authHeader;

            HttpWebResponse response = (HttpWebResponse) request.GetResponse();

            return response.ToString();
        }

    }
}
