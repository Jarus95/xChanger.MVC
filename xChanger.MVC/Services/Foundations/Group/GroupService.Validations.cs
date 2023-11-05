//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using xChanger.MVC.Models.Foundations.Groups.Exceptions;
using ApplicantsGroup = xChanger.MVC.Models.Foundations.Groups.Group;
namespace xChanger.MVC.Services.Foundations.Group
{
    public partial class GroupService
    {

        private dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidGroupException = new InvalidGroupException();
            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidGroupException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }
            invalidGroupException.ThrowIfContainsErrors();
        }
        private void ValidateGroupIsNotNull(ApplicantsGroup group)
        {
            if (group is null)
            {
                throw new NullGroupEexception();
            }

            Validate(
                (IsInvalid(group.Id), nameof(ApplicantsGroup.Id)),
                (IsInvalid(group.GroupName), nameof(ApplicantsGroup.GroupName)));
        }
    }
}
