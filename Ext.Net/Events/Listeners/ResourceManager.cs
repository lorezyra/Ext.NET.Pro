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
    public partial class ResourceManagerListeners : ComponentListeners
    {
        private ComponentListener documentReady;

        /// <summary>
        /// Fires when the document is ready (before onload and before images are loaded). Can be accessed shorthanded as Ext.onReady().
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the document is ready (before onload and before images are loaded). Can be accessed shorthanded as Ext.onReady().")]
        public virtual ComponentListener DocumentReady
        {
            get
            {
                if (this.documentReady == null)
                {
                    this.documentReady = new ComponentListener();
                }

                return this.documentReady;
            }
        }

        private ComponentListener windowResize;

        /// <summary>
        /// Fires when the window is resized and provides resize event buffering (50 milliseconds), passes new viewport width and height to handlers.
        /// </summary>
        [ListenerArgument(0, "width", typeof(int), "New viewport width")]
        [ListenerArgument(1, "height", typeof(int), "New viewport height")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the window is resized and provides resize event buffering (50 milliseconds), passes new viewport width and height to handlers.")]
        public virtual ComponentListener WindowResize
        {
            get
            {
                if (this.windowResize == null)
                {
                    this.windowResize = new ComponentListener();
                }

                return this.windowResize;
            }
        }

        private ComponentListener windowUnload;

        /// <summary>
        /// Fires when the browser window is unloaded. Return 'true' to prompt the message, or 'false' to cancel the unload.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The browser unload event object")]
        [ConfigOption("beforeunload", typeof(ListenerJsonConverter))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the browser window is unloaded. Return 'true' to prompt the message, or 'false' to cancel the unload.")]
        public virtual ComponentListener WindowUnload
        {
            get
            {
                if (this.windowUnload == null)
                {
                    this.windowUnload = new ComponentListener();
                }

                return this.windowUnload;
            }
        }

        private ComponentListener windowScroll;

        /// <summary>
        /// Fires when the browser window is scrolled.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The browser scroll event object")]
        [ListenerArgument(1, "document", typeof(object), "The browser document object")]
        [ConfigOption("scroll", typeof(ListenerJsonConverter))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the browser window is scrolled.")]
        public virtual ComponentListener WindowScroll
        {
            get
            {
                if (this.windowScroll == null)
                {
                    this.windowScroll = new ComponentListener();
                }

                return this.windowScroll;
            }
        }

        private ComponentListener beforeAjaxRequest;

        /// <summary>
        /// Fires before each ajax request
        /// </summary>
        [ListenerArgument(0, "item", typeof(object), "The browser scroll event object")]
        [ListenerArgument(1, "eventType", typeof(object), "Event type")]
        [ListenerArgument(2, "action", typeof(object), "Type of action")]
        [ListenerArgument(3, "extraParams", typeof(object), "Extra parameters of request")]
        [ListenerArgument(4, "o", typeof(object), "")]
        [ConfigOption("beforeajaxrequest", typeof(ListenerJsonConverter))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before each ajax request.")]
        public virtual ComponentListener BeforeAjaxRequest
        {
            get
            {
                if (this.beforeAjaxRequest == null)
                {
                    this.beforeAjaxRequest = new ComponentListener();
                }

                return this.beforeAjaxRequest;
            }
        }

        private ComponentListener ajaxRequestComplete;

        /// <summary>
        /// Fires if the ajax request was successfully completed.
        /// </summary>
        [ListenerArgument(0, "response", typeof(object), "The reponse object")]
        [ListenerArgument(1, "result", typeof(object), "")]
        [ListenerArgument(2, "el", typeof(object), "The browser scroll event object")]
        [ListenerArgument(3, "eventType", typeof(object), "Event type")]
        [ListenerArgument(4, "action", typeof(object), "Type of action")]
        [ListenerArgument(5, "extraParams", typeof(object), "Extra parameters of request")]
        [ListenerArgument(6, "o", typeof(object), "")]
        [ConfigOption("ajaxrequestcomplete", typeof(ListenerJsonConverter))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires if the ajax request was successfully completed.")]
        public virtual ComponentListener AjaxRequestComplete
        {
            get
            {
                if (this.ajaxRequestComplete == null)
                {
                    this.ajaxRequestComplete = new ComponentListener();
                }

                return this.ajaxRequestComplete;
            }
        }

        private ComponentListener ajaxRequestException;

        /// <summary>
        /// Fires if the ajax request was failed.
        /// </summary>
        [ListenerArgument(0, "response", typeof(object), "The reponse object")]
        [ListenerArgument(1, "result", typeof(object), "")]
        [ListenerArgument(2, "el", typeof(object), "The browser scroll event object")]
        [ListenerArgument(3, "eventType", typeof(object), "Event type")]
        [ListenerArgument(4, "action", typeof(object), "Type of action")]
        [ListenerArgument(5, "extraParams", typeof(object), "Extra parameters of request")]
        [ListenerArgument(6, "o", typeof(object), "")]
        [ConfigOption("ajaxrequestexception", typeof(ListenerJsonConverter))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires if the ajax request was failed.")]
        public virtual ComponentListener AjaxRequestException
        {
            get
            {
                if (this.ajaxRequestException == null)
                {
                    this.ajaxRequestException = new ComponentListener();
                }

                return this.ajaxRequestException;
            }
        }
    }
}