//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using xChanger.MVC.Models.Foundations.Groups;

namespace xChanger.MVC.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Group> InsertGroupAsync(Group group);
        IQueryable<Group> RetrieveAllGroups();
        ValueTask<Group> SelectGroupIdAsync(Guid id);
        ValueTask<Group> UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(Group group);
    }
}
