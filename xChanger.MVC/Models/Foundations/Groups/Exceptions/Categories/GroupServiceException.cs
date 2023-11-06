//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Foundations.Groups.Exceptions.Categories
{
    public class GroupServiceException : Xeption
    {
        public GroupServiceException(Xeption innerException)
            : base("Group service error occured contact support",innerException)
        { }
    }
}
