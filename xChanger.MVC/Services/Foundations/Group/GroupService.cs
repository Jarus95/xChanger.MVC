//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using xChanger.MVC.Brokers.DateTimes;
using xChanger.MVC.Brokers.Loggings;
using xChanger.MVC.Brokers.Storages;
using xChanger.MVC.Models.Foundations.Groups.Exceptions;
using ApplicantsGroup = xChanger.MVC.Models.Foundations.Groups.Group;
namespace xChanger.MVC.Services.Foundations.Group
{
    public partial class GroupService : IGroupService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public GroupService(IStorageBroker storageBroker, IDateTimeBroker dateTimeBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<ApplicantsGroup> AddGroupAsyc(ApplicantsGroup group) =>
        TryCatch(async() =>
        {
            ValidateGroupIsNotNull(group);
            return await storageBroker.InsertGroupAsync(group);
        });

        public IQueryable<ApplicantsGroup> RetrieveAllGroups() =>
              TryCatch(() => storageBroker.RetrieveAllGroups());
    }
}
