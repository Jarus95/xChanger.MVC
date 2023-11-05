//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using System.Threading.Tasks;
using System;
using Tarteeb.XChanger.Models.Foundations.Applicants;

namespace Tarteeb.XChanger.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<ExternalApplicantModel> InsertExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel);
        IQueryable<ExternalApplicantModel> RetrieveAllExternalApplicantModels();
        ValueTask<ExternalApplicantModel> SelectExternalApplicantModelIdAsync(Guid id);
        ValueTask<ExternalApplicantModel> UpdateExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel);
        ValueTask<ExternalApplicantModel> DeleteExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel);
    }
}
