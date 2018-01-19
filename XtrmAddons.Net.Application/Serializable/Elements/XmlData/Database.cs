﻿using System;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlData
{
    /// <summary>
    /// <para>Class XtrmAddons Net Application Serializable Elements XML Database Informations.</para>
    /// <para>Allows you to set database connection parameters</para>
    /// </summary>
    [Serializable]
    public class Database : ElementBase
    {
        #region Properties

        /// <summary>
        /// Property name of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Property type of database.
        /// </summary>
        [XmlAttribute(AttributeName = "Type")]
        public DatabaseType Type { get; set; }

        /// <summary>
        /// Property source of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Source")]
        public string Source { get; set; }

        /// <summary>
        /// Property connexion host name of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Host")]
        public string Host { get; set; }

        /// <summary>
        /// Property connexion port of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Port")]
        public string Port { get; set; }

        /// <summary>
        /// Property connexion user name or login of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Property connexion password of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Property comment on the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Comment")]
        public string Comment { get; set; }

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Database constructor.
        /// </summary>
        public Database() : base() { }

        #endregion
    }



    /// <summary>
    /// Enumerator XtrmAddons Net Application Serializable Elements XML Database Types.
    /// </summary>
    [Serializable]
    public enum DatabaseType
    {
        /// <summary>
        /// Database type for SQLite database. 
        /// </summary>
        [XmlEnum(Name = "SQLite")]
        SQLite = 0,

        /// <summary>
        /// Database type for MySQL database. 
        /// </summary>
        [XmlEnum(Name = "MySQL")]
        MySQL = 1
    }



    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Enumerator XML Database Types Extensions.
    /// </summary>
    public static class DatabaseTypeExtensions
    {
        /// <summary>
        /// Method to get string name of a database type.
        /// </summary>
        /// <param name="dbtype">The database type.</param>
        /// <returns>The string name of the database type otherwise return null.</returns>
        public static string Name(this DatabaseType dbtype)
        {
            switch (dbtype)
            {
                case DatabaseType.SQLite:
                    return "SQLite";
                case DatabaseType.MySQL:
                    return "MySQL";
            }

            return null;
        }

        /// <summary>
        /// Method to get int value of a database type.
        /// </summary>
        /// <param name="dbtype">The database type.</param>
        /// <returns>The int value of the database type otherwise return -1.</returns>
        public static int Value(this DatabaseType dbtype)
        {
            switch (dbtype)
            {
                case DatabaseType.SQLite:
                    return 0;
                case DatabaseType.MySQL:
                    return 1;
            }

            return -1;
        }
    }
}