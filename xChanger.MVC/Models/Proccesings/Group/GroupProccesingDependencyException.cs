//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Proccesings.Group
{
    public class GroupProccesingDependencyException : Xeption
    {
        public GroupProccesingDependencyException(Xeption innerException)
            : base("Group dependency error occured fix the errors", innerException)
        { }
    }
}

