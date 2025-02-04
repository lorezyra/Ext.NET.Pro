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
    /// <summary><![CDATA[
    /// AjaxProxy is one of the most widely-used ways of getting data into your application. It uses AJAX requests to load data from the server, usually to be placed into a Store. Let's take a look at a typical setup. Here we're going to set up a Store that has an AjaxProxy. To prepare, we'll also set up a Model:
    /// 
    /// Ext.regModel('User', {
    ///     fields: ['id', 'name', 'email']
    /// });
    /// 
    /// //The Store contains the AjaxProxy as an inline configuration
    /// var store = new Ext.data.Store({
    ///     model: 'User',
    ///     proxy: {
    ///         type: 'ajax',
    ///         url : 'users.json'
    ///     }
    /// });
    /// 
    /// store.load();
    /// Our example is going to load user data into a Store, so we start off by defining a Model with the fields that we expect the server to return. Next we set up the Store itself, along with a proxy configuration. This configuration was automatically turned into an Ext.data.proxy.Ajax instance, with the url we specified being passed into AjaxProxy's constructor. It's as if we'd done this:
    /// 
    /// new Ext.data.proxy.Ajax({
    ///     url: 'users.json',
    ///     model: 'User',
    ///     reader: 'json'
    /// });
    /// A couple of extra configurations appeared here - model and reader. These are set by default when we create the proxy via the Store - the Store already knows about the Model, and Proxy's default Reader is JsonReader.
    /// 
    /// Now when we call store.load(), the AjaxProxy springs into action, making a request to the url we configured ('users.json' in this case). As we're performing a read, it sends a GET request to that url (see actionMethods to customize this - by default any kind of read will be sent as a GET request and any kind of write will be sent as a POST request).
    /// 
    /// Limitations
    /// 
    /// AjaxProxy cannot be used to retrieve data from other domains. If your application is running on http://domainA.com it cannot load data from http://domainB.com because browsers have a built-in security policy that prohibits domains talking to each other via AJAX.
    /// 
    /// If you need to read data from another domain and can't set up a proxy server (some software that runs on your own domain's web server and transparently forwards requests to http://domainB.com, making it look like they actually came from http://domainA.com), you can use Ext.data.proxy.JsonP and a technique known as JSON-P (JSON with Padding), which can help you get around the problem so long as the server on http://domainB.com is set up to support JSON-P responses. See JsonPProxy's introduction docs for more details.
    /// 
    /// Readers and Writers
    ///
    /// AjaxProxy can be configured to use any type of Reader to decode the server's response. If no Reader is supplied, AjaxProxy will default to using a JsonReader. Reader configuration can be passed in as a simple object, which the Proxy automatically turns into a Reader instance:
    /// 
    /// var proxy = new Ext.data.proxy.Ajax({
    ///     model: 'User',
    ///     reader: {
    ///         type: 'xml',
    ///         root: 'users'
    ///     }
    /// });
    /// 
    /// proxy.getReader(); //returns an XmlReader instance based on the config we supplied
    /// Url generation
    /// 
    /// AjaxProxy automatically inserts any sorting, filtering, paging and grouping options into the url it generates for each request. These are controlled with the following configuration options:
    ///
    /// pageParam - controls how the page number is sent to the server (see also startParam and limitParam)
    /// sortParam - controls how sort information is sent to the server
    /// groupParam - controls how grouping information is sent to the server
    /// filterParam - controls how filter information is sent to the server
    /// Each request sent by AjaxProxy is described by an Operation. To see how we can customize the generated urls, let's say we're loading the Proxy with the following Operation:
    /// 
    /// var operation = new Ext.data.Operation({
    ///     action: 'read',
    ///     page  : 2
    /// });
    /// Now we'll issue the request for this Operation by calling read:
    /// 
    /// var proxy = new Ext.data.proxy.Ajax({
    ///     url: '/users'
    /// });
    /// 
    /// proxy.read(operation); //GET /users?page=2
    /// Easy enough - the Proxy just copied the page property from the Operation. We can customize how this page data is sent to the server:
    /// 
    /// var proxy = new Ext.data.proxy.Ajax({
    ///     url: '/users',
    ///     pagePage: 'pageNumber'
    /// });
    /// 
    /// proxy.read(operation); //GET /users?pageNumber=2
    /// Alternatively, our Operation could have been configured to send start and limit parameters instead of page:
    /// 
    /// var operation = new Ext.data.Operation({
    ///     action: 'read',
    ///     start : 50,
    ///     limit : 25
    /// });
    /// 
    /// var proxy = new Ext.data.proxy.Ajax({
    ///     url: '/users'
    /// });
    /// 
    /// proxy.read(operation); //GET /users?start=50&limit=25
    /// Again we can customize this url:
    /// 
    /// var proxy = new Ext.data.proxy.Ajax({
    ///     url: '/users',
    ///     startParam: 'startIndex',
    ///     limitParam: 'limitIndex'
    /// });
    /// 
    /// proxy.read(operation); //GET /users?startIndex=50&limitIndex=25
    /// AjaxProxy will also send sort and filter information to the server. Let's take a look at how this looks with a more expressive Operation object:
    /// 
    /// var operation = new Ext.data.Operation({
    ///     action: 'read',
    ///     sorters: [
    ///         new Ext.util.Sorter({
    ///             property : 'name',
    ///             direction: 'ASC'
    ///         }),
    ///         new Ext.util.Sorter({
    ///             property : 'age',
    ///             direction: 'DESC'
    ///         })
    ///     ],
    ///     filters: [
    ///         new Ext.util.Filter({
    ///             property: 'eyeColor',
    ///             value   : 'brown'
    ///         })
    ///     ]
    /// });
    /// This is the type of object that is generated internally when loading a Store with sorters and filters defined. By default the AjaxProxy will JSON encode the sorters and filters, resulting in something like this (note that the url is escaped before sending the request, but is left unescaped here for clarity):
    /// 
    /// var proxy = new Ext.data.proxy.Ajax({
    ///     url: '/users'
    /// });
    /// 
    /// proxy.read(operation); //GET /users?sort=[{"property":"name","direction":"ASC"},{"property":"age","direction":"DESC"}]&filter=[{"property":"eyeColor","value":"brown"}]
    /// We can again customize how this is created by supplying a few configuration options. Let's say our server is set up to receive sorting information is a format like "sortBy=name#ASC,age#DESC". We can configure AjaxProxy to provide that format like this:
    /// 
    ///  var proxy = new Ext.data.proxy.Ajax({
    ///      url: '/users',
    ///      sortParam: 'sortBy',
    ///      filterParam: 'filterBy',
    /// 
    ///      //our custom implementation of sorter encoding - turns our sorters into "name#ASC,age#DESC"
    ///      encodeSorters: function(sorters) {
    ///          var length   = sorters.length,
    ///              sortStrs = [],
    ///              sorter, i;
    /// 
    ///          for (i = 0; i < length; i++) {
    ///              sorter = sorters[i];
    /// 
    ///              sortStrs[i] = sorter.property + '#' + sorter.direction
    ///          }
    /// 
    ///          return sortStrs.join(",");
    ///      }
    ///  });
    /// 
    ///  proxy.read(operation); //GET /users?sortBy=name#ASC,age#DESC&filterBy=[{"property":"eyeColor","value":"brown"}]
    ///  
    /// We can also provide a custom encodeFilters function to encode our filters.
    /// ]]></summary>
    [Meta]
    public partial class AjaxProxy : ServerProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public AjaxProxy()
        {
        }

        /// <summary>
        /// Alias
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        protected override string Type
        {
            get
            {
                return "ajax";
            }
        }

        private ParameterCollection headers;

        /// <summary>
        /// Any headers to add to the Ajax request. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("Config Options")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Any headers to add to the Ajax request. Defaults to undefined.")]
        public virtual ParameterCollection Headers
        {
            get
            {
                return this.headers ?? (this.headers = new ParameterCollection{Owner = this.Owner});
            }
        }

        /// <summary>
        /// Send params as JSON object
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Send params as JSON object")]
        public virtual bool Json
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
        /// Send params as XML object
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Send params as XML object")]
        public virtual bool Xml
        {
            get
            {
                return this.State.Get<bool>("Xml", false);
            }
            set
            {
                this.State.Set("Xml", value);
            }
        }

        private CRUDMethods actionMethods;

        /// <summary>
        /// Mapping of action name to HTTP request method. In the basic AjaxProxy these are set to 'GET' for 'read' actions and 'POST' for 'create', 'update' and 'destroy' actions. The Ext.data.proxy.Rest maps these to the correct RESTful methods.
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Mapping of action name to HTTP request method. In the basic AjaxProxy these are set to 'GET' for 'read' actions and 'POST' for 'create', 'update' and 'destroy' actions. The Ext.data.proxy.Rest maps these to the correct RESTful methods.")]
        public virtual CRUDMethods ActionMethods
        {
            get
            {
                return this.actionMethods ?? (this.actionMethods = new CRUDMethods{ Owner = this.Owner });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("actionMethods", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string ActionMethodsProxy
        {
            get
            {
                if (this.ActionMethods.IsDefault)
                {
                    return "";
                }

                return string.Format("Ext.apply({{}}, {0}, Ext.data.proxy.Ajax.prototype.actionMethods)", new ClientConfig().Serialize(this.ActionMethods));
            }
        }

        private JFunction getMethod;

        /// <summary>
        /// Returns the HTTP method name for a given request. By default this returns based on a lookup on actionMethods.
        /// Parameters
        /// request : Ext.data.Request
        ///     The request object
        /// Returns
        ///     The HTTP method to use (should be one of 'GET', 'POST', 'PUT' or 'DELETE')
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Returns the HTTP method name for a given request. By default this returns based on a lookup on actionMethods.")]
        public virtual JFunction GetMethod
        {
            get
            {
                if (this.getMethod == null)
                {
                    this.getMethod = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.getMethod.Args = new string[] { "request" };
                    }
                }

                return this.getMethod;
            }
        }
    }
}
