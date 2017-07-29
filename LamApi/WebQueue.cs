using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;


namespace LamApi
{
    class WebQueue
    {
        private string entryURL;

        public WebQueue(string url)
        {
            entryURL = url;
        }

        public string Create(string[] entryKeyValue)
        {
            if (entryKeyValue.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(entryURL);
                sb.Append("?");
                foreach (string kvp in entryKeyValue)
                {
                    sb.Append(kvp);
                    sb.Append("&");
                }
                string result = sb.ToString();
                // remove '&' at the end
                return (result.TrimEnd('&'));
            }
            else
            {
                return (null);
            }

        } // end Create

        public bool Submit(string submitQueue)
        {
            bool result = false;
            try
            {
                string username = "CADMMETRICS";
                string userPw = "CADMMETRICS";
                WebRequest networkCredential = WebRequest.Create(submitQueue);
                networkCredential.Credentials = new NetworkCredential(username, userPw);
                networkCredential.Method = "GET";
                WebResponse response = networkCredential.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(responseStream);
                Console.WriteLine(sr.ReadToEnd());
                sr.Close();
                responseStream.Close();
                response.Close();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: unable to sumbit queue " + submitQueue + ". " + ex.Message);
            }
            return (result);
        } // end Sumbit

    } // end WebQueue
}
