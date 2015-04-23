using System;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring ChartTitleBorderSettings
    /// </summary>
    public partial class ChartTitleBorderSettingsBuilder
        
    {
        /// <summary>
        /// The color of the border. Accepts a valid CSS color string, including hex and rgb.
        /// </summary>
        /// <param name="value">The value for Color</param>
        public ChartTitleBorderSettingsBuilder Color(string value)
        {
            Container.Color = value;
            return this;
        }

        /// <summary>
        /// The dash type of the chart title border.The following dash types are supported:
        /// </summary>
        /// <param name="value">The value for DashType</param>
        public ChartTitleBorderSettingsBuilder DashType(string value)
        {
            Container.DashType = value;
            return this;
        }

        /// <summary>
        /// The width of the border in pixels. By default the border width is set to zero which means that the border will not appear.
        /// </summary>
        /// <param name="value">The value for Width</param>
        public ChartTitleBorderSettingsBuilder Width(double value)
        {
            Container.Width = value;
            return this;
        }

    }
}
