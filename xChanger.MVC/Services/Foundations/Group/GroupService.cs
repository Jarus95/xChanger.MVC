//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.XChanger.Brokers.DateTimes;
using Tarteeb.XChanger.Brokers.Loggings;
using Tarteeb.XChanger.Brokers.Storages;
using Tarteeb.XChanger.Models.Foundations.Groups.Exceptions;
using ApplicantsGroup = Tarteeb.XChanger.Models.Foundations.Groups.Group;
namespace Tarteeb.XChanger.Services.Foundations.Group
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
