using System.Net.Http;

namespace Jay8.XmlEdit.Models
{
    public interface IXmlRepository
    {
        void ProcessNewXml(MultipartFileData file);
    }
}
