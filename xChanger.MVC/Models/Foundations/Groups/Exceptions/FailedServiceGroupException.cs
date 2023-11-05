//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Groups.Exceptions
{
    public class FailedServiceGroupException : Xeption
    {
        public FailedServiceGroupException(Exception exception)
            : base("Group service error", exception)
        { }
    }
}
