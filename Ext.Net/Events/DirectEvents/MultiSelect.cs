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
    public partial class MultiSelectDirectEvents : FieldDirectEvents
    {
        public MultiSelectDirectEvents() { }

        public MultiSelectDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent click;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(MultiSelect), "this")]
        [ListenerArgument(1, "e", typeof(object), "The click event")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent Click
        {
            get
            {
                if (this.click == null)
                {
                    this.click = new ComponentDirectEvent(this);
                }

                return this.click;
            }
        }

        private ComponentDirectEvent dblClick;

        /// <summary>
        /// Fires when a template node is double clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(MultiSelect), "this")]
        [ListenerArgument(1, "index", typeof(object))]
        [ListenerArgument(2, "node", typeof(object))]
        [ListenerArgument(3, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a template node is double clicked.")]
        public virtual ComponentDirectEvent DblClick
        {
            get
            {
                if (this.dblClick == null)
                {
                    this.dblClick = new ComponentDirectEvent(this);
                }

                return this.dblClick;
            }
        }

        private ComponentDirectEvent beforeDrop;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "view", typeof(object))]
        [ListenerArgument(1, "node", typeof(object))]
        [ListenerArgument(2, "dd", typeof(object))]
        [ListenerArgument(3, "e", typeof(object))]
        [ListenerArgument(4, "data", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforedrop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeDrop
        {
            get
            {
                if (this.beforeDrop == null)
                {
                    this.beforeDrop = new ComponentDirectEvent(this);
                }

                return this.beforeDrop;
            }
        }

        private ComponentDirectEvent drop;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(object))]
        [ListenerArgument(1, "records", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("drop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent Drop
        {
            get
            {
                if (this.drop == null)
                {
                    this.drop = new ComponentDirectEvent(this);
                }

                return this.drop;
            }
        }
    }
}