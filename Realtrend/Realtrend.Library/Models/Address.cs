namespace Realtrend.Library.Models
{
    public class Address
    {
        public string? StreetAndHouseNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? AddressId { get; set; }
        public string? Jordstykke { get; set; }
        public string? BfeNumber { get; set; }

        public Address()
        {
            StreetAndHouseNumber = null;
            ZipCode = null;
            City = null;
            AddressId = null;
            Jordstykke = null;
            BfeNumber = null;
        }

        public Address(string streetAndHouseNumber, string zipCode, string city)
        {
            StreetAndHouseNumber = streetAndHouseNumber;
            ZipCode = zipCode;
            City = city;
            AddressId = null;
            Jordstykke = null;
            BfeNumber = null;
        }
    }
}
