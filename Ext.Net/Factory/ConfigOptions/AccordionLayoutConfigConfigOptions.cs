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
    public partial class AccordionLayoutConfig
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
                
                list.Add("layoutType", new ConfigOption("layoutType", new SerializationOptions("type"), "", this.LayoutType ));
                list.Add("activeOnTop", new ConfigOption("activeOnTop", null, false, this.ActiveOnTop ));
                list.Add("animate", new ConfigOption("animate", null, true, this.Animate ));
                list.Add("originalHeader", new ConfigOption("originalHeader", null, false, this.OriginalHeader ));
                list.Add("collapseFirst", new ConfigOption("collapseFirst", null, false, this.CollapseFirst ));
                list.Add("fill", new ConfigOption("fill", null, true, this.Fill ));
                list.Add("hideCollapseTool", new ConfigOption("hideCollapseTool", null, false, this.HideCollapseTool ));
                list.Add("multi", new ConfigOption("multi", null, false, this.Multi ));
                list.Add("titleCollapse", new ConfigOption("titleCollapse", null, true, this.TitleCollapse ));

                return list;
            }
        }
    }
}