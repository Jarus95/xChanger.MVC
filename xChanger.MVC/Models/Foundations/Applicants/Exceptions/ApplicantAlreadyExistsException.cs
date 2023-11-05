//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions
{
    public class ApplicantAlreadyExistsException :Xeption
    {
        public ApplicantAlreadyExistsException(Exception innerException)
        :base("Applicant already exists.",innerException)
        { }
    }
}
