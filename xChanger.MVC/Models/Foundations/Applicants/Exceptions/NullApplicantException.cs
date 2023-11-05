using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions
{
    public class NullApplicantException: Xeption
    {
        public NullApplicantException()
        : base("Applicant is null.") 
        { }
    }
}
