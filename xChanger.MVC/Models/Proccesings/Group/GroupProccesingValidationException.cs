//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Proccesings.Group
{
    public class GroupProccesingValidationException : Xeption
    {
        public GroupProccesingValidationException(Xeption innerException)
            : base(message: "Group validate error occured. fix the errors", innerException)
        { }
    }
}
