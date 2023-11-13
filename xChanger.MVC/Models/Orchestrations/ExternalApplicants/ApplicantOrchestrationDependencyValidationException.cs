//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Orchestrations.ExternalApplicants
{
    public class ApplicantOrchestrationDependencyValidationException : Xeption
    {
        public ApplicantOrchestrationDependencyValidationException(Xeption innerException)
              : base("Applicant dependency validation error occured,fix the errors", innerException)
        { }
    }
}
