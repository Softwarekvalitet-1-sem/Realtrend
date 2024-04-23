using Newtonsoft.Json;
using Realtrend.Library.Models;

public class PropertyDataService
{
    //Path to mockdata file.
    private readonly string _mockDataPath = "./MockData.json";

    //Get AssessmentProperty from mockdata file using bfeNumber as parameter.
    public async Task<AssessmentProperty> GetAssessmentPropertyByBfeNumberAsync(int bfeNumber)
    {
        var json = await File.ReadAllTextAsync(_mockDataPath);
        var properties = JsonConvert.DeserializeObject<List<AssessmentProperty>>(json);
        return properties.FirstOrDefault(p => p.BFENumber == bfeNumber);
    }

    //Get all AssessmentProperties from Mockdata file.
    public async Task<List<AssessmentProperty>> GetAllAssessmentPropertiesAsync()
    {
        var json = await File.ReadAllTextAsync(_mockDataPath);
        return JsonConvert.DeserializeObject<List<AssessmentProperty>>(json);
    }
}