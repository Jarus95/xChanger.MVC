//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Groups.Exceptions
{
    public class LockedGroupException : Xeption
    {
        public LockedGroupException(Exception exception)
           : base("Group is busy", exception)
        { }
    }
}
