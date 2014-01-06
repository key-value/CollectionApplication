using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Maticsoft.BLL
{
    public static class PostHttpResponse
    {
        #region  Post发送方法

        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>  
        /// <returns></returns>  
        public static string CreateGetHttpResponse(string url, IDictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            HttpWebRequest request;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                if (request != null)
                {
                    request.ProtocolVersion = HttpVersion.Version10;
                }
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            if (request != null)
            {
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = 5000;

                //如果需要POST数据  
                if (!(parameters == null || parameters.Count == 0))
                {
                    var buffer = GetParameters(parameters);
                    Encoding requestEncoding = Encoding.GetEncoding("gbk");
                    byte[] data = requestEncoding.GetBytes(buffer.ToString());
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                string strResult;
                var srReader = new StreamReader(stream: request.GetResponse().GetResponseStream(), encoding: Encoding.ASCII);
                strResult = srReader.ReadToEnd();
                return strResult;
            }
            return string.Empty;
        }
        private static string GetParameters(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var stringBuilder = new StringBuilder();
            int i = 0;
            foreach (var parameter in parameters)
            {
                if (i > 0)
                {
                    stringBuilder.AppendFormat("&{0}={1}", parameter.Key, parameter.Value);
                }
                else
                {
                    stringBuilder.AppendFormat("{0}={1}", parameter.Key, parameter.Value);
                }
                i++;
            }
            return stringBuilder.ToString();
        }
        #endregion
        public static string CreatePostHttpResponse(string url, IDictionary<string, string> parameters)
        {

            WebClient WebClientObj = new System.Net.WebClient();
            NameValueCollection PostVars = new NameValueCollection();


            foreach (var parameter in parameters)
            {
                PostVars.Add(parameter.Key, parameter.Value);
            }
            try
            {
                byte[] byRemoteInfo = WebClientObj.UploadValues(url, "POST", PostVars);
                String s = Encoding.Default.GetString(byRemoteInfo);
            }
            catch
            { }
            return string.Empty;
        }

        /// <summary>
        /// 以POST 形式请求数据
        /// </summary>
        /// <param name="RequestPara"></param>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="heaDictionary"></param>
        /// <returns></returns>
        public static string PostData(string url, IDictionary<string, string> parameters, IDictionary<string, string> heaDictionary)
        {
            var RequestPara = GetParameters(parameters);
            WebRequest hr = HttpWebRequest.Create(url);

            byte[] buf = System.Text.Encoding.GetEncoding("utf-8").GetBytes(RequestPara);
            hr.ContentType = "application/x-www-form-urlencoded";
            hr.ContentLength = buf.Length;
            hr.Method = "POST";

            hr.Headers.Add(GetNameValueCollection(heaDictionary));

            hr.Timeout = 5000;

            System.IO.Stream RequestStream = hr.GetRequestStream();
            RequestStream.Write(buf, 0, buf.Length);
            RequestStream.Close();

            System.Net.WebResponse response = hr.GetResponse();
            var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
            var returnVal = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return returnVal;
        }

        public static NameValueCollection GetNameValueCollection(IDictionary<string, string> heaDictionary)
        {
            var nameValueCollection = new NameValueCollection();
            foreach (var body in heaDictionary)
            {
                nameValueCollection.Add(body.Key, body.Value);
            }
            return nameValueCollection;
        }
    }
}