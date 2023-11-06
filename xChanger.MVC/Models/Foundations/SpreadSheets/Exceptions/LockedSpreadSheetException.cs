//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace xChanger.MVC.Models.Foundations.SpreadSheets.Exceptions;

public class LockedSpreadSheetException : Xeption
{
    public LockedSpreadSheetException(Exception innerException)
        : base(message: "Spread sheer is locked. try again later.", innerException)
    { }
}