using System;
using Newtonsoft.Json;

namespace Goman_Plugin.Model
{
    class VersionModel
    {
        [JsonIgnore]
        public static readonly string CurrentVersion = "5.6";
        [JsonIgnore]
        public static readonly string SavePath = "./Plugins/GoMan-Plugin.dll";
        [JsonIgnore]
        public static readonly Uri Uri = new Uri("http://bit.ly/2k4Kl51");
        public string Version { get; set; }
        public string UpdateUrl { get; set; }
    }
}