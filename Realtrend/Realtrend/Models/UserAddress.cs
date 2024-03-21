namespace Realtrend.Models
{
    public class UserAddress
    {
        public string StreetAndHouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string AddressId { get; set; }
        public string Jordstykke { get; set; }
        public string BfeNumber { get; set; }

        public UserAddress()
        {
        }

        public UserAddress(string streetAndHouseNumber, string zipCode, string city)
        {
            StreetAndHouseNumber = streetAndHouseNumber;
            ZipCode = zipCode;
            City = city;
        }
    }
}
