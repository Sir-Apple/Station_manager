using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine;

namespace ConnectServer
{
    public static class Connect
    {
        public static byte[] UploadFiles(string address, IEnumerable<UploadFile> files, NameValueCollection values)
        {
            var request = WebRequest.Create(address);
            request.Method = "POST";
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            boundary = "--" + boundary;

            using (var requestStream = request.GetRequestStream())
            {
                // Write the values
                foreach (string name in values.Keys)
                {
                    var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                }

                // Write the files
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                        requestStream.Write(buffer, 0, buffer.Length);
                        buffer = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", file.Name, file.Filename, Environment.NewLine));
                        requestStream.Write(buffer, 0, buffer.Length);
                        buffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", file.ContentType, Environment.NewLine));
                        requestStream.Write(buffer, 0, buffer.Length);
                        file.Stream.CopyTo(requestStream);
                        buffer = Encoding.ASCII.GetBytes(Environment.NewLine);
                        requestStream.Write(buffer, 0, buffer.Length);
                    }
                }

                var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
                requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
            }

            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var stream = new MemoryStream())
            {
                responseStream.CopyTo(stream);
                return stream.ToArray();
            }
        }

        public static string UploadInfo(string URL, string newValue)
        {
            string feedback = string.Empty;

            var postInfo = new NameValueCollection
            {
                { "newStation", newValue },
            };

            byte[] result = UploadFiles(URL, null, postInfo);
            feedback = Encoding.UTF8.GetString(result, 0, result.Length);
            Debug.Log(feedback);

            return feedback;
        }

        public static string UpdateInfo(string URL, string newValue, string oldValue)
        {
            string feedback = string.Empty;

            var postInfo = new NameValueCollection
            {
                { "newStation", newValue },
                { "tuananh", oldValue},
            };

            byte[] result = UploadFiles(URL, null, postInfo);
            feedback = Encoding.UTF8.GetString(result, 0, result.Length);
            Debug.Log(feedback);

            return feedback;
        }

        public static string UploadRandomFile(string URL, string filePath, string username, string token)
        {
            string feedback = string.Empty;
            using (var stream = File.Open(filePath, FileMode.Open))
            {
                var files = new[]
                {
                    new UploadFile
                    {
                        Name = "file",
                        Filename = Path.GetFileName(filePath),
                        ContentType = "text/plain",
                        Stream = stream
                    }
                };

                var postInfo = new NameValueCollection
                {
                    { "username", username },
                    { "token", token },
                };

                byte[] result = UploadFiles(URL, files, postInfo);
                feedback = Encoding.UTF8.GetString(result, 0, result.Length);
                Debug.Log(feedback);
            }

            return feedback;
        }

        public static List<string> ProcessingFeedbackArray(string feedback)
        {
            //feedback = feedback.Split('_')[1];
            string tempString = feedback.Replace("\\/", "/");
            tempString = tempString.Replace("[", "");
            tempString = tempString.Replace("]", "");
            tempString = tempString.Replace("{", "");
            tempString = tempString.Replace("}", "");
            tempString = tempString.Replace("\"", "");
            List<string> itemList = tempString.Split(',').ToList();

            return itemList;
        }
    }

    public class UploadFile
    {
        public UploadFile()
        {
            ContentType = "application/octet-stream";
        }
        public string Name { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public Stream Stream { get; set; }
    }
}
