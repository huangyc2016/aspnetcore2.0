using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HYC.WebApi.JsonConfig
{
    public class Configuration
    {
        private static Configuration _config;
        private static IConfigurationRoot _configuration { get; set; }
        public static Configuration Default
        {
            get
            {
                if (_configuration == null)
                {
                    var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    _configuration = configBuilder.Build();
                }
                if (_config == null)
                {
                    _config = new Configuration();
                }
                return _config;
            }
        }

        /// <summary>
        /// 运行环境,控制api文档是否显示Product-生产环境，空为测试环境或者开发环境
        /// </summary>
        /// <returns></returns>
        public string RunEnvironment
        {
            get
            {
                return _configuration["RunEnvironment"];
            }
        }
    }
}
