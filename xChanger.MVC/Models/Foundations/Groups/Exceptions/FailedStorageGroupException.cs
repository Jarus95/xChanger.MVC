//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace xChanger.MVC.Models.Foundations.Groups.Exceptions
{
    public class FailedStorageGroupException : Xeption
    {
        public FailedStorageGroupException(Exception exception)
            : base("Failed storage error occured contact support", exception)
        { }
    }
}
