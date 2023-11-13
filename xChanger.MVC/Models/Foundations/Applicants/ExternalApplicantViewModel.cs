//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using xChanger.MVC.Models.Foundations.Groups;

namespace xChanger.MVC.Models.Foundations.Applicants
{
    public class ExternalApplicantViewModel
    {
        public ExternalApplicantModel ExternalApplicantModel { get; set; }
        public IQueryable<SelectListItem> SelectListGroups { get; set; }
    }
}
