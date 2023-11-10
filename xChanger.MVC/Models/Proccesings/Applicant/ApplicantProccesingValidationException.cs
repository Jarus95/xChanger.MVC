//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Proccesings.Applicant
{
    public class ApplicantProccesingValidationException : Xeption
    {
        public ApplicantProccesingValidationException(Xeption innerException)
        : base("Appliacant validation error occured,fix the errors", innerException)
        { }
    }
}
