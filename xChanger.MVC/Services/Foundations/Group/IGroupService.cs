//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using System.Threading.Tasks;
using ApplicantsGroup = xChanger.MVC.Models.Foundations.Groups.Group;
namespace xChanger.MVC.Services.Foundations.Group
{
    public interface IGroupService
    {
        ValueTask<ApplicantsGroup> AddGroupAsync(ApplicantsGroup group);
        IQueryable<ApplicantsGroup> RetrieveAllGroups();
        ValueTask<ApplicantsGroup> UpdateGroupAsync(ApplicantsGroup group);
        Task DeleteGroupAsync(ApplicantsGroup group);
        string GroupGetDownloadedFileName();
    }
}
