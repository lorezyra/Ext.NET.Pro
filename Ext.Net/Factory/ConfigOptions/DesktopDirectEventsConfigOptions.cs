/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DesktopDirectEvents
    {
        /// <summary>
        /// 
        /// </summary>
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("shortcutMove", new ConfigOption("shortcutMove", new SerializationOptions("shortcutmove", typeof(DirectEventJsonConverter)), null, this.ShortcutMove ));
                list.Add("shortcutNameEdit", new ConfigOption("shortcutNameEdit", new SerializationOptions("shortcutnameedit", typeof(DirectEventJsonConverter)), null, this.ShortcutNameEdit ));
                list.Add("ready", new ConfigOption("ready", new SerializationOptions("ready", typeof(DirectEventJsonConverter)), null, this.Ready ));
                list.Add("beforeUnload", new ConfigOption("beforeUnload", new SerializationOptions("beforeunload", typeof(DirectEventJsonConverter)), null, this.BeforeUnload ));

                return list;
            }
        }
    }
}