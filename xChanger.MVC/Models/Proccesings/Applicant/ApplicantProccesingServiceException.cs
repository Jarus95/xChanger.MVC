//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Proccesings.Applicant
{
    public class ApplicantProccesingServiceException : Xeption
    {
        public ApplicantProccesingServiceException(Xeption innerException)
        : base("Applicant service exception occured,contact support", innerException)
        { }
    }
}
