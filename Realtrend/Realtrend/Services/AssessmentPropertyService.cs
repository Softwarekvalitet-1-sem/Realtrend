using Realtrend.Library.Interfaces;
using Realtrend.Library.Models;

namespace Realtrend.Services
{
    public class AssessmentPropertyService : IAssessmentProperty
    {
        private readonly IAssessmentProperty _assessmentProperty;


        public AssessmentPropertyService(IAssessmentProperty assessmentPropertyService)
        {
            _assessmentProperty = assessmentPropertyService;
        }

        // TODO: Implement this method
        public async Task<AssessmentProperty> GetAssessmentPropertyAsync(string propertyId)
        {
            return await _assessmentProperty.GetAssessmentPropertyAsync(propertyId);

        }

    }
}
