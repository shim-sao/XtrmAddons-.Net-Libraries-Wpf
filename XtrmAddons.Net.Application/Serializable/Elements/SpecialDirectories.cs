﻿using System;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Specials Directories.
    /// </summary>
    public class SpecialDirectories
    {
        /// <summary>
        /// Property application cache directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Cache")]
        public string Cache;

        /// <summary>
        /// Property application config directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Config")]
        public string Config;

        /// <summary>
        /// Property application data directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Data")]
        public string Data;

        /// <summary>
        /// Property application logs directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Logs")]
        public string Logs;
    }


    /// <summary>
    /// Enumerator of application special directories.
    /// </summary>
    [Serializable]
    public enum SpecialDirectoriesName
    {
        /// <summary>
        /// Application cache special directory.
        /// </summary>
        [XmlEnum(Name = "Cache")]
        Cache,

        /// <summary>
        /// Application config special directory.
        /// </summary>
        [XmlEnum(Name = "Config")]
        Config,

        /// <summary>
        /// Application data special directory.
        /// </summary>
        [XmlEnum(Name = "Data")]
        Data,

        /// <summary>
        /// Application logs special directory.
        /// </summary>
        [XmlEnum(Name = "Logs")]
        Logs
    }


    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Specials Directories Extensions.
    /// </summary>
    public static class SpecialDirectoriesExtensions
    {
        /// <summary>
        /// Method to get Special Directories Enumerator to root directory string.
        /// </summary>
        /// <param name="sdn">A Special Directories Name.</param>
        /// <returns>The root directory Special Directories Name.</returns>
        public static string RootDirectory(this SpecialDirectoriesName sdn)
        {
            switch(sdn)
            {
                case SpecialDirectoriesName.Cache:
                    return "{Cache}";
                    
                case SpecialDirectoriesName.Config:
                    return "{Config}";

                case SpecialDirectoriesName.Data:
                    return "{Data}";

                case SpecialDirectoriesName.Logs:
                    return "{Logs}";
            }

            return null;
        }
    }
}