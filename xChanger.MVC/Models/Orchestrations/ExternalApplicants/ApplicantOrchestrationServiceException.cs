//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Orchestrations.ExternalApplicants
{
    public class ApplicantOrchestrationServiceException : Xeption
    {
        public ApplicantOrchestrationServiceException(Xeption innerException)
            : base("Applicant service exception occured,contact support", innerException)
        { }
    }
}
