//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using xChanger.MVC.Models.Foundations.Groups;

namespace xChanger.MVC.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Group> Group { get; set; }

        public async ValueTask<Group> InsertGroupAsync(Group group) =>
            await InsertAsync(group);

        public IQueryable<Group> RetrieveAllGroups() =>
            SelectAll<Group>();

        public async ValueTask<Group> SelectGroupIdAsync(Guid id) => 
            await SelectAsync<Group>(id);

        public async ValueTask<Group> UpdateGroupAsync(Group group) =>
            await UpdateAsync(group);

        public async ValueTask<Group> DeleteGroupAsync(Group group) =>
            await DeleteAsync(group);
    }
}
