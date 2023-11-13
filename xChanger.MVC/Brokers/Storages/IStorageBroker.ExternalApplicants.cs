//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using System.Threading.Tasks;
using System;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<ExternalApplicantModel> InsertExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel);
        IQueryable<ExternalApplicantModel> RetrieveAllExternalApplicantModels();
        ValueTask<ExternalApplicantModel> SelectExternalApplicantModelIdAsync(Guid id);
        ValueTask<ExternalApplicantModel> UpdateExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel);
        Task DeleteExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel);
    }
}
