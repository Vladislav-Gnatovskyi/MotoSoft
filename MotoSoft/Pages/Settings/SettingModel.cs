namespace MotoSoft.Pages.Settings
{
    public class SettingsModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PayPal { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string TemplateBuilder { get; set; }
        public string Html { get; set; }
        public string Token { get; set; }
        public bool PaymentRequired { get; set; }
        public bool CreditCards { get; set; }
        public bool BestOffer { get; set; }
        public bool PartCompatibility { get; set; }
    }
}
