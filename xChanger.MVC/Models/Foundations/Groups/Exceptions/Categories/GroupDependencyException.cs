//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Foundations.Groups.Exceptions.Categories
{
    public class GroupDependencyException : Xeption
    {
        public GroupDependencyException(Xeption innerException)
            : base("Group dependency error occured fix the errors", innerException)
        { }
    }
}
