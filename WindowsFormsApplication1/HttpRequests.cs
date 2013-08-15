using ReduOffline.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline
{
    public class HttpRequests
    {

        private RestClient _client;        

        public HttpRequests()
        {
            _client = new RestClient(Constants.BASE_URL);
        }

        /// <summary>
        /// Does a complete OAuth GET Request according to the request URL. Converts the received data to return
        /// as a result the type T of object demanded as a request.
        /// </summary>
        /// <typeparam name="T">Any type of the Redu API</typeparam>
        /// <param name="demand">Request URL</param>
        /// <param name="access_token">Authorization token</param>
        /// <returns>Object of same type as demanded</returns>
        public T get<T>(string demand, string access_token) where T : new()
        {
            if (demand.Equals(string.Empty))
            {
                throw new ArgumentNullException("missing demand url");
            }

            var request = new RestRequest(demand, Method.GET);
            request.AddHeader("Authorization", "OAuth " + access_token);
            var response = _client.Execute<T>(request);

            T content = response.Data;

            return content ;
        }

        public string post()
        {
            return "";
        }

        public string delete()
        {
            return "";
        }
        /// <summary>
        /// Async download of any kind of data. It calls DownloadProgressChangedEventArgs when some progress is done and
        /// AsyncCompletedEventArgs when the download is finished.
        /// </summary>
        /// <param name="url">Download url</param>
        /// <param name="path">Destination in the local path system</param>
        public void download_file(string url, string path)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(done);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(progress_done);
            webClient.DownloadFileAsync(new Uri(url), path);
        }

        private void progress_done(object sender, DownloadProgressChangedEventArgs e)
        {
            //progressBar.Value = e.ProgressPercentage;
        }

        private void done(object sender, AsyncCompletedEventArgs e)
        {
            //MessageBox.Show("Download efetuado!");
        }
    }
}
