using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Jay8.XmlEdit.Models
{
    public class XmlRepository:IXmlRepository
    {
        public void ProcessNewXml(MultipartFileData file)
        {
            Trace.WriteLine("Server file path: " + file.LocalFileName);
            MoveFileToDraft(file);
        }

        public string GetFileName(string name)
        {
            int start = name.LastIndexOf("\\") + 1;
            int end = name.LastIndexOf(".") - start;
            return name.Substring(start, end);
        }

        private void MoveFileToDraft(MultipartFileData file)
        {
            string root = HttpContext.Current.Server.MapPath("~/App_Data/draft");
            string fileName = string.Format("{0}\\{1}.{2}", root, GetFileName(file.Headers.ContentDisposition.FileName), "xml");
            Trace.WriteLine("draft: " + fileName);
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            try
            {
                File.Move(file.LocalFileName, fileName);
                Console.WriteLine("Moved"); // Success
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message); // Write error
            }
        }
    }
}