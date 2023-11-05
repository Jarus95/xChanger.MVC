//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using Xeptions;

namespace Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions;

public class AlreadyExistsSpreadSheetException : Xeption
{
    public AlreadyExistsSpreadSheetException(Exception innerException)
         : base(message: "Spread sheet already exists", innerException)
    { }
}
