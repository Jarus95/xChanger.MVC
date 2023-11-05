//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace xChanger.MVC.Models.Foundations.SpreadSheets.Exceptions;

public class FailedServiceSpreadSheetException : Xeption
{
    public FailedServiceSpreadSheetException(Exception innerException)
        : base(message: "Failed spread sheet service error occured, contact support.", innerException)
    { }
}