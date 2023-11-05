//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.Models.Foundations.Groups.Exceptions.Categories
{
    public class GroupDependencyValidationException : Xeption
    {
        public GroupDependencyValidationException(Xeption innerException)
            : base("Group dependency validation error occured fix the errors", innerException)
        { }
    }
}
