//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Orchestrations.Groups
{
    public class GroupOrchestartionValidationException : Xeption
    {
        public GroupOrchestartionValidationException(Xeption innerException)
            : base("Group validate error occured. fix the errors", innerException)
        { }
    }
}
