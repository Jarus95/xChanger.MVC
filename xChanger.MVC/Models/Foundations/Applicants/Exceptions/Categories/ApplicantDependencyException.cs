//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace xChanger.MVC.Models.Foundations.Applicants.Exceptions.Categories
{
    public class ApplicantDependencyException : Xeption
    {
        public ApplicantDependencyException(Exception innerException)
            : base("Applicant dependency error ocured.Fix the error and try again", innerException)
        { }
    }
}
