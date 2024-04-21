using Newtonsoft.Json;
using Realtrend.Models;

public class PropertyDataService
{
    private readonly string _mockDataPath = "./MockData.json"; // Adjust the path as necessary.

    public async Task<AssessmentProperty> GetPropertyByBfeNumberAsync(int bfeNumber)
    {
        var json = await File.ReadAllTextAsync(_mockDataPath);
        var properties = JsonConvert.DeserializeObject<List<AssessmentProperty>>(json);
        return properties.FirstOrDefault(p => p.BFENumber == bfeNumber);
    }

    public async Task<List<AssessmentProperty>> GetAllPropertiesAsync()
    {
        var json = await File.ReadAllTextAsync(_mockDataPath);
        return JsonConvert.DeserializeObject<List<AssessmentProperty>>(json);
    }
}