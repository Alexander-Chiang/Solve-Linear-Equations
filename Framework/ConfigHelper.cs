using System;

namespace Framework
{
    /// <summary>
    /// 配置Helper 
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 默认构造
        /// </summary>
        private ConfigHelper() { }

        /// <summary>
        /// 获取App.config的appSettings配置节
        /// </summary>
        /// <param name="configName">key</param>
        /// <returns>value</returns>
        public static string GetConfig(string configName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[configName];
        }

        /// <summary>
        /// 为了CureSuitServiceStub.dll的使用新增
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConifg(string configName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[configName];
        }

        /// <summary>
        /// 获取App.config的appSettings配置节
        /// </summary>
        /// <param name="configName">key</param>
        /// <returns>value</returns>
        public static string GetPrefix(string configName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[configName];
        }
    }
}