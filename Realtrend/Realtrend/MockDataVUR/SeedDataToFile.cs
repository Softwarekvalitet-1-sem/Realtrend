using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Realtrend.Models; // Ensure this is the correct namespace for your models

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
            var property = new AssessmentProperty
            {
                VURejendomsid = RandomNumber(),
                ESRejendomsnummer = RandomNumber(),
                ESRkommunenummer = RandomNumber(),
                VurderingsejendomID = RandomNumber(),
                BFENummber = "BFE" + RandomNumber().ToString(),
                ValueSpecifications = CreateBasicValueSpecifications("BFE" + RandomNumber().ToString())
            };

            properties.Add(property);
        }

        return properties;
    }

    private static List<BasicValueSpecification> CreateBasicValueSpecifications(string propertyId)
    {
        List<BasicValueSpecification> specs = new List<BasicValueSpecification>();

        for (int i = 0; i < 5; i++)
        {
            var spec = new BasicValueSpecification(propertyId)
            {
                Areal = RandomNumber(),
                Beløb = RandomNumber(),
                EnhedBeløb = RandomNumber(),
                Løbenummer = RandomNumber(),
                PrisKode = "PK" + RandomNumber().ToString(),
                Tekst = "Sample Text " + RandomNumber().ToString()
            };

            specs.Add(spec);
        }

        return specs;
    }

    private static double RandomNumber()
    {
        Random random = new Random();
        return random.NextDouble() * 10000; // Adjust the range as per your requirement
    }

    public static List<AssessmentProperty> ReadMockData()
    {
        var jsonString = File.ReadAllText("MockData.json");
        return JsonConvert.DeserializeObject<List<AssessmentProperty>>(jsonString);
    }
}
