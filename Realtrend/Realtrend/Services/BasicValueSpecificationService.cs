using Realtrend.Interfaces;
using Realtrend.Models;

namespace Realtrend.Services
{
    public class BasicValueSpecificationService : IBasicValueSpecification
    {
        private readonly HttpClient _httpClient;

        public BasicValueSpecificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // TODO: Implement this method
        public double GetAssessment(string assessmentProperty)
        {
            return 123.45;
        }
    }
}
