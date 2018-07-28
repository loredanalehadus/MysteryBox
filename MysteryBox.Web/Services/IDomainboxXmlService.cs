namespace MysteryBox.WebService.Services
{
    public interface IDomainboxXmlService
    {
        string Serialize<T>(T payload) where T : class;
        T DeserializeXml<T>(string content) where T : class;
    }
}