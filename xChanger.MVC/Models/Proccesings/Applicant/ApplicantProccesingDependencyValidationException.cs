//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Proccesings.Applicant
{
    public class ApplicantProccesingDependencyValidationException : Xeption
    {
        public ApplicantProccesingDependencyValidationException(Xeption innerException)
        : base("Applicant dependency validation error occured,fix the errors", innerException)
        { }
    }
}
