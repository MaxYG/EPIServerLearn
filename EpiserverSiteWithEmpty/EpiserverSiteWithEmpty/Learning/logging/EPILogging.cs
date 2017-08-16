

using System;
using log4net;

namespace EpiserverSiteWithEmpty.Learning.logging
{
    public class EpiLogging
    {
        private static readonly ILog Logger = LogManager.GetLogger("CustomLogAppender");

        public static void LoggingMessage(string message)
        {
            Logger.Info("episerver Log message:" + message);
        }
    }
}