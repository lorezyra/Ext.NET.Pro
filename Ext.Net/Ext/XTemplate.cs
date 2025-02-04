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
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;
using System.Web;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:XTemplate runat=\"server\"></{0}:XTemplate>")]
    [ToolboxBitmap(typeof(XTemplate), "Build.ToolboxIcons.XTemplate.bmp")]
    [ToolboxItem(true)]
    [Designer(typeof(EmptyDesigner))]
    [Description("")]
    public partial class XTemplate : LazyObservable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public XTemplate() 
        {
            if (HttpContext.Current != null)
            {
                this.EnableViewState = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.XTemplate";
            }
        }

        private List<JFunction> functions;

        /// <summary>
        /// Inline functions
        /// </summary>
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Meta]
        [Description("Inline functions")]
        public List<JFunction> Functions
        {
            get
            {
                if (this.functions == null)
                {
                    this.functions = new List<JFunction>();
                }

                return this.functions;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("functions", JsonMode.Raw)]
        [Description("")]
        protected internal virtual string FunctionsProxy
        {
            get
            {
                if (this.Functions.Count == 0)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder();

                sb.Append("{");
                bool comma = false;

                foreach (JFunction f in this.Functions)
                {
                    if (f.Name.IsEmpty())
                    {
                        throw new Exception("You have to define Name for XTemplate's function");
                    }

                    if (comma)
                    {
                        sb.Append(",");
                    }

                    sb.Append(f.ToScript());
                    comma = true;
                }

                sb.Append("}");

                return sb.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DefaultValue("")]
        [Description("Template text")]
        public string Html
        {
            get
            {
                return this.State.Get<string>("Html", "");
            }
            set
            {
                this.State.Set("Html", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("html", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected internal virtual string HtmlProxy
        {
            get
            {
                if (this.Html.IsEmpty())
                {
                    return "";
                }
                
                return "<!token>" + JSON.Serialize(this.TemplateString(true));
            }
        }

        /// <summary>
        /// Return template string
        /// </summary>
        /// <param name="array">true to return array of string</param>
        /// <returns></returns>
        public object TemplateString(bool array)
        {
            if (this.Html.IsEmpty())
            {
                return "";
            }

            string[] lines = this.Html.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            lines = Array.ConvertAll<string, string>(lines, delegate(string input) { return (input ?? "").Trim(); });

            return array ? (object)lines : (object)lines.Join("");
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.Html.IsEmpty();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool Visible
        {
            get
            {
                if (!base.Visible || this.DesignMode)
                {
                    return base.Visible;
                }
                return !this.IsDefault;
            }
            set
            {
                base.Visible = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            this.Visible = !this.IsDefault;
            base.Render(writer);
        }

        /// <summary>
        /// Applies the supplied values to the template and appends the new node(s) to el.
        /// </summary>
        /// <param name="target">The context element</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and appends the new node(s) to el.")]
        public void Append(string target, object data)
        {
            this.ScriptHelper("append", target, data);
        }

        /// <summary>
        /// Applies the supplied values to the template and appends the new node(s) to el.
        /// </summary>
        /// <param name="target">A ContentPanel whose body will be updated.</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and appends the new node(s) to el.")]
        public void Append(AbstractComponent target, object data)
        {
            this.ScriptHelper("append", target, data);
        }

        /// <summary>
        /// Applies the supplied values to the template and appends the new node(s) to el.
        /// </summary>
        /// <param name="target">A ContentPanel whose body will be updated.</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and appends the new node(s) to el.")]
        public void Append(Element target, object data)
        {
            this.Call("append", new JRawValue(target.Descriptor), data);
        }

        /// <summary>
        /// Applies the supplied values to the template and inserts the new node(s) after el.
        /// </summary>
        /// <param name="target">The context element</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and inserts the new node(s) after el.")]
        public void InsertAfter(string target, object data)
        {
            this.ScriptHelper("insertAfter", target, data);
        }

        /// <summary>
        /// Applies the supplied values to the template and inserts the new node(s) after el.
        /// </summary>
        /// <param name="target">A ContentPanel whose body will be updated.</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and inserts the new node(s) after el.")]
        public void InsertAfter(AbstractComponent target, object data)
        {
            this.ScriptHelper("insertAfter", target, data);
        }

        /// <summary>
        /// Applies the supplied values to the template and inserts the new node(s) after el.
        /// </summary>
        /// <param name="target">A ContentPanel whose body will be updated.</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and inserts the new node(s) after el.")]
        public void InsertAfter(Element target, object data)
        {
            this.Call("insertAfter", new JRawValue(target.Descriptor), data);
        }

        /// <summary>
        /// Applies the supplied values to the template and inserts the new node(s) before el.
        /// </summary>
        /// <param name="target">The context element</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and inserts the new node(s) before el.")]
        public void InsertBefore(string target, object data)
        {
            this.ScriptHelper("insertBefore", target, data);
        }

        /// <summary>
        /// Applies the supplied values to the template and inserts the new node(s) before el.
        /// </summary>
        /// <param name="target">A ContentPanel whose body will be updated.</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and inserts the new node(s) before el.")]
        public void InsertBefore(AbstractComponent target, object data)
        {
            this.ScriptHelper("insertBefore", target, data);
        }

        /// <summary>
        /// Applies the supplied values to the template and inserts the new node(s) before el.
        /// </summary>
        /// <param name="target">A ContentPanel whose body will be updated.</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and inserts the new node(s) before el.")]
        public void InsertBefore(Element target, object data)
        {
            this.Call("insertBefore", new JRawValue(target.Descriptor), data);
        }

        /// <summary>
        /// Applies the supplied values to the template and inserts the new node(s) as the first child of el.
        /// </summary>
        /// <param name="target">The context element</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and inserts the new node(s) as the first child of el.")]
        public void InsertFirst(string target, object data)
        {
            this.ScriptHelper("insertFirst", target, data);
        }

        /// <summary>
        /// Applies the supplied values to the template and inserts the new node(s) as the first child of el.
        /// </summary>
        /// <param name="target">A ContentPanel whose body will be updated.</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and inserts the new node(s) as the first child of el.")]
        public void InsertFirst(AbstractComponent target, object data)
        {
            this.ScriptHelper("insertFirst", target, data);
        }

        /// <summary>
        /// Applies the supplied values to the template and inserts the new node(s) as the first child of el.
        /// </summary>
        /// <param name="target">A ContentPanel whose body will be updated.</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and inserts the new node(s) as the first child of el.")]
        public void InsertFirst(Element target, object data)
        {
            this.Call("insertFirst", new JRawValue(target.Descriptor), data);
        }

        /// <summary>
        /// Applies the supplied values to the template and overwrites the content of el with the new node(s).
        /// </summary>
        /// <param name="target">The context element</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and overwrites the content of el with the new node(s).")]
        public void Overwrite(string target, object data)
        {
            this.ScriptHelper("overwrite", target, data);
        }

        /// <summary>
        /// Applies the supplied values to the template and overwrites the content of el with the new node(s).
        /// </summary>
        /// <param name="target">The context element</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and overwrites the content of el with the new node(s).")]
        public void Overwrite(Element target, object data)
        {
            this.Call("overwrite", new JRawValue(target.Descriptor), data);
        }

        /// <summary>
        /// Applies the supplied values to the template and overwrites the content of el with the new node(s).
        /// </summary>
        /// <param name="target">A ContentPanel whose body will be updated.</param>
        /// <param name="data">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        [Meta]
        [Description("Applies the supplied values to the template and overwrites the content of el with the new node(s).")]
        public void Overwrite(AbstractComponent target, object data)
        {
            this.ScriptHelper("overwrite", target, data);
        }

        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <param name="data"></param>
        [Description("")]
        protected void ScriptHelper(string name, AbstractComponent target, object data)
        {
            this.ScriptHelper(name, TokenUtils.RawWrap(target.ClientID + ".getContentTarget()"), data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <param name="data"></param>
        [Description("")]
        protected void ScriptHelper(string name, string target, object data)
        {
            this.AddScript(this.ClientID.ConcatWith(".", name, "(Ext.net.getEl(", this.ParseTarget(target), "),", JSON.Serialize(data), ");"));
        }
    }
}