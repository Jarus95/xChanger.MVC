using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions
{
    public class FailedApplicantServiceException : Xeption
    {
        public FailedApplicantServiceException(Exception innerException) 
            : base("Failed Pplicant sevice error occured",innerException) 
        { }
    }
}
