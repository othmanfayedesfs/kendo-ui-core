using System;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring ChartChartAreaSettings
    /// </summary>
    public partial class ChartChartAreaSettingsBuilder
        
    {
        /// <summary>
        /// The background color of the chart area. Accepts a valid CSS color string, including hex and rgb.
        /// </summary>
        /// <param name="value">The value for Background</param>
        public ChartChartAreaSettingsBuilder Background(string value)
        {
            Container.Background = value;
            return this;
        }

        /// <summary>
        /// The border of the chart area.
        /// </summary>
        /// <param name="configurator">The configurator for the border setting.</param>
        public ChartChartAreaSettingsBuilder Border(Action<ChartChartAreaBorderSettingsBuilder> configurator)
        {

            Container.Border.Chart = Container.Chart;
            configurator(new ChartChartAreaBorderSettingsBuilder(Container.Border));

            return this;
        }

        /// <summary>
        /// The height of the chart area.
        /// </summary>
        /// <param name="value">The value for Height</param>
        public ChartChartAreaSettingsBuilder Height(double value)
        {
            Container.Height = value;
            return this;
        }

        /// <summary>
        /// The margin of the chart area. A numeric value will set all margins.
        /// </summary>
        /// <param name="configurator">The configurator for the margin setting.</param>
        public ChartChartAreaSettingsBuilder Margin(Action<ChartChartAreaMarginSettingsBuilder> configurator)
        {

            Container.Margin.Chart = Container.Chart;
            configurator(new ChartChartAreaMarginSettingsBuilder(Container.Margin));

            return this;
        }

        /// <summary>
        /// The background opacity of the chart area. By default the background is opaque.
        /// </summary>
        /// <param name="value">The value for Opacity</param>
        public ChartChartAreaSettingsBuilder Opacity(double value)
        {
            Container.Opacity = value;
            return this;
        }

        /// <summary>
        /// The width of the chart area.
        /// </summary>
        /// <param name="value">The value for Width</param>
        public ChartChartAreaSettingsBuilder Width(double value)
        {
            Container.Width = value;
            return this;
        }

    }
}
