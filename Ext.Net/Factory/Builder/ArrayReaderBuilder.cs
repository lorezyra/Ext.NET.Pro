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
    public partial class ArrayReader
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TArrayReader, TBuilder> : JsonReader.Builder<TArrayReader, TBuilder>
            where TArrayReader : ArrayReader
            where TBuilder : Builder<TArrayReader, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TArrayReader component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ArrayReader.Builder<ArrayReader, ArrayReader.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ArrayReader()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ArrayReader component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ArrayReader.Config config) : base(new ArrayReader(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ArrayReader component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ArrayReader.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ArrayReader(this);
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
        public ArrayReader.Builder ArrayReader()
        {
#if MVC
			return this.ArrayReader(new ArrayReader { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ArrayReader(new ArrayReader());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ArrayReader.Builder ArrayReader(ArrayReader component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ArrayReader.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ArrayReader.Builder ArrayReader(ArrayReader.Config config)
        {
#if MVC
			return new ArrayReader.Builder(new ArrayReader(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ArrayReader.Builder(new ArrayReader(config));
#endif			
        }
    }
}