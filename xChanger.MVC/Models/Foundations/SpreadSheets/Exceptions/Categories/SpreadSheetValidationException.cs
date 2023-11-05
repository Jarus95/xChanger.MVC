//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Foundations.SpreadSheets.Exceptions.Categories;

public class SpreadSheetValidationException : Xeption
{
    public SpreadSheetValidationException(Xeption innerException)
         : base("Spreadsheet validation error occured. Fix the errors and try again", innerException)
    { }
}
