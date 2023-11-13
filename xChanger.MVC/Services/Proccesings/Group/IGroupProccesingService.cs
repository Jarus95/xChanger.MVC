//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using System.Threading.Tasks;
using xChanger.MVC.Models.Foundations.Applicants;
using ApplicantsGroup = xChanger.MVC.Models.Foundations.Groups.Group;
namespace xChanger.MVC.Services.Proccesings.Group
{
    public interface IGroupProccesingService
    {
        ValueTask<ApplicantsGroup> EnsureGroupExistsByName(string name);
        ApplicantsGroup RetrieveGroupByName(string name);
        IQueryable<ApplicantsGroup> RetrieveAllGroups();
        ValueTask<ApplicantsGroup> UpdateGroupAsync(ApplicantsGroup group);
        Task DeleteGroupAsync(ApplicantsGroup group);
        string GroupGetDownloadedFileName();
    }
}
