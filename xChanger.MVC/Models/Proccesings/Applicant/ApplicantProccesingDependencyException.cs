//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Proccesings.Applicant
{
    public class ApplicantProccesingDependencyException : Xeption
    {
        public ApplicantProccesingDependencyException(Xeption innerException)
        : base("Applicant dependency error occured,fix the errors", innerException)
        { }
    }
}
