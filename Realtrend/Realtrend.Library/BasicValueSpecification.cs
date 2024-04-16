namespace Realtrend.Models
{
    public class BasicValueSpecification
    {
        public double Areal { get; set; }
        public double Beløb { get; set; }
        public double EnhedBeløb { get; set; }
        public double Løbenummer { get; set; }
        public string PrisKode { get; set; }
        public string Tekst { get; set; }
        public string RequiredVURejendomsid { get; private set; }

        public BasicValueSpecification(string propertyId)
        {
            RequiredVURejendomsid = propertyId;
        }

        public BasicValueSpecification()
        {
        }
    }
}
