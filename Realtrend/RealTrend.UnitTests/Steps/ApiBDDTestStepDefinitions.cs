using Realtrend.Library;
using Reqnroll;
using FluentAssertions;
using Newtonsoft.Json;

namespace RealTrend.UnitTests.Steps
	{
		[Binding]
		public class ApiBDDTestStepDefinitions
		{
      private string _address = "Provstebakken+23D";

      private static List<Address> _addressList;

      /// 
      /// Scenario: User types in a address and address id
      /// 
      [Given(@"the user types in a address")]
      public void Giventheusertypesinaaddress()
      {
        _address.Should().NotBeNullOrEmpty();
      }

      
      [When(@"the user clicks on the submit button")]
      public async Task Whentheuserclicksonthesubmitbutton()
      {
        string endpoint = $"https://api.dataforsyningen.dk/adresser?q={_address}&struktur=mini";
        _addressList = await GetAddressesAsync(endpoint);
      }

            
      [Then(@"the user will get address id")]
      public void Thentheuserwillgetaddressid()
      {
        _addressList.Should().Contain(x => x.Vejnavn == "Provstebakken" && x.Husnr == "23D");
        _addressList.Should().Contain(x => !string.IsNullOrEmpty(x.Id));
      }

      // Method to get all repositories
      private static async Task <List<Address>> GetAddressesAsync(string endpoint)
      {
        using (HttpClient client = new HttpClient())
        {
            try
            {
              HttpResponseMessage response = await client.GetAsync(endpoint);
              if (response.IsSuccessStatusCode)
              {
                  string responseBody = await response.Content.ReadAsStringAsync();
                  _addressList = JsonConvert.DeserializeObject<List<Address>>(responseBody);
              }
              else
              {
                  Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
              }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            
            return _addressList;  
        }
      }

    }
	}