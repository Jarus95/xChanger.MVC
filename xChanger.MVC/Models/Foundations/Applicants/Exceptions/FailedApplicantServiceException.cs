using System;
using Xeptions;

namespace xChanger.MVC.Models.Foundations.Applicants.Exceptions
{
    public class FailedApplicantServiceException : Xeption
    {
        public FailedApplicantServiceException(Exception innerException) 
            : base("Failed Pplicant sevice error occured",innerException) 
        { }
    }
}
