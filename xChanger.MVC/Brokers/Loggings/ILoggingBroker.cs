//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;

namespace xChanger.MVC.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        public void LogError(Exception exception);
    }
}