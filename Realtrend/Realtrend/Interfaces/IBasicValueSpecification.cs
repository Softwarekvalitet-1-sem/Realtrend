using Realtrend.Models;

namespace Realtrend.Interfaces
{
    public interface IBasicValueSpecification
    {
        Task<double> GetAssessment(AssessmentProperty assessmentProperty);
    }
}
