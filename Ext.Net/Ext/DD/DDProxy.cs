/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// A DragDrop implementation that inserts an empty, bordered div into the document that follows the cursor during drag operations. At the time of the click, the frame div is resized to the dimensions of the linked html element, and moved to the exact location of the linked element. References to the "frame" element refer to the single proxy element that was created to be dragged in place of all DDProxy elements on the page.
    /// </summary>
    [Meta]
    [ToolboxItem(true)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxData("<{0}:DDProxy runat=\"server\"></{0}:DDProxy>")]
    [ToolboxBitmap(typeof(DDProxy), "Build.ToolboxIcons.DragDrop.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A DragDrop implementation that inserts an empty, bordered div into the document that follows the cursor during drag operations. At the time of the click, the frame div is resized to the dimensions of the linked html element, and moved to the exact location of the linked element.")]
    public partial class DDProxy : DD
    {
        /// <summary>
        /// 
        /// </summary>
        public DDProxy()
        {
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
                return "Ext.dd.DDProxy";
            }
        }

        /// <summary>
        /// By default the frame is positioned exactly where the drag element is, so we use the cursor offset provided by Ext.dd.DD. Another option that works only if you do not have constraints on the obj is to have the drag frame centered around the cursor. Set centerFrame to true for this effect. Defaults to: false
        /// </summary>
        [ConfigOption]
        [Meta]
        [Category("5. DDProxy")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("By default the frame is positioned exactly where the drag element is, so we use the cursor offset provided by Ext.dd.DD. Another option that works only if you do not have constraints on the obj is to have the drag frame centered around the cursor. Set centerFrame to true for this effect. Defaults to: false")]
        public virtual bool CenterFrame
        {
            get
            {
                return this.State.Get<bool>("CenterFrame", false);
            }
            set
            {
                this.State.Set("CenterFrame", value);
            }
        }

        /// <summary>
        /// By default we resize the drag frame to be the same size as the element we want to drag (this is to get the frame effect). We can turn it off if we want a different behavior.
        /// </summary>
        [ConfigOption]
        [Meta]
        [Category("5. DDProxy")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("By default we resize the drag frame to be the same size as the element we want to drag (this is to get the frame effect). We can turn it off if we want a different behavior.")]
        public virtual bool ResizeFrame
        {
            get
            {
                return this.State.Get<bool>("ResizeFrame", true);
            }
            set
            {
                this.State.Set("ResizeFrame", value);
            }
        }

        private JFunction afterDrag;

        /// <summary>
        /// Abstract method runs on drag end
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Meta]
        [Category("5. DDProxy")]        
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Abstract method runs on drag end")]
        public virtual JFunction AfterDrag
        {
            get
            {
                if (this.afterDrag == null)
                {
                    this.afterDrag = new JFunction();
                }

                return this.afterDrag;
            }
        }
    }
}