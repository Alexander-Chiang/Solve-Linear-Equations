using System;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Framework
{
    public class Logger
    {

        /// <summary>
        /// 客户端错误提交回服务器级别，此级别以上（包含此级别）的事件才会提交回服务器。常用级别由低到高：All->Debug->Info->Warn->Error->Off
        /// </summary>
        public static log4net.Core.Level ClientErrorSendBackLevel = log4net.Core.Level.Off;

        static Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// 记录Debug消息
        /// </summary>
        /// <param name="strMessage"></param>
        public static void Debug(string strMessage)
        {
            ILog logger = LogManager.GetLogger(string.Empty);
            if (logger != null && logger.IsDebugEnabled)
            {
                logger.Debug(strMessage);
            }
        }

        /// <summary>
        /// 记录Info消息
        /// </summary>
        /// <param name="strMessage"></param>
        public static void Info(string strMessage)
        {
            ILog logger = LogManager.GetLogger(string.Empty);
            if (logger != null && logger.IsInfoEnabled)
            {
                logger.Info(strMessage);
            }
        }

        /// <summary>
        /// 记录Warn消息
        /// </summary>
        /// <param name="strMessage"></param>
        public static void Warn(string strMessage)
        {
            ILog logger = LogManager.GetLogger(string.Empty);
            if (logger != null && logger.IsWarnEnabled)
            {
                logger.Warn(strMessage);
            }
        }

        /// <summary>
        /// 记录Error消息
        /// </summary>
        /// <param name="strMessage"></param>
        public static void Error(string strMessage)
        {
            ILog logger = LogManager.GetLogger(string.Empty);
            if (logger != null && logger.IsErrorEnabled)
            {
                logger.Error(strMessage);
            }
        }

        /// <summary>
        /// 记录Error消息
        /// </summary>
        /// <param name="ex"></param>
        public static void Error(Exception ex)
        {
            Error(ex.ToString());
        }
    }
}
