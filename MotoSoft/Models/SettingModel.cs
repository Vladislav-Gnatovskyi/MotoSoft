using MotoSoft.Models.Enums;
using System.Runtime.Serialization;

namespace MotoSoft.Models
{
    [DataContract]
    public class SettingModel
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
        [DataMember]
        public bool PaymentRequired { get; set; }
        [DataMember]
        public bool CreditCards { get; set; }
        [DataMember]
        public bool BestOffer { get; set; }
        [DataMember]
        public bool PartCompatibility { get; set; }
        [DataMember]
        public ETitleStyle TitleStyle { get; set; }
        [DataMember]
        public EInventoryNumber TypeNumber { get; set;}
    }
}
