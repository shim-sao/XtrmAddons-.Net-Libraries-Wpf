﻿using System;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Transactions;
using XtrmAddons.Net.Application.Tools;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.SQLiteBundle
{
    /// <summary>
    /// Class XtrmAddons Net SQLite Bundle using System.Data.SQLite.
    /// </summary>
    public class WpfSQLiteData : IDisposable
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Variable database filename.
        /// </summary>
        private string database;

        #endregion



        #region Properties

        /// <summary>
        /// Variable SQLite database connection.
        /// </summary>
        public SQLiteConnection Db { get; private set; }

        #endregion



        #region Methods

        /// <summary>
        /// XtrmAddons Common WPF SQLite Data constructor.
        /// </summary>
        public WpfSQLiteData() { }

        /// <summary>
        /// XtrmAddons Common WPF SQLite Data constructor.
        /// </summary>
        /// <param name="database">The database file name.</param>
        /// <param name="createFile">Create file if not exists ?</param>
        /// <param name="scheme">The path to the database scheme.</param>
        public WpfSQLiteData(string database, bool createFile = false, string scheme = "")
        {
            this.database = database;
            CreateConnection(database, createFile, scheme);
        }

        /// <summary>
        /// Method to create and to connect to a SQLite database.
        /// </summary>
        /// <param name="database">The database file name (full path to the file).</param>
        /// <param name="createFile">Create file if not exists ?</param>
        /// <param name="scheme">The path to the database scheme.</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public void CreateConnection(string database, bool createFile = false, string scheme = "")
        {
            log.Info("WPFSQLiteData Connecting to database : Data Source=" + database + ";Version=3;");

            try
            {
                if (createFile)
                {
                    CreateFile(database);
                }

                log.Debug("WPFSQLiteData Connecting : Data Source=" + database + ";Version=3;");

                Db = new SQLiteConnection("Data Source=" + database + ";Version=3;");
                Db.Open();

                if (createFile)
                {
                    CreateDatabase(scheme);
                    InitializeSetting();
                }
            }

            catch (FileNotFoundException e)
            {
                string message = string.Format(CultureInfo.InvariantCulture, "Failed to connect to the database : {0}", database);
                log.Fatal(string.Format(message));
                throw new FileNotFoundException(message, e);
            }

            catch (SQLiteException e)
            {
                string message = string.Format(CultureInfo.InvariantCulture, "Failed to connect to the database : {0}", database);
                log.Fatal(string.Format(message));
                throw new SQLiteException(message, e);
            }
        }

        /// <summary>
        /// Method to create a database file.
        /// </summary>
        /// <param name="filename">A database file name (full path).</param>
        public static void CreateFile(string filename)
        {
            SQLiteConnection.CreateFile(filename);
            ApplicationTools.GrantAccess(filename);
        }

        /// <summary>
        /// Method to create a new database base on a file of scheme.
        /// </summary>
        /// <param name="scheme">An application relative path to the database scheme to create.</param>
        /// <exception cref="SQLiteException"></exception>
        /// <exception cref="Exception"></exception>
        protected void CreateDatabase(string scheme)
        {
            log.Info(string.Format(CultureInfo.InvariantCulture, "Creating Database scheme : {0}", scheme));

            string query = "";
            string path = Path.Combine(Environment.CurrentDirectory, scheme);

            try
            {
                query = File.ReadAllText(path);
            }
            catch(Exception e)
            {
                string message = string.Format(CultureInfo.InvariantCulture, "Database file scheme not found : {0}", scheme);
                log.Error(message);
                throw new FileNotFoundException(message, e);
            }

            try
            { 
                // Create sheme with transaction for big query.
                using (TransactionScope tran = new TransactionScope())
                {
                    SQLiteCommand command = Db.CreateCommand();

                    // Not supported by DLL
                    //command.Parameters.Add("@Text", DbType.String).Value = query;
                    //command.CommandText = "@Text";

                    command.CommandText = @query;
                    command.ExecuteNonQuery();
                }
            }
            catch (SQLiteException e)
            {
                string message = string.Format(CultureInfo.InvariantCulture, "Failed to create database scheme : {0}", scheme);
                log.Error(message);
                throw new SQLiteException(message, e);
            }

            log.Info("Creating Database scheme done.");
        }

        /// <summary>
        /// Method to initialize database data.
        /// </summary>
        protected void InitializeSetting() { }
        
        #endregion



        #region IDisposable Support
        /// <summary>
        /// Variable to detect recursive call.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Method to dispose object and its managed dependencies.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Db.Close();
                    Db.Dispose();
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~WPFSQLiteData() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        /// <summary>
        /// <para>Method to dispose object and its managed dependencies.</para>
        /// <para>This code is added to correctly implement the deleteable template.</para>
        /// </summary>
        public void Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            // TODO: supprimer les marques de commentaire pour la ligne suivante si le finaliseur est remplacé ci-dessus.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}