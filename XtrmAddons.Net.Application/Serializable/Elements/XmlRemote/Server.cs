﻿using System;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlRemote
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Server Informations.
    /// </summary>
    [Serializable]
    public class Server : ServerInfo
    {
        #region Properties

        /// <summary>
        /// Property type of server.
        /// </summary>
        [XmlAttribute(AttributeName = "Type")]
        public ServerType Type { get; } = ServerType.Server;

        #endregion
    }



    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Enumerator XML Server Informations Types Extensions.
    /// </summary>
    public static class ServerExtensions
    {
        /// <summary>
        /// Method to get string name of a server informations type.
        /// </summary>
        /// <param name="type">The server informations type.</param>
        /// <returns>The string name of the server informations type otherwise return null.</returns>
        public static string Name(this ServerType type)
        {
            switch (type)
            {
                case ServerType.Server:
                    return "Server";
                case ServerType.Client:
                    return "Client";
            }

            return null;
        }

        /// <summary>
        /// Method to get int value of a server informations type.
        /// </summary>
        /// <param name="type">The server informations type.</param>
        /// <returns>The int value of the server informations type otherwise return -1.</returns>
        public static int Value(this ServerType type)
        {
            switch (type)
            {
                case ServerType.Server:
                    return 0;
                case ServerType.Client:
                    return 1;
            }

            return -1;
        }
    }
}