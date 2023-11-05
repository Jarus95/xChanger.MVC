//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Orchestrations.Groups
{
    public class GroupOchrestartionDependencyException : Xeption
    {
        public GroupOchrestartionDependencyException(Xeption innerException)
            : base("Group dependency error occured fix the errors",  innerException)
        { }
    }
}
