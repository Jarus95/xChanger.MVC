//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Proccesings.Group
{
    public class GroupProccesingDependencValidationException : Xeption
    {
        public GroupProccesingDependencValidationException(Xeption innerException)
            : base("Group dependency validation error occured fix the errors", innerException)
        { }
    }
}
