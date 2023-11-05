//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Groups.Exceptions
{
    public class AlreadyExistsGroupException : Xeption
    {
        public AlreadyExistsGroupException(Exception exception)
            : base("Group already exists", exception)
        { }
    }
}
