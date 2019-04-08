using System.Runtime.Serialization;

namespace MotoSoft.Model
{
    [DataContract]
    public class SettingsModel
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string PayPal { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string TemplateBuilder { get; set; }
        [DataMember]
        public string Html { get; set; }
    }
}
