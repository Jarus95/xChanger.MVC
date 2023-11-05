//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;

namespace xChanger.MVC.Brokers.DateTimes
{
    public interface IDateTimeBroker
    {
        DateTimeOffset GetCurrentDateTime();
    }
}
