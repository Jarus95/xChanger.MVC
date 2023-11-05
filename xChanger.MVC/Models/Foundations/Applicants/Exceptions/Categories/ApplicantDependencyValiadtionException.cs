//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace xChanger.MVC.Models.Foundations.Applicants.Exceptions.Categories
{
    public class ApplicantDependencyValidationException : Xeption
    {
        public ApplicantDependencyValidationException(Exception innerException)
        : base("Applicant dependency validation error ocured.Fix the error and try again", innerException)
        { }
    }
}
