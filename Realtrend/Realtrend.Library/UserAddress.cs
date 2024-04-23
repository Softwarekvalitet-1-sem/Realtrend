namespace Realtrend.Library
{
    public class UserAddress
    {
        public string? StreetAndHouseNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? AddressId { get; set; }
        public string? Jordstykke { get; set; }
        public string? BfeNumber { get; set; }

        public UserAddress()
        {
            StreetAndHouseNumber = null;
            ZipCode = null;
            City = null;
            AddressId = null;
            Jordstykke = null;
            BfeNumber = null;
        }

        public UserAddress(string streetAndHouseNumber, string zipCode, string city)
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
