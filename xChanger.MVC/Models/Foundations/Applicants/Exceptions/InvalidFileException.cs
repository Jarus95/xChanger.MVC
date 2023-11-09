//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace xChanger.MVC.Models.Foundations.Applicants.Exceptions
{
    public class InvalidFileException : Xeption
    {
        public InvalidFileException(Exception innerException)
            :base("Data is Invalid try upload other file", innerException)
        { }
    }
}
