//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Orchestrations.Groups
{
    public class GroupOrchestartionDependencyException : Xeption
    {
        public GroupOrchestartionDependencyException(Xeption innerException)
            : base("Group dependency error occured fix the errors",  innerException)
        { }
    }
}
