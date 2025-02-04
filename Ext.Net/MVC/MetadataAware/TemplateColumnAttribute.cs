/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel;

namespace Ext.Net.MVC
{
    public partial class TemplateColumnAttribute : ColumnBaseAttribute
    {
        /// <summary>
        /// An XTemplate, or an XTemplate definition string to use to process a Model's data to produce a column's rendered value.
        /// </summary>
        [DefaultValue(null)]
        public virtual string TemplateString
        {
            get;
            set;
        }
        
        protected override ColumnBase CreateColumn()
        {
            return new TemplateColumn();
        }
    }
}