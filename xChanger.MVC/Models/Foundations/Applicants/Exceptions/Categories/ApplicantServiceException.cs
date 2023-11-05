//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace xChanger.MVC.Models.Foundations.Applicants.Exceptions.Categories
{
    public class ApplicantServiceException : Xeption
    {
        public ApplicantServiceException(Exception innerException)
        : base("Applicant service error occured", innerException)
        { }

    }
}
