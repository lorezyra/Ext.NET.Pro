/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Web.Mvc;

namespace Ext.Net
{
    public partial class Button : ButtonBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Description("")]
        public virtual string DirectClickAction
        {
            get
            {
                return this.DirectEvents.Click.Action;
            }
            set
            {
                this.DirectEvents.Click.Action = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Description("")]
        public virtual string DirectToggleAction
        {
            get
            {
                return this.DirectEvents.Toggle.Action;
            }
            set
            {
                this.DirectEvents.Toggle.Action = value;
            }
        }
    }
}