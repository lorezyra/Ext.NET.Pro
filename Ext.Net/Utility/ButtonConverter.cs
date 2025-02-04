/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ButtonConverter : ControlConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        protected override object[] GetControls(IContainer container)
        {
            ComponentCollection components = container.Components;
            ArrayList controls = new ArrayList();

            foreach (IComponent component in components)
            {
                if (component is System.Web.UI.Control)
                {
                    Control c = (Control)component;

                    List<ButtonBase> buttons = ControlUtils.FindControls<ButtonBase>(c);

                    if (buttons != null && buttons.Count > 0)
                    {
                        foreach (ButtonBase btn in buttons)
                        {
                            if (btn.ID.IsNotEmpty() && !controls.Contains(btn.ID))
                            {
                                controls.Add(btn.ID);
                            }
                        }                        
                    }
                }
            }

            controls.Sort(Comparer.Default);

            return controls.ToArray();
        }
    }
}
