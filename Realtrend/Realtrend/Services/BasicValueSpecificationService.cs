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
        public Task<double> GetAssessment(string assessmentProperty)
        {
            throw new NotImplementedException();
        }
    }
}
