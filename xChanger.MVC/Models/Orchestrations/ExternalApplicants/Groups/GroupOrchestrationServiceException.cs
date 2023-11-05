//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Orchestrations.Groups
{
    public class GroupOrchestrationServiceException : Xeption
    {
        public GroupOrchestrationServiceException(Xeption innerException)
           : base("Group Service error occured contact support", innerException)
        { }
    }
}
