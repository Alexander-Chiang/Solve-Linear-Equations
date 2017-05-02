using System;

namespace Framework
{
    /// <summary>
    /// ����Helper 
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// Ĭ�Ϲ���
        /// </summary>
        private ConfigHelper() { }

        /// <summary>
        /// ��ȡApp.config��appSettings���ý�
        /// </summary>
        /// <param name="configName">key</param>
        /// <returns>value</returns>
        public static string GetConfig(string configName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[configName];
        }

        /// <summary>
        /// Ϊ��CureSuitServiceStub.dll��ʹ������
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConifg(string configName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[configName];
        }

        /// <summary>
        /// ��ȡApp.config��appSettings���ý�
        /// </summary>
        /// <param name="configName">key</param>
        /// <returns>value</returns>
        public static string GetPrefix(string configName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[configName];
        }
    }
}