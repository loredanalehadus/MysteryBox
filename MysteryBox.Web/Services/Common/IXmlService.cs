namespace MysteryBox.WebService.Services.Common
{
    public interface IXmlService
    {
        string Serialize<T>(T payload) where T : class;
        T DeserializeXml<T>(string content) where T : class;
    }
}