using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Realtrend.Library.Models;

public static class SeedDataToFile
{
    //Opretter mockdata filen med navnet MockData.json.
    public static void CreateAndSaveMockData()
    {
        var properties = CreateMockAssessmentProperties();
        var dateFormat = new IsoDateTimeConverter { DateTimeFormat = "dd-MM-yyyy" };

        var jsonString = JsonConvert.SerializeObject(properties, Formatting.Indented, dateFormat);
        File.WriteAllText("MockData.json", jsonString);
    }

    //Opretter 10 forskellige AssessmentProperty mock objekter, den første med Seebladsgade 1's BFE Nummer
    //Resten med random data.
    private static List<AssessmentProperty> CreateMockAssessmentProperties()
    {
        List<AssessmentProperty> properties = new List<AssessmentProperty>();
        DateTime startDate = new DateTime(2018, 1, 1);

        for (int i = 0; i < 10; i++)
        {
            var bfeNumber = GenerateRandomBfeNumber(i);

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

    //Opretter 5 BasicValueSpecification objekter som indeholdes i hver AssessmentProperty.
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

    //Opretter et random property number, som har 6 cifre.
    private static int GenerateRandomPropertyNumber()
    {
        Random random = new Random();
        return random.Next(100000, 999999);
    }

    //Opretter et random property ID, som har 7 cifre.
    private static int GenerateRandomPropertyId()
    {
        Random random = new Random();
        return random.Next(1000000, 9999999);
    }

    //Opretter et totalt random number
    private static int RandomNumber()
    {
        Random random = new Random();
        return random.Next();
    }

    //Opretter et random BFE nummer med 7 cifre, med index som parameter 
    //Ved index 0 oprettes Seebladsgades BFE nummer, da resten er random. 
    private static int GenerateRandomBfeNumber(int index)
    {
        if (index == 0)
        {
            return 5475678;
        }
        else
        {
            Random random = new Random();

            int randomBfe = random.Next(1000000, 9999999);

            return randomBfe;
        }
    }

    //Opretter et random areal til AssessmentProperty
    private static int GenerateRandomArea()
    {
        Random random = new Random();

        int randomArea = random.Next(0, 1000);

        return randomArea;
    }

    //Opretter en random pris imellem 1.000.000 og 10.000.000
    private static double GenerateRandomPrice()
    {
        Random random = new Random();

        int randomPrice = random.Next(1000000, 10000000);

        double randomDecimal = random.NextDouble() * 0.99;

        return Math.Round(randomPrice + randomDecimal, 2);
    }

    //Giver et random kommunenummer fra listen til en AssessmentProperty.
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

    //Bruges til at læse Mockdataen.
    public static List<AssessmentProperty> ReadMockData()
    {
        var jsonString = File.ReadAllText("MockData.json");
        return JsonConvert.DeserializeObject<List<AssessmentProperty>>(jsonString);
    }
}
