//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions
{
    public class LockedApplicantException :Xeption
    {
        public LockedApplicantException(Exception exception)
            : base("Applicant is busy",exception) 
        { }
    }
}
