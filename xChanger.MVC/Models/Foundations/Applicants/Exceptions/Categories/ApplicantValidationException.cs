//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace xChanger.MVC.Models.Foundations.Applicants.Exceptions.Categories
{
    public class ApplicantValidationException : Xeption
    {
        public ApplicantValidationException(Exception innerException)
        : base("Applicant validation error ocured,fix the error and try again", innerException)
        { }
    }
}
