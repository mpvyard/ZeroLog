﻿namespace ZeroLog
{
    public partial class Log : ILog
    {
        private readonly IInternalLogManager _logManager;

        internal Log(IInternalLogManager logManager, string name)
        {
            _logManager = logManager;
            Name = name;
        }

        internal string Name { get; }

        public ILogEvent ForLevel(Level level)
        {
            return GetLogEventFor(level);
        }

        private IInternalLogEvent GetLogEventFor(Level level)
        {
            var logEvent = _logManager.AllocateLogEvent();
            logEvent.Initialize(level, this);
            return logEvent;
        }

        internal void Enqueue(IInternalLogEvent logEvent)
        {
            _logManager.Enqueue(logEvent);
        }
    }
}
