//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.Groups.Exceptions.Categories
{
    public class GroupValidationException : Xeption
    {
        public GroupValidationException(Xeption innerException)
            : base("Group validate error occured. fix the errors", innerException)
        { }
    }
}
