using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CarReservation.Common.Helper
{
    public class ExceptionHelper
    {
        public static void ThrowAPIException(string content)
        {
            ThrowAPIException(HttpStatusCode.BadRequest, string.Empty, content);
        }

        public static void ThrowAPIException(HttpStatusCode code, string content)
        {
            ThrowAPIException(code, string.Empty, content);
        }

        public static void ThrowAPIException(HttpStatusCode code, string reasonPhrase, string content)
        {
            var resp = new HttpResponseMessage(code);

            ErrorMessage error = new ErrorMessage() { Error = content };

            resp.Content = new ObjectContent(error.GetType(), error, new JsonMediaTypeFormatter());

            throw new HttpResponseException(resp);
        }

        public static Exception GetAPIException(HttpStatusCode code, string reasonPhrase, string content)
        {
            var resp = new HttpResponseMessage(code);

            resp.Content = new StringContent(content);
            resp.ReasonPhrase = reasonPhrase;

            return new HttpResponseException(resp);
        }

        public static void LogAPIException(string log)
        {
            Exception ex = new Exception(log);
            LogAPIException(ex);
        }

        public static void LogAPIException(Exception ex)
        {
            Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
        }

        public static void LogFileException(string log)
        {
            Exception ex = new Exception(log);
            LogFileException(ex);
        }

        public static void LogFileException(Exception ex)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Exceptions\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (TextWriter tw = new StreamWriter(path + DateTime.Now.ToString().Replace("/", "_").Replace(":", "_") + ".txt"))
            {
                tw.WriteLine(ex.Message);
            }
        }
    }

    public class ErrorMessage
    {
        public string Error { get; set; }
    }

    public class SuccessMessage
    {
        public string successMessage { get; set; }
    }
}
