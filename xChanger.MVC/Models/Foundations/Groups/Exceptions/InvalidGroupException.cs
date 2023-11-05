//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Foundations.Groups.Exceptions
{
    public class InvalidGroupException : Xeption
    {
        public InvalidGroupException()
            : base("Group is invalid fix and try again")
        { }
    }
}
