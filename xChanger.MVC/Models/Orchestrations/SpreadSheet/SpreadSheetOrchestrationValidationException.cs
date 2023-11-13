﻿//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Orchestrations.SpreadSheet
{
    public class SpreadSheetOrchestrationValidationException : Xeption
    {
        public SpreadSheetOrchestrationValidationException(Xeption innerException)
             : base("Spreadsheet validation error occured. Fix the errors and try again", innerException)
        { }
    }
}
