//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Proccesings.Group
{
    public class GroupProccesingServiceException : Xeption
    {
        public GroupProccesingServiceException(Xeption inneerException)
            : base("Group Service error occured contact support ", inneerException)
        { }
    }
}
