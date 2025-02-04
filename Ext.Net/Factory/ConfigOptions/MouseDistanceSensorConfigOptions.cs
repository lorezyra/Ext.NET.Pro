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
    public partial class MouseDistanceSensor
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
                
                list.Add("threshold", new ConfigOption("threshold", null, 100, this.Threshold ));
                list.Add("opacity", new ConfigOption("opacity", null, true, this.Opacity ));
                list.Add("minOpacity", new ConfigOption("minOpacity", null, 0, this.MinOpacity ));
                list.Add("maxOpacity", new ConfigOption("maxOpacity", null, 1, this.MaxOpacity ));
                list.Add("sensorElementProxy", new ConfigOption("sensorElementProxy", new SerializationOptions("getSensorEls", JsonMode.Raw), "", this.SensorElementProxy ));
                list.Add("constrainElementProxy", new ConfigOption("constrainElementProxy", new SerializationOptions("getConstrainEls", JsonMode.Raw), "", this.ConstrainElementProxy ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}