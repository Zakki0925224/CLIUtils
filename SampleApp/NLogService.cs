using NLog;

namespace SampleApp
{
    public static class NLogService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void InfoLog(string str)
        {
            logger.Info(str);
        }
    }
}
