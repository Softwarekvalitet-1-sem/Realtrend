using Realtrend.Library.Interfaces;
using System.Threading.Tasks;

namespace Realtrend.Services
{
    public class BasicValueSpecificationService : IBasicValueSpecification
    {
        private readonly IHttpService _httpService;

        public BasicValueSpecificationService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public double GetAssessment(string assessmentProperty)
        {
            // Brug den nye HttpService til at fetche data og erstat den statiske værdi nedenunder
            return 123.45;
        }
    }
}
