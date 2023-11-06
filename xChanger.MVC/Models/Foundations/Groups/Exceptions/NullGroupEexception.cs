//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Foundations.Groups.Exceptions
{
    public class NullGroupEexception : Xeption
    {
        public NullGroupEexception()
            : base("Group is null")
        { }
    }
}
