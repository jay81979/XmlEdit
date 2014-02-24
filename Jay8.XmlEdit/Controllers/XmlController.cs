using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Collections.Generic;
using Jay8.XmlEdit.Models;
using System;

namespace Jay8.XmlEdit.Controllers
{
    public class XmlController : ApiController
    {
        public XmlController(IXmlRepository xmlRepository)
        {
            if (xmlRepository == null)
            {
                throw new ArgumentNullException("xmlRepository is null");
            }
            _xmlRepository = xmlRepository;
        } 

        private readonly IXmlRepository _xmlRepository;

        public async Task<HttpResponseMessage> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data/uploads");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                List<string> fileResultList = new List<string>();
                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    if (file.Headers.ContentType.MediaType.Equals("text/xml"))
                    {
                        _xmlRepository.ProcessNewXml(file);
                        fileResultList.Add("hello");
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, fileResultList);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}