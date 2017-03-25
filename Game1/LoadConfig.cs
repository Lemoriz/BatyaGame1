using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;


namespace Game1
{
    /// <summary>
    /// Stores a configuration for game
    /// </summary>
    class LoadConfig
    {
        public int ScreenW { get; }
        public int ScreenH { get; }
        public bool IsServer { get; }

        public bool FullScreen { get; }

        /// <summary>
        /// Load a configuration file from App.config
        /// </summary>
        public LoadConfig()
        {
            
            ScreenW = Convert.ToInt32(ConfigurationManager.AppSettings["width"]);
            ScreenH = Convert.ToInt32(ConfigurationManager.AppSettings["height"]);
            IsServer = Convert.ToBoolean(ConfigurationManager.AppSettings["server"]);
            FullScreen = Convert.ToBoolean(ConfigurationManager.AppSettings["fullscreen"]);


        }

    }
}
