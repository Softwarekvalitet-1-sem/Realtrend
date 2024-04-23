namespace Realtrend.Library.Models
{
    public class AssessmentProperty
    {
        public int VURejendomsid { get; set; }
        public int ESRejendomsnummer { get; set; }
        public int ESRkommunenummer { get; set; }
        public int? VurderingsejendomID { get; set; }
        public int? BFENumber { get; set; }
        public DateTime Dato { get; set; }
        public List<BasicValueSpecification> ValueSpecifications { get; set; }
    }
}
