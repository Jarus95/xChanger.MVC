//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace xChanger.MVC.Models.Foundations.SpreadSheets.Exceptions;

public class FailedStorageSpreadSheetException : Xeption
{
    public FailedStorageSpreadSheetException(Exception innerException)
         : base(message: "Failed spread sheet storage error occered, contact support.", innerException)
    { }
}