﻿using System;
using Newtonsoft.Json;

namespace GoManCaptcha
{
    class VersionModel
    {
        [JsonIgnore]
        public static readonly string CurrentVersion = "1.7";
        [JsonIgnore]
        public static readonly string SavePath = "./Plugins/GoMan-Pokemon-GoManager-Plugin.dll";
        [JsonIgnore]
        public static readonly Uri Uri = new Uri("http://bit.ly/2k4Kl51");
        public string Version { get; set; }
        public string UpdateUrl { get; set; }
    }
}
