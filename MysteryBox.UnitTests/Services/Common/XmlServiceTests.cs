using System;
using FluentAssertions;
using MysteryBox.WebService.Exceptions;
using MysteryBox.WebService.Models.Domainbox.Request;
using MysteryBox.WebService.Models.Domainbox.Response;
using MysteryBox.WebService.Services.Common;
using Xunit;

namespace MysteryBox.UnitTests.Services.Common
{
    public class XmlServiceTests
    {
        private readonly XmlService _xmlService;

        public XmlServiceTests()
        {
            _xmlService = new XmlService();
        }

        [Fact]
        public void Serialize_ValidInput_ShouldSerialize()
        {
            var createContactRequest = new CreateContactRequest();

            var serializedPayload = _xmlService.Serialize(createContactRequest);

            serializedPayload.Should().Be("<s:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" />");
        }

        [Fact]
        public void Deserialize_ValidInput_ShouldReturnDeserializedObject()
        {
            var serializedPayload = "<s:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" />";
            var createContactRequest = new CreateContactRequest();

            var deserializedPayload = _xmlService.DeserializeXml<CreateContactRequest>(serializedPayload);

            deserializedPayload.Should().BeEquivalentTo(createContactRequest);
        }

        [Fact]
        public void Deserialize_InvalidData_ShouldThrowXmlDeserializationException()
        {
            Action action = () => _xmlService.DeserializeXml<CreateContactResponse>("invalid payload");
            action.Should().Throw<XmlDeserializationException>();
        }
    }
}
