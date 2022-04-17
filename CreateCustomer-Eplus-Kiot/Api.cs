using System;
using System.IO;
using System.Net;

namespace CreateCustomer_Eplus_Kiot
{
    public class Api
    {
        public static string Post(string url, string body, string auth)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            // add authorization to header
            httpWebRequest.Headers["Authorization"] = auth;
            httpWebRequest.Headers["Retailer"] = "earldom";

            // add method
            httpWebRequest.Method = "POST";
            // use stream write
            string status;
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(body);
                    streamWriter.Close();
                }

                var response = (HttpWebResponse) httpWebRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader streamReader =
                           new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
                    {
                        status = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
                else
                {
                    status = "501";
                }

                response.Close();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
                status = "502";
            }
            return status;
        }
        
        public static string Get(string url, string auth)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            // add authorization to header
            httpWebRequest.Headers["Authorization"] = auth;
            httpWebRequest.Headers["Retailer"] = "earldom";

            // add method
            httpWebRequest.Method = "GET";
            // use stream write
            string status;
            try
            {

                var response = (HttpWebResponse) httpWebRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader streamReader =
                           new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
                    {
                        status = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
                else
                {
                    status = "501";
                }

                response.Close();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
                status = "502";
            }
            return status;
        }
    }
}