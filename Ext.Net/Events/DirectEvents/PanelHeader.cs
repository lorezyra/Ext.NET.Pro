/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class PanelHeaderDirectEvents : ContainerDirectEvents
    {
        public PanelHeaderDirectEvents() { }

        public PanelHeaderDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent click;

        /// <summary>
        /// Fires when the header is clicked. This event will not be fired if the click was on a Ext.panel.Tool
        /// Parameters
        /// item : Ext.panel.Header
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the header is clicked. This event will not be fired if the click was on a Ext.panel.Tool")]
        public virtual ComponentDirectEvent Click
        {
            get
            {
                return this.click ?? (this.click = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent dblclick;

        /// <summary>
        /// Fires when the header is double clicked. This event will not be fired if the click was on a Ext.panel.Tool
        /// Parameters
        /// item : Ext.panel.Header
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the header is double clicked. This event will not be fired if the click was on a Ext.panel.Tool")]
        public virtual ComponentDirectEvent DblClick
        {
            get
            {
                return this.dblclick ?? (this.dblclick = new ComponentDirectEvent(this));
            }
        }
    }
}