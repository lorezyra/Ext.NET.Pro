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
    public partial class AjaxProxy
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
                
                list.Add("type", new ConfigOption("type", null, null, this.Type ));
                list.Add("headers", new ConfigOption("headers", new SerializationOptions(JsonMode.ArrayToObject), null, this.Headers ));
                list.Add("json", new ConfigOption("json", null, false, this.Json ));
                list.Add("xml", new ConfigOption("xml", null, false, this.Xml ));
                list.Add("actionMethodsProxy", new ConfigOption("actionMethodsProxy", new SerializationOptions("actionMethods", JsonMode.Raw), "", this.ActionMethodsProxy ));
                list.Add("getMethod", new ConfigOption("getMethod", new SerializationOptions(JsonMode.Raw), null, this.GetMethod ));

                return list;
            }
        }
    }
}