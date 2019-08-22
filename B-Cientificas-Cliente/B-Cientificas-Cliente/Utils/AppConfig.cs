﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace B_Cientificas_Cliente.Utils
{
    /// <summary>
    /// To get configuration from web config file
    /// </summary>
    public class AppConfig
    {
        public static string Get(string key)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                return ConfigurationManager.AppSettings[key];
            }
            else
            {
                 throw new Exception("Configuration Key not configured properly. Key Name: " + key);
            }
        }
    }
}