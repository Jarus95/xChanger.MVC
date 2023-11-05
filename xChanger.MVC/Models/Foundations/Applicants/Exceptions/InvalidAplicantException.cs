//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions
{
    public class InvalidApplicantException: Xeption
    {
        public InvalidApplicantException()
            : base("Applicant is invalid") 
        { }
    }
}
