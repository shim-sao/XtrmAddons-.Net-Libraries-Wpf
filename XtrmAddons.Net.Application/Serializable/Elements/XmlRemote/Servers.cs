﻿using Newtonsoft.Json;
using System.Collections.Generic;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlRemote
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Servers List.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Servers : ElementsBase<Server>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Servers List Constructor.
        /// </summary>
        public Servers() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Servers List Constructor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the list.</param>
        public Servers(int capacity) : base(capacity) { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Servers List Constructor.
        /// </summary>
        /// <param name="collection">Collection whose items are copied to the new list.</param>
        public Servers(IEnumerable<Server> collection) : base(collection) { }

        #endregion
    }
}
