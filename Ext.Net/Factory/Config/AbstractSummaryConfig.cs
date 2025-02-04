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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class AbstractSummary
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : GridFeature.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool showSummaryRow = true;

			/// <summary>
			/// true to add css for column separation lines. Default is false.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowSummaryRow 
			{ 
				get
				{
					return this.showSummaryRow;
				}
				set
				{
					this.showSummaryRow = value;
				}
			}

        }
    }
}