using Xeptions;

namespace xChanger.MVC.Models.Foundations.Applicants.Exceptions
{
    public class NullApplicantException: Xeption
    {
        public NullApplicantException()
        : base("Applicant is null.") 
        { }
    }
}
