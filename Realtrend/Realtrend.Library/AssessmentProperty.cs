namespace Realtrend.Models
{
    public class AssessmentProperty
    {
        public double VURejendomsid { get; set; }
        public double ESRejendomsnummer { get; set; }
        public double ESRkommunenummer { get; set; }
        public double? VurderingsejendomID { get; set; }
        public int? BFENummber { get; set; }
        public List<BasicValueSpecification> ValueSpecifications { get; set; }
    }
}
