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
    public partial class GroupTabPanelListeners
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
                
                list.Add("beforeGroupChange", new ConfigOption("beforeGroupChange", new SerializationOptions("beforegroupchange", typeof(ListenerJsonConverter)), null, this.BeforeGroupChange ));
                list.Add("groupChange", new ConfigOption("groupChange", new SerializationOptions("groupchange", typeof(ListenerJsonConverter)), null, this.GroupChange ));
                list.Add("beforeTabChange", new ConfigOption("beforeTabChange", new SerializationOptions("beforetabchange", typeof(ListenerJsonConverter)), null, this.BeforeTabChange ));
                list.Add("tabChange", new ConfigOption("tabChange", new SerializationOptions("tabchange", typeof(ListenerJsonConverter)), null, this.TabChange ));

                return list;
            }
        }
    }
}