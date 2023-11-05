//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions
{
    public class FailedApplicantStorageException : Xeption
    {
        public FailedApplicantStorageException(Exception innerException)
            : base("Failed applicant storage error occured,",innerException) 
        { }
    }
}
