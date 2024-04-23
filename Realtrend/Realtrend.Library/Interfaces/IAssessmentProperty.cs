using Realtrend.Library.Models;

namespace Realtrend.Library.Interfaces
{
    public interface IAssessmentProperty
    {
        Task<AssessmentProperty> GetAssessmentPropertyAsync(string address);
    }
}
