//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.XChanger.Models.Foundations.Applicants;

namespace Tarteeb.XChanger.Services.Foundations.Applicants
{
    public interface IApplicantService
    {
        ValueTask<ExternalApplicantModel> AddApplicantAsync(ExternalApplicantModel externalApplicantModel);
        IQueryable<ExternalApplicantModel> RetrieveAllExternalApplicantModels();
    }
}
