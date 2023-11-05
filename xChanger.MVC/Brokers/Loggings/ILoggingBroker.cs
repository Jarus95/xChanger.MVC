//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;

namespace Tarteeb.XChanger.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        public void LogError(Exception exception);
    }
}