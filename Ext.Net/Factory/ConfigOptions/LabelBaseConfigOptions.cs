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
    public abstract partial class LabelBase
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
                
                list.Add("format", new ConfigOption("format", null, "", this.Format ));
                list.Add("emptyText", new ConfigOption("emptyText", null, "", this.EmptyText ));
                list.Add("forID", new ConfigOption("forID", new SerializationOptions("forId"), "", this.ForID ));
                list.Add("html", new ConfigOption("html", null, "", this.Html ));
                list.Add("textProxy", new ConfigOption("textProxy", new SerializationOptions("text"), "", this.TextProxy ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));
                list.Add("iconAlign", new ConfigOption("iconAlign", new SerializationOptions(JsonMode.ToLower), Alignment.Left, this.IconAlign ));
                list.Add("editor", new ConfigOption("editor", new SerializationOptions("editor", typeof(SingleItemCollectionJsonConverter)), null, this.Editor ));

                return list;
            }
        }
    }
}