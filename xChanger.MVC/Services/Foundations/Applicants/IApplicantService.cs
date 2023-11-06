//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Services.Foundations.Applicants
{
    public interface IApplicantService
    {
        ValueTask<ExternalApplicantModel> AddApplicantAsync(ExternalApplicantModel externalApplicantModel);
        IQueryable<ExternalApplicantModel> RetrieveAllExternalApplicantModels();
    }
}
