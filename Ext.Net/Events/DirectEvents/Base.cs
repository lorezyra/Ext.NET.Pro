/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class BaseDirectEvent : BaseListener
    {
        /// <summary>
        /// Only extra params will be added to request. Useful if request has web-service Url
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("Only extra params will be added to request. Useful if request has web-service Url")]
        public bool CleanRequest
        {
            get
            {
                bool defValue = this.ResourceManager != null ? this.Url.IsNotEmpty() : false;
                return this.State.Get<bool>("CleanRequest", defValue);
            }
            set
            {
                this.State.Set("CleanRequest", value);
            }
        }

        /// <summary>
        /// True to add a unique cache-buster param to GET requests.
        /// </summary>
        [DefaultValue(null)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True to add a unique cache-buster param to GET requests.")]
        public bool? DisableCaching
        {
            get
            {
                return this.State.Get<bool?>("DisableCaching", null);
            }
            set
            {
                this.State.Set("DisableCaching", value);
            }
        }

        /// <summary>
        /// Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc'
        /// </summary>
        [ConfigOption]
        [DefaultValue("_dc")]
        [NotifyParentProperty(true)]
        [Description("Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc'")]
        public string DisableCachingParam
        {
            get
            {
                return this.State.Get<string>("DisableCachingParam", "_dc");
            }
            set
            {
                this.State.Set("DisableCachingParam", value);
            }
        }

        /// <summary>
        /// True if the form object is a file upload
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True if the form object is a file upload")]
        public bool IsUpload
        {
            get
            {
                return this.State.Get<bool>("IsUpload", false);
            }
            set
            {
                this.State.Set("IsUpload", value);
            }
        }

        /// <summary>
        /// True to move the request parameters to jsonData that means JSON data to use as the post. This will be used instead of params for the post data. Any params will be appended to the URL. Defaults to false.
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True to move the request parameters to jsonData that means JSON data to use as the post. This will be used instead of params for the post data. Any params will be appended to the URL. Defaults to false.")]
        public bool Json
        {
            get
            {
                return this.State.Get<bool>("Json", false);
            }
            set
            {
                this.State.Set("Json", value);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(ViewStateMode.Inherit)]
        [NotifyParentProperty(true)]
        [Description("")]
        public ViewStateMode ViewStateMode
        {
            get
            {
                object obj = this.ViewState["ViewStateMode"];

                if (obj == null || ((ViewStateMode)obj) == ViewStateMode.Inherit)
                {
                    if (HttpContext.Current != null)
                    {
                        ResourceManager sm = ResourceManager.GetInstance(HttpContext.Current);

                        if (sm == null)
                        {
                            return ViewStateMode.Inherit;
                        }
                        return sm.AjaxViewStateMode;
                    }
                    return ViewStateMode.Inherit;
                }
                else
                {
                    return (ViewStateMode)obj;    
                }
            }
            set
            {
                this.State.Set("ViewStateMode", value);
            }
        }

        /// <summary>
        /// The type of DirectEvent to perform. The 'Submit' type will submit the &lt;form> and 'Load' will make a POST request to url set in the .Url property, or the current url if the .Url property has not been set.
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(DirectEventType.Submit)]
        [NotifyParentProperty(true)]
        [Description("The type of DirectEvent to perform. The 'Submit' type will submit the &lt;form> and 'Load' will make a POST request to url set in the .Url property, or the current url if the .Url property has not been set.")]
        public virtual DirectEventType Type
        {
            get
            {
                return this.State.Get<DirectEventType>("Type", DirectEventType.Submit);
            }
            set
            {
                this.State.Set("Type", value);
            }
        }

        /// <summary>
        /// The id of the form to submit. If this.ParentForm is not null then this.ParentForm.ClientID is used, else if FormID is empty the Page.Form.ClientID is used, else try to find the form in dom tree hierarchy, otherwise the Url of current page is used.
        /// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("The id of the form to submit. If this.ParentForm is not null then this.ParentForm.ClientID is used, else if FormID is empty the Page.Form.ClientID is used, else try to find the form in dom tree hierarchy, otherwise the Url of current page is used.")]
        public string FormID
        {
            get
            {
                return this.State.Get<string>("FormID", "");
            }
            set
            {
                this.State.Set("FormID", value);
            }
        }

        /// <summary>
        /// The default URL to be used for requests to the server. (defaults to '')
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The default URL to be used for requests to the server if DirectEventType.Request. (defaults to '')")]
        public virtual string Url
        {
            get
            {
                return this.State.Get<string>("Url", "");
            }
            set
            {
                this.State.Set("Url", value);
            }
        }

        /// <summary>
        /// The default URL to be used for requests to the server if DirectEventType.Request. (defaults to '')
        /// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [ConfigOption("url")]
        [Description("The default URL to be used for requests to the server if DirectEventType.Request. (defaults to '')")]
        protected virtual string UrlProxy
        {
            get
            {
                if (this.Url.IsEmpty())
                {
                    return "";
                }

                Control c = this.Owner;

                if (c == null)
                {
                    c = this.ResourceManager;
                }

                if (c is BaseControl)
                {
                    return ((BaseControl)c).ResolveUrlLink(this.Url);
                }

                return c != null ? c.ResolveUrl(this.Url) : this.Url;
            }
        }

        /// <summary>
        /// The HTTP method to use. Defaults to POST if params are present, or GET if not.
        /// </summary>
        [ConfigOption("method")]
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("The HTTP method to use. Defaults to POST if params are present, or GET if not.")]
        public virtual HttpMethod Method
        {
            get
            {
                return this.State.Get<HttpMethod>("Method", HttpMethod.Default);
            }
            set
            {
                this.State.Set("Method", value);
            }
        }

        /// <summary>
        /// The timeout in milliseconds to be used for requests. (defaults to 30000)
        /// </summary>
        [ConfigOption]
        [NotifyParentProperty(true)]
        [DefaultValue(30000)]
        [Description("The timeout in milliseconds to be used for requests. (defaults to 30000)")]
        public int Timeout
        {
            get
            {
                return this.State.Get<int>("Timeout", 30000);
            }
            set
            {
                this.State.Set("Timeout", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("formId")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [DefaultValue("")]
        public string FormProxyArg
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return "";
                }

                string formId = "";

                if (this.FormID.IsNotEmpty())
                {
                    formId = this.FormID;
                }
                /*else if (this.Owner != null && this.Owner.Page != null && this.Owner.Page.Form != null)
                {
                    formId = this.Owner.Page.Form.ClientID;
                }*/

                return formId;
            }
        }

        private ParameterCollection userParams;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ArrayToObject)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ParameterCollection ExtraParams
        {
            get
            {
                if (this.userParams == null)
                {
                    this.userParams = new ParameterCollection();
                    this.userParams.Owner = this.Owner;
                }

                return this.userParams;
            }
        }

        private EventMask eventMask;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public EventMask EventMask
        {
            get
            {
                if (this.eventMask == null)
                {
                    this.eventMask = new EventMask();
                }

                return this.eventMask;
            }
        }

        /// <summary>
        /// Show warning if request fail. If Failure handler exists then this handler will be called instead showing warning
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Show a Window with error message is DirectEvent request fails. This message Window will only show if a Failure Handler does not exist.")]
        public virtual bool ShowWarningOnFailure
        {
            get
            {
                return this.State.Get<bool>("ShowWarningOnFailure", true);
            }
            set
            {
                this.State.Set("ShowWarningOnFailure", value);
            }
        }
    }


    /*  EventMask
    -----------------------------------------------------------------------------------------------*/

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class EventMask : LoadMask
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [Localizable(true)]
        [DefaultValue("Working...")]
        [Description("")]
        public override string Msg
        {
            get
            {
                return this.State.Get<string>("Msg", "Working...");
            }
            set
            {
                this.State.Set("Msg", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(MaskTarget.Page)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual MaskTarget Target
        {
            get
            {
                return this.State.Get<MaskTarget>("Target", MaskTarget.Page);
            }
            set
            {
                this.State.Set("Target", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CustomTarget
        {
            get
            {
                return this.State.Get<string>("CustomTarget", "");
            }
            set
            {
                this.State.Set("CustomTarget", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int MinDelay
        {
            get
            {
                return this.State.Get<int>("MinDelay", 0);
            }
            set
            {
                this.State.Set("MinDelay", value);
            }
        }
    }
}