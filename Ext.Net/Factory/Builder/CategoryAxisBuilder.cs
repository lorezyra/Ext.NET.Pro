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
    public partial class CategoryAxis
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCategoryAxis, TBuilder> : Axis.Builder<TCategoryAxis, TBuilder>
            where TCategoryAxis : CategoryAxis
            where TBuilder : Builder<TCategoryAxis, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCategoryAxis component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Indicates whether or not to calculate the number of categories (ticks and labels) when there is not enough room to display all labels on the axis. If set to true, the axis will determine the number of categories to plot. If not, all categories will be plotted. Defaults to: false
			/// </summary>
            public virtual TBuilder CalculateCategoryCount(bool calculateCategoryCount)
            {
                this.ToComponent().CalculateCategoryCount = calculateCategoryCount;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A list of category names to display along this axis.
			/// </summary>
            public virtual TBuilder CategoryNames(string[] categoryNames)
            {
                this.ToComponent().CategoryNames = categoryNames;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : CategoryAxis.Builder<CategoryAxis, CategoryAxis.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CategoryAxis()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CategoryAxis component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CategoryAxis.Config config) : base(new CategoryAxis(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CategoryAxis component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CategoryAxis.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CategoryAxis(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CategoryAxis.Builder CategoryAxis()
        {
#if MVC
			return this.CategoryAxis(new CategoryAxis { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.CategoryAxis(new CategoryAxis());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public CategoryAxis.Builder CategoryAxis(CategoryAxis component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new CategoryAxis.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CategoryAxis.Builder CategoryAxis(CategoryAxis.Config config)
        {
#if MVC
			return new CategoryAxis.Builder(new CategoryAxis(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new CategoryAxis.Builder(new CategoryAxis(config));
#endif			
        }
    }
}