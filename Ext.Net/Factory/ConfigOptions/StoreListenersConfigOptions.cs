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
    public partial class StoreListeners
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
                
                list.Add("beforePrefetch", new ConfigOption("beforePrefetch", new SerializationOptions("beforeprefetch", typeof(ListenerJsonConverter)), null, this.BeforePrefetch ));
                list.Add("groupChange", new ConfigOption("groupChange", new SerializationOptions("groupchange", typeof(ListenerJsonConverter)), null, this.GroupChange ));
                list.Add("prefetch", new ConfigOption("prefetch", new SerializationOptions("prefetch", typeof(ListenerJsonConverter)), null, this.Prefetch ));
                list.Add("totalCountChange", new ConfigOption("totalCountChange", new SerializationOptions("totalcountchange", typeof(ListenerJsonConverter)), null, this.TotalCountChange ));

                return list;
            }
        }
    }
}