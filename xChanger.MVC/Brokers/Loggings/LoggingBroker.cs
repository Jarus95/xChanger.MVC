//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Microsoft.Extensions.Logging;
using System;

namespace xChanger.MVC.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> logger;
        public LoggingBroker(ILogger<LoggingBroker> logger)
        {
            this.logger = logger;
        }
        public void LogError(Exception exception)
        {
            this.logger.LogError(exception.Message,exception);
        }
    }
}
