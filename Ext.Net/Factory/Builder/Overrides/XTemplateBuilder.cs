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

namespace Ext.Net
{
    // <summary>
    /// 
    /// </summary>
    public partial class XTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : XTemplate.Builder<XTemplate, XTemplate.Builder>
        {
            public virtual XTemplate.Builder Html(Func<object, object> html)
            {
                object result = html(null);
                this.ToComponent().Html = result.ToString();

                return this as XTemplate.Builder;
            }
        }
    }
}