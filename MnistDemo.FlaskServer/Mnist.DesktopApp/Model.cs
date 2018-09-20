using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Mnist.DesktopApp
{
    class Model
    {
        public const int ImageSize = 28;

        private string _serviceEndpoint = null;

        public Model()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _serviceEndpoint = config.AppSettings.Settings["MnistServiceEndpoint"].Value;
        }

        public float[] Predict(float[] input)
        {
            var body = string.Join(",", input);
            var request = WebRequest.Create("http://localhost:8080/predict") as HttpWebRequest;
            var bytes = Encoding.UTF8.GetBytes(body);
            request.Method = "POST";
            request.MediaType = "text/plain";
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            var response = request.GetResponse() as HttpWebResponse;
            body = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return body.Split(',').Select(t => float.Parse(t)).ToArray();
        }
    }
}
