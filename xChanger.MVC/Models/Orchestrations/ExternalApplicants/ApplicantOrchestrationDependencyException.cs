//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Orchestrations.ExternalApplicants
{
    public class ApplicantOrchestrationDependencyException : Xeption
    {
        public ApplicantOrchestrationDependencyException(Xeption innerException)
            : base("Applicant dependency error occured,fix the errors", innerException)
        {  }
    }
}
