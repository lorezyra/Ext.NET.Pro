/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;
using Ext.Net;
using System;

namespace Ext.Net
{
    public partial class MonthViewDirectEvents : AbstractCalendarViewDirectEvents
    {
        public MonthViewDirectEvents() { }

        public MonthViewDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent dayClick;

        /// <summary>
        /// Fires after the user clicks within the view container and not on an event element. This is a cancelable event, so returning false from a handler will cancel the click without displaying the event editor view. This could be useful for validating that a user can only create events on certain days.
        /// Listeners will be called with the following arguments:
        /// this : Extensible.calendar.view.Month
        /// dt : Date
        /// The date/time that was clicked on
        /// allday : Boolean
        /// True if the day clicked on represents an all-day box, else false. Clicks within the MonthView always return true for this param.
        /// el : Ext.Element
        /// The Element that was clicked on
        /// </summary>
        [ListenerArgument(0, "item", typeof(MonthView), "Ext.calendar.MonthView")]
        [ListenerArgument(1, "dt", typeof(DateTime), "The date/time that was clicked on")]
        [ListenerArgument(2, "allDay", typeof(bool), "True if the day clicked on represents an all-day box, else false. Clicks within the MonthView always return true for this param.")]
        [ListenerArgument(3, "el", typeof(Element), "The Element that was clicked on")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dayclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the user clicks within the view container and not on an event element. This is a cancelable event, so returning false from a handler will cancel the click without displaying the event editor view. This could be useful for validating that a user can only create events on certain days.")]
        public virtual ComponentDirectEvent DayClick
        {
            get
            {
                if (this.dayClick == null)
                {
                    this.dayClick = new ComponentDirectEvent(this);
                }

                return this.dayClick;
            }
        }

        private ComponentDirectEvent weekClick;

        /// <summary>
        /// Fires after the user clicks within a week link (when #showWeekLinks is true)
        /// Listeners will be called with the following arguments:
        /// this : Extensible.calendar.view.Month
        /// dt : Date
        /// The start date of the week that was clicked on
        /// </summary>
        [ListenerArgument(0, "item", typeof(MonthView), "Ext.calendar.MonthView")]
        [ListenerArgument(1, "dt", typeof(DateTime), "The start date of the week that was clicked on")]        
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("weekclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the user clicks within a week link (when #showWeekLinks is true)")]
        public virtual ComponentDirectEvent WeekClick
        {
            get
            {
                if (this.weekClick == null)
                {
                    this.weekClick = new ComponentDirectEvent(this);
                }

                return this.weekClick;
            }
        }
    }
}