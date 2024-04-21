using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Realtrend.Models;

public static class SeedDataToFile
{
    public static void CreateAndSaveMockData()
    {
        var properties = CreateMockAssessmentProperties();
        var dateFormat = new IsoDateTimeConverter { DateTimeFormat = "dd-MM-yyyy" };

        var jsonString = JsonConvert.SerializeObject(properties, Formatting.Indented, dateFormat);
        File.WriteAllText("MockData.json", jsonString);
    }

    private static List<AssessmentProperty> CreateMockAssessmentProperties()
    {
        List<AssessmentProperty> properties = new List<AssessmentProperty>();
        DateTime startDate = new DateTime(2018, 1, 1);

        for (int i = 0; i < 10; i++)
        {

            var bfeNumber = GenerateRandomBfeNumber();

            var property = new AssessmentProperty
            {
                VURejendomsid = GenerateRandomPropertyId(),
                ESRejendomsnummer = GenerateRandomPropertyNumber(),
                ESRkommunenummer = GenerateRandomMunicipalityNumber(),
                VurderingsejendomID = RandomNumber(),
                BFENumber = bfeNumber,
                ValueSpecifications = CreateBasicValueSpecifications(RandomNumber().ToString(), bfeNumber, startDate)
            };

            properties.Add(property);
        }

        return properties;
    }

    private static List<BasicValueSpecification> CreateBasicValueSpecifications(string propertyId, int bfeNumber, DateTime date)
    {
        List<BasicValueSpecification> specs = new List<BasicValueSpecification>();

        for (int i = 0; i < 5; i++)
        {
            var spec = new BasicValueSpecification(propertyId)
            {
                Dato = date.AddYears(i),
                Areal = GenerateRandomArea(),
                Beløb = GenerateRandomPrice(),
                EnhedBeløb = GenerateRandomPrice(),
                Løbenummer = RandomNumber(),
                PrisKode = "PK" + RandomNumber().ToString(),
                Tekst = "Beskrivelse for BFE: " + bfeNumber
            };

            specs.Add(spec);
        }

        return specs;
    }

    private static int GenerateRandomPropertyNumber()
    {
        Random random = new Random();
        return random.Next(100000, 999999);
    }

    private static int GenerateRandomPropertyId()
    {
        Random random = new Random();
        return random.Next(1000000, 9999999);
    }

    private static int RandomNumber()
    {
        Random random = new Random();
        return random.Next();
    }

    private static int GenerateRandomBfeNumber()
    {
        Random random = new Random();

        int randomBfe = random.Next(1000000, 9999999);

        return randomBfe;
    }

    private static int GenerateRandomArea()
    {
        Random random = new Random();

        int randomArea = random.Next(0, 1000);

        return randomArea;
    }

    private static double GenerateRandomPrice()
    {
        Random random = new Random();

        int randomPrice = random.Next(1000000, 10000000);

        double randomDecimal = random.NextDouble() * 0.99;

        return Math.Round(randomPrice + randomDecimal, 2);
    }

    private static int GenerateRandomMunicipalityNumber()
    {
        var municipalityNumbers = new int[]
        {
            101, // København
            165, // Albertslund
            151, // Ballerup
            461, //Odense
            751, //Aarhus

        };

        Random random = new Random();

        var randomlySelectedMunicipalityIndex = random.Next(municipalityNumbers.Length);

        return municipalityNumbers[randomlySelectedMunicipalityIndex];
    }

    public static List<AssessmentProperty> ReadMockData()
    {
        var jsonString = File.ReadAllText("MockData.json");
        return JsonConvert.DeserializeObject<List<AssessmentProperty>>(jsonString);
    }
}
