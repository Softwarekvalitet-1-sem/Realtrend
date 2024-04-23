using Realtrend.Models;

namespace Realtrend.Interfaces
{
    public interface IAssessmentProperty
    {
        Task<AssessmentProperty> GetAssessmentPropertyAsync(string address);
    }
}
