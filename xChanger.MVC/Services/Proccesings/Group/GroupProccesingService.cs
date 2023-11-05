//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.XChanger.Brokers.Loggings;
using Tarteeb.XChanger.Services.Foundations.Group;
using ApplicantsGroup = Tarteeb.XChanger.Models.Foundations.Groups.Group;

namespace Tarteeb.XChanger.Services.Proccesings.Group
{
    public partial class GroupProccesingService : IGroupProccesingService
    {
        private readonly IGroupService groupService;
        private readonly ILoggingBroker loggingBroker;

        public GroupProccesingService(IGroupService groupService, ILoggingBroker loggingBroker)
        {
            this.groupService = groupService;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<ApplicantsGroup> EnsureGroupExistsByName(string name)
        {
            ApplicantsGroup maybeGroup = RetrieveGroupByName(name);

            return maybeGroup is null ? await AddGroupAsync(name) : maybeGroup;
        }

        private ValueTask<ApplicantsGroup> AddGroupAsync(string name) =>
        TryCatch(async() =>
        {
            ApplicantsGroup group = new ApplicantsGroup();

            group.Id = Guid.NewGuid();
            group.GroupName = name;

            return await groupService.AddGroupAsyc(group);
        });

        public ApplicantsGroup RetrieveGroupByName(string name)
        {
            IQueryable<ApplicantsGroup> Groups = groupService.RetrieveAllGroups();
            ApplicantsGroup group = 
                Groups.FirstOrDefault(groupName => groupName.GroupName == name);

            return group;
        }
    }
}
