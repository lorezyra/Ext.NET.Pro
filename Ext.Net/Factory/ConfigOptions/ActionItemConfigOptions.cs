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
    public partial class ActionItem
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
                
                list.Add("iconProxy", new ConfigOption("iconProxy", new SerializationOptions("iconCls", JsonMode.Raw), "", this.IconProxy ));
                list.Add("iconCls", new ConfigOption("iconCls", null, "", this.IconCls ));
                list.Add("iconUrlProxy", new ConfigOption("iconUrlProxy", new SerializationOptions("icon"), "", this.IconUrlProxy ));
                list.Add("getClass", new ConfigOption("getClass", new SerializationOptions(JsonMode.Raw), null, this.GetClass ));
                list.Add("getTip", new ConfigOption("getTip", new SerializationOptions(JsonMode.Raw), null, this.GetTip ));
                list.Add("isDisabled", new ConfigOption("isDisabled", new SerializationOptions(JsonMode.Raw), null, this.IsDisabled ));
                list.Add("handler", new ConfigOption("handler", new SerializationOptions(typeof(FunctionJsonConverter)), "", this.Handler ));
                list.Add("scope", new ConfigOption("scope", new SerializationOptions(JsonMode.Raw), null, this.Scope ));
                list.Add("tooltip", new ConfigOption("tooltip", null, null, this.Tooltip ));
                list.Add("disabled", new ConfigOption("disabled", null, false, this.Disabled ));

                return list;
            }
        }
    }
}