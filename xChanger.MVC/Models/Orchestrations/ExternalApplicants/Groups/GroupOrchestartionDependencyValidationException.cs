//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Orchestrations.Groups
{
    public class GroupOrchestartionDependencyValidationException :Xeption
    {
        public GroupOrchestartionDependencyValidationException(Xeption innerException)
            :base("Group dependency validation error occured fix the errors", innerException)
        { }
    }
}
