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
    public partial class ResizableDirectEvents : ComponentDirectEvents
    {
        public ResizableDirectEvents() { }

        public ResizableDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeResize;

        /// <summary>
        /// Fired before resize is allowed. Set enabled to false to cancel resize.
        /// Parameters
        /// item : Ext.resizer.Resizer
        /// width : Number
        ///     The start width
        /// height : Number
        ///     The start height
        /// e : Ext.EventObject
        ///     The mousedown event
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "width")]
        [ListenerArgument(2, "height")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeresize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired before resize is allowed. Set enabled to false to cancel resize.")]
        public virtual ComponentDirectEvent BeforeResize
        {
            get
            {
                return this.beforeResize ?? (this.beforeResize = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent resize;

        /// <summary>
        /// Fired after a resize.
        /// Parameters
        /// item : Ext.resizer.Resizer
        /// width : Number
        ///     The new width
        /// height : Number
        ///     The new height
        /// e : Ext.EventObject
        ///     The mouseup event
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "width")]
        [ListenerArgument(2, "height")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("resize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a resize.")]
        public virtual ComponentDirectEvent Resize
        {
            get
            {
                return this.resize ?? (this.resize = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent resizedrag;

        /// <summary>
        /// Fires during resizing. Return false to cancel resize.
        /// Parameters
        /// item : Ext.resizer.Resizer
        /// width : Number
        ///     The new width
        /// height : Number
        ///     The new height
        /// e : Ext.EventObject
        ///     The mousedown event
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "width")]
        [ListenerArgument(2, "height")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("resizedrag", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires during resizing. Return false to cancel resize.")]
        public virtual ComponentDirectEvent ResizeDrag
        {
            get
            {
                return this.resizedrag ?? (this.resizedrag = new ComponentDirectEvent(this));
            }
        }
    }
}