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
    public abstract partial class CheckboxGroupBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCheckboxGroupBase, TBuilder> : FieldContainerBase.Builder<TCheckboxGroupBase, TBuilder>
            where TCheckboxGroupBase : CheckboxGroupBase
            where TBuilder : Builder<TCheckboxGroupBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCheckboxGroupBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// False to validate that at least one item in the group is checked (defaults to true). If no items are selected at validation time, BlankText will be used as the error text.
			/// </summary>
            public virtual TBuilder AllowBlank(bool allowBlank)
            {
                this.ToComponent().AllowBlank = allowBlank;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the AllowBlank validation fails (defaults to 'You must select at least one item in this group')
			/// </summary>
            public virtual TBuilder BlankText(string blankText)
            {
                this.ToComponent().BlankText = blankText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies a number of columns will be created and the contained controls will be automatically distributed based on the value of vertical.
			/// </summary>
            public virtual TBuilder ColumnsNumber(int columnsNumber)
            {
                this.ToComponent().ColumnsNumber = columnsNumber;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// You can also specify an array of column widths, mixing integer (fixed width) and float (percentage width) values as needed (e.g., [100, .25, .75]). Any integer values will be rendered first, then any float values will be calculated as a percentage of the remaining space. Float values do not have to add up to 1 (100%) although if you want the controls to take up the entire field container you should do so.
			/// </summary>
            public virtual TBuilder ColumnsWidths(double[] columnsWidths)
            {
                this.ToComponent().ColumnsWidths = columnsWidths;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Fire change event after rendering
			/// </summary>
            public virtual TBuilder FireChangeOnLoad(bool fireChangeOnLoad)
            {
                this.ToComponent().FireChangeOnLoad = fireChangeOnLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to distribute contained controls across columns, completely filling each column top to bottom before starting on the next column. The number of controls in each column will be automatically calculated to keep columns as even as possible. The default value is false, so that controls will be added to columns one at a time, completely filling each row left to right before starting on the next row.
			/// </summary>
            public virtual TBuilder Vertical(bool vertical)
            {
                this.ToComponent().Vertical = vertical;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetValue(Dictionary<string, object> values)
            {
                this.ToComponent().SetValue(values);
                return this as TBuilder;
            }
            
        }        
    }
}