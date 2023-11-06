//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace xChanger.MVC.Models.Foundations.Applicants.Exceptions
{
    public class LockedApplicantException :Xeption
    {
        public LockedApplicantException(Exception exception)
            : base("Applicant is busy",exception) 
        { }
    }
}
