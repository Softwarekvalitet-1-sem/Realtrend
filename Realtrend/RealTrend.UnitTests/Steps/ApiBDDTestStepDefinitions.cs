using Realtrend.Library;
using Reqnroll;
using FluentAssertions;
using Newtonsoft.Json;
using System.Text.Json;

namespace RealTrend.UnitTests.Steps
	{
		[Binding]
		public class ApiBDDTestStepDefinitions
		{
      // Variables to be used in the tests
      private static string? _address;
      private static List<Address>? _addressList;
      private string _addressID = "0a3f50b4-876e-32b8-e044-0003ba298018";
      private string _jordstykke = "436266";
      private string _bfeNumber = "5464000";
      private static string? _jordstykkeFromApi;
      private static string? _bfeFromApi;



      /// 
      /// Scenario: User types in a address and get address id
      /// 
      [Given(@"the user types in a address (.*)")]
      public void GivenTheUserTypesInAAddress(string address)
      {
        _address = address;
      }

      
      [When(@"the user clicks on the submit button")]
      public async Task WhenTheUserClicksOnTheSubmitButton()
      {
        string endpoint = $"https://api.dataforsyningen.dk/adresser?q={_address}&struktur=mini";
        _addressList = await GetAddressesAsync(endpoint);
      }

            
      [Then(@"the user will get the correct address id")]
      public void ThenTheUserWillGetTheCorrectAddressId()
      {
        _addressList.Should().Contain(x => x.Vejnavn == "Provstebakken" 
                                      && x.Husnr == "23D" 
                                      && x.Id == _addressID
                                      );
      }



      /// 
      /// Scenario: System is able to find the jordstykke number from address id
      /// 
      [Given(@"the system has a address id")]
      public void GivenTheSystemHasAAddressId()
      {
         _addressID.Should().NotBeNullOrEmpty();
      }
      
      [When(@"the system sends a GET jordstykke request to the api")]
      public async Task WhenTheSystemSendsAJordstykkeGETRequestToTheApi()
      {
        var endpoint = $"https://services.datafordeler.dk/DAR/DAR/2.0.0/rest/adresse?id={_addressID}&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";
        _jordstykkeFromApi = await GetJordstykkeAsync(endpoint);
      }

      [Then(@"the system will retrieve the correct jordstykke number")]
      public void ThenTheSystemWillRetrieveTheCorrectJordstykkeNumber()
      {
        _jordstykkeFromApi.Should().Be(_jordstykke);
      }



      /// 
      /// Scenario: System is able to find the jordstykke number from address id
      ///
      [Given(@"the system has jordstykke number (.*)")]
      public void GivenTheSystemHasJordstykkeNumber(string jordstykke)
      {
        _jordstykkeFromApi = jordstykke;
      }

      
      [When(@"the system sends the GET BFE request to the api")]
      public async Task WhenTheSystemSendsTheGETBFERequestToTheApi()
      {
        var endpoint = $"https://services.datafordeler.dk//BBR/BBRPublic/1/rest/grund?jordstykke={_jordstykke}&&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";
        _bfeFromApi = await GetBfeNumberAsync(endpoint);
      }
      
      [Then(@"the system will retrieve the BFE number")]
      public void ThenTheSystemWillRetrieveTheBFENumber()
      {
        _bfeFromApi.Should().Be(_bfeNumber);
      }



      /// 
      /// HELPER METHODS
      /// 

      // Method to get a address id from the api
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

      // Method to get a jordstykke number from the api
      private static async Task <string> GetJordstykkeAsync(string endpoint)
      {
        using (HttpClient client = new HttpClient())
        {
            try
            {
              HttpResponseMessage response = await client.GetAsync(endpoint);
              if (response.IsSuccessStatusCode)
              {
                  string responseBody = await response.Content.ReadAsStringAsync();
                  using var jsonDoc = JsonDocument.Parse(responseBody);
                  var rootElement = jsonDoc.RootElement;

                  // Navigate to the specific jordstykke value
                  if (rootElement.ValueKind == JsonValueKind.Array && rootElement.GetArrayLength() > 0)
                  {
                      var husnummer = rootElement[0].GetProperty("husnummer");
                      if (husnummer.TryGetProperty("jordstykke", out var jordstykke))
                      {
                          _jordstykkeFromApi = jordstykke.GetString();
                      }
                  }
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

            return _jordstykkeFromApi;
        }
      }

      // Method to get a BFE number from the api
      private static async Task <string> GetBfeNumberAsync(string endpoint)
      {
        using (HttpClient client = new HttpClient())
        {
            try
            {
              HttpResponseMessage response = await client.GetAsync(endpoint);
              if (response.IsSuccessStatusCode)
              {
                  string responseBody = await response.Content.ReadAsStringAsync();
                  using var jsonDoc = JsonDocument.Parse(responseBody);
                  var rootElement = jsonDoc.RootElement;

                  if (rootElement.ValueKind == JsonValueKind.Array && rootElement.GetArrayLength() > 0)
                  {
                      var bestemtFastEjendom = rootElement[0].GetProperty("bestemtFastEjendom");
                      if (bestemtFastEjendom.TryGetProperty("bfeNummer", out var bfeNumber))
                      {
                          _bfeFromApi = bfeNumber.ToString();
                      }
                  }
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

            return _bfeFromApi;
        }
      }
    }
	}