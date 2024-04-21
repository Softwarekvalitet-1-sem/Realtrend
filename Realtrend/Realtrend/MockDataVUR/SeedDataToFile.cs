using Newtonsoft.Json;
using Realtrend.Models;

public static class SeedDataToFile
{
    public static void CreateAndSaveMockData()
    {
        var properties = CreateMockAssessmentProperties();
        var jsonString = JsonConvert.SerializeObject(properties, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText("MockData.json", jsonString);
    }

    private static List<AssessmentProperty> CreateMockAssessmentProperties()
    {
        List<AssessmentProperty> properties = new List<AssessmentProperty>();

        for (int i = 0; i < 10; i++)
        {

            var bfeNumber = GenerateRandomBfeNumber();

            var property = new AssessmentProperty
            {
                VURejendomsid = RandomNumber(),
                ESRejendomsnummer = RandomNumber(),
                ESRkommunenummer = GenerateRandomMunicipalityNumber(),
                VurderingsejendomID = RandomNumber(),
                BFENummber = bfeNumber,
                ValueSpecifications = CreateBasicValueSpecifications(RandomNumber().ToString(), bfeNumber)
            };

            properties.Add(property);
        }

        return properties;
    }

    private static List<BasicValueSpecification> CreateBasicValueSpecifications(string propertyId, int bfeNumber)
    {
        List<BasicValueSpecification> specs = new List<BasicValueSpecification>();

        for (int i = 0; i < 5; i++)
        {
            var spec = new BasicValueSpecification(propertyId)
            {
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

    private static double RandomNumber()
    {
        Random random = new Random();
        return Math.Round(random.NextDouble() * 10000, 0);
    }

    private static int GenerateRandomBfeNumber()
    {
        Random random = new Random();

        int randomBfe = random.Next(1000000, 9999999);

        return randomBfe;
    }

    private static double GenerateRandomArea()
    {
        Random random = new Random();

        double randomArea = random.Next(0, 1000);

        return Math.Round(randomArea, 0);
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
