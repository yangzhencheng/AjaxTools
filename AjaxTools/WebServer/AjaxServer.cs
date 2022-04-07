using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AjaxTools.WebServer
{
    internal class AjaxServer
    {
        public AjaxServer(string url)
        {
            this.url = url;
        }


        public AjaxServer(string url, string method)
        {
            this.url = url;
            this.method = method;
        }


        public AjaxServer(string url, string method, string data)
        {
            this.url = url;
            this.method = method;
            this.data = data;
        }


        /// <summary>
        /// 添加 Http Header
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void SetHeader(string key, string value)
        {
            httpHeaders.Add(key, value);
        }


        /// <summary>
        /// 发送
        /// </summary>
        /// <returns>bool: 与数据器的结果 true: 成功；false 失败</returns>
        public bool Send()
        {
            return Run();
        }


        /// <summary>
        /// 等待时间（单位：ms）
        /// </summary>
        public int TimeOut
        {
            get
            {
                return _timeOut;
            }

            set
            {
                _timeOut = value;
            }
        }


        /// <summary>
        /// CA 证书介入
        /// </summary>
        public string X509CertFilePath
        {
            get
            {
                return _x509CertFilePath;
            }

            set
            {
                _x509CertFilePath = value;
            }
        }



        /// <summary>
        /// 错误
        /// </summary>
        public string Error
        {
            get
            {
                return ErrorInformation;
            }
        }


        /// <summary>
        /// 返回的全部字符串
        /// </summary>
        public string Value
        {
            get
            {
                return Result;
            }
        }


        /// <summary>
        /// 返回执行状态
        /// </summary>
        public HttpStatusCode Status
        {
            get
            {
                return _status;
            }
        }



        public string ContentType
        {
            get
            {
                return _contentType;
            }

            set
            {
                _contentType = value;
            }
        }



        private string url;
        private string data;
        private string method = "POST";

        protected int _timeOut = 0;
        protected string Result = "";
        protected string _contentType = "application/x-www-form-urlencoded";
        protected string ErrorInformation = "";
        protected string _x509CertFilePath = "";
        protected HttpStatusCode _status = HttpStatusCode.Created;
        protected Dictionary<string, string> httpHeaders = new Dictionary<string, string>();





        private bool Run()
        {
            _status = HttpStatusCode.Created;
            ErrorInformation = "";
            Result = "";

            bool _r = false;

            //生成文件流
            byte[] _buffer = Encoding.UTF8.GetBytes(data);


            //根据url创建请求对象
            HttpWebRequest _request = (HttpWebRequest)WebRequest.Create(url);
            _request.Method = method;
            _request.ContentLength = _buffer.Length;
            _request.ContentType = _contentType;


            // 设置等待时间
            if (0 < _timeOut) _request.Timeout = _timeOut;


            // 加载文件头
            if (0 < httpHeaders.Count)
            {
                foreach (KeyValuePair<string, string> kvp in httpHeaders)
                {
                    _request.Headers.Add(kvp.Key, kvp.Value);
                }
            }


            // CA 证书介入
            if (0 < _x509CertFilePath.Length) _request.ClientCertificates.Add(X509Certificate.CreateFromCertFile(_x509CertFilePath));


            // 正式推送
            try
            {
                Stream sm = _request.GetRequestStream();
                sm.Write(_buffer, 0, _buffer.Length);
                sm.Close();

                HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
                using (StreamReader sr = new StreamReader(_response.GetResponseStream()))
                {
                    Result = sr.ReadToEnd();
                    sr.Close();
                }


                _status = _response.StatusCode;
                _r = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Source);
                Console.Write(ex.StackTrace);
                Console.Write(ex.Message);

                ErrorInformation = ex.Message;

                _r = false;
            }


            return _r;
        }
    }
}
