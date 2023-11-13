//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Orchestrations.ExternalApplicants
{
    public class ExternalApplicantOrchestrationValidationException : Xeption
    {
        public ExternalApplicantOrchestrationValidationException(Xeption innerException)
            : base("External applicant error occured. Fix the errors and try again", innerException)
        { }
    }
}
