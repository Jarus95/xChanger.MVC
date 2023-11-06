//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Foundations.SpreadSheets.Exceptions;

public class InvalidSpreadSheetException : Xeption
{
    public InvalidSpreadSheetException()
        : base(message: "Spread sheer is invalid, Fix the errors and try again.")
    { }
}