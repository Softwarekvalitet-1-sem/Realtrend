using Realtrend.Models;

namespace Realtrend.Interfaces
{
    public interface IBasicValueSpecification
    {
        double GetAssessment(string assessmentProperty);
    }
}
