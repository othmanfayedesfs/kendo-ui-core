using System;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring ChartValueAxis
    /// </summary>
    public partial class ChartValueAxisBuilder
        
    {
        /// <summary>
        /// Value at which the category axis crosses this axis. (Only for object)Value indices at which the category axes cross the value axis. (Only for array)Date at which the category axis crosses this axis. (Only for date)
        /// </summary>
        /// <param name="value">The value for AxisCrossingValue</param>
        public ChartValueAxisBuilder AxisCrossingValue(params object[] value)
        {
            Container.AxisCrossingValue = value;
            return this;
        }

        /// <summary>
        /// The background color of the axis.
        /// </summary>
        /// <param name="value">The value for Background</param>
        public ChartValueAxisBuilder Background(string value)
        {
            Container.Background = value;
            return this;
        }

        /// <summary>
        /// The color of the value axis. Accepts a valid CSS color string, including hex and rgb.
        /// </summary>
        /// <param name="value">The value for Color</param>
        public ChartValueAxisBuilder Color(string value)
        {
            Container.Color = value;
            return this;
        }

        /// <summary>
        /// The crosshair configuration options.
        /// </summary>
        /// <param name="configurator">The configurator for the crosshair setting.</param>
        public ChartValueAxisBuilder Crosshair(Action<ChartValueAxisCrosshairSettingsBuilder> configurator)
        {

            Container.Crosshair.Chart = Container.Chart;
            configurator(new ChartValueAxisCrosshairSettingsBuilder(Container.Crosshair));

            return this;
        }

        /// <summary>
        /// The axis labels configuration.
        /// </summary>
        /// <param name="configurator">The configurator for the labels setting.</param>
        public ChartValueAxisBuilder Labels(Action<ChartValueAxisLabelsSettingsBuilder> configurator)
        {

            Container.Labels.Chart = Container.Chart;
            configurator(new ChartValueAxisLabelsSettingsBuilder(Container.Labels));

            return this;
        }

        /// <summary>
        /// The configuration of the axis lines. Also affects the major and minor ticks, but not the grid lines.
        /// </summary>
        /// <param name="configurator">The configurator for the line setting.</param>
        public ChartValueAxisBuilder Line(Action<ChartValueAxisLineSettingsBuilder> configurator)
        {

            Container.Line.Chart = Container.Chart;
            configurator(new ChartValueAxisLineSettingsBuilder(Container.Line));

            return this;
        }

        /// <summary>
        /// The configuration of the major grid lines. These are the lines that are an extension of the major ticks through the
		/// body of the chart.
        /// </summary>
        /// <param name="configurator">The configurator for the majorgridlines setting.</param>
        public ChartValueAxisBuilder MajorGridLines(Action<ChartValueAxisMajorGridLinesSettingsBuilder> configurator)
        {

            Container.MajorGridLines.Chart = Container.Chart;
            configurator(new ChartValueAxisMajorGridLinesSettingsBuilder(Container.MajorGridLines));

            return this;
        }

        /// <summary>
        /// The interval between major divisions.
		/// If the valueAxis.type is set to "log", the majorUnit value will be used for the base of the logarithm.
        /// </summary>
        /// <param name="value">The value for MajorUnit</param>
        public ChartValueAxisBuilder MajorUnit(double value)
        {
            Container.MajorUnit = value;
            return this;
        }

        /// <summary>
        /// The maximum value of the axis.
        /// </summary>
        /// <param name="value">The value for Max</param>
        public ChartValueAxisBuilder Max(double value)
        {
            Container.Max = value;
            return this;
        }

        /// <summary>
        /// The minimum value of the axis.
        /// </summary>
        /// <param name="value">The value for Min</param>
        public ChartValueAxisBuilder Min(double value)
        {
            Container.Min = value;
            return this;
        }

        /// <summary>
        /// The configuration of the minor grid lines. These are the lines that are an extension of the minor ticks through the
		/// body of the chart.
        /// </summary>
        /// <param name="configurator">The configurator for the minorgridlines setting.</param>
        public ChartValueAxisBuilder MinorGridLines(Action<ChartValueAxisMinorGridLinesSettingsBuilder> configurator)
        {

            Container.MinorGridLines.Chart = Container.Chart;
            configurator(new ChartValueAxisMinorGridLinesSettingsBuilder(Container.MinorGridLines));

            return this;
        }

        /// <summary>
        /// The configuration of the value axis major ticks.
        /// </summary>
        /// <param name="configurator">The configurator for the majorticks setting.</param>
        public ChartValueAxisBuilder MajorTicks(Action<ChartValueAxisMajorTicksSettingsBuilder> configurator)
        {

            Container.MajorTicks.Chart = Container.Chart;
            configurator(new ChartValueAxisMajorTicksSettingsBuilder(Container.MajorTicks));

            return this;
        }

        /// <summary>
        /// The configuration of the value axis minor ticks.
        /// </summary>
        /// <param name="configurator">The configurator for the minorticks setting.</param>
        public ChartValueAxisBuilder MinorTicks(Action<ChartValueAxisMinorTicksSettingsBuilder> configurator)
        {

            Container.MinorTicks.Chart = Container.Chart;
            configurator(new ChartValueAxisMinorTicksSettingsBuilder(Container.MinorTicks));

            return this;
        }

        /// <summary>
        /// The interval between minor divisions. It defaults to 1/5th of the valueAxis.majorUnit.
		/// If the valueAxis.type is set to "log", the minorUnit value represents the number of divisions between two major units and defaults to the major unit minus one.
        /// </summary>
        /// <param name="value">The value for MinorUnit</param>
        public ChartValueAxisBuilder MinorUnit(double value)
        {
            Container.MinorUnit = value;
            return this;
        }

        /// <summary>
        /// The unique axis name. Used to associate a series with a value axis using the series.axis option.
        /// </summary>
        /// <param name="value">The value for Name</param>
        public ChartValueAxisBuilder Name(string value)
        {
            Container.Name = value;
            return this;
        }

        /// <summary>
        /// If set to true the chart will prevent the automatic axis range from snapping to 0.
		/// Setting it to false will force the automatic axis range to snap to 0.
        /// </summary>
        /// <param name="value">The value for NarrowRange</param>
        public ChartValueAxisBuilder NarrowRange(bool value)
        {
            Container.NarrowRange = value;
            return this;
        }

        /// <summary>
        /// The name of the pane that the value axis should be rendered in.
		/// The axis will be rendered in the first (default) pane if not set.
        /// </summary>
        /// <param name="value">The value for Pane</param>
        public ChartValueAxisBuilder Pane(string value)
        {
            Container.Pane = value;
            return this;
        }

        /// <summary>
        /// The plot bands of the value axis.
        /// </summary>
        /// <param name="configurator">The configurator for the plotbands setting.</param>
        public ChartValueAxisBuilder PlotBands(Action<ChartValueAxisPlotBandFactory> configurator)
        {

            configurator(new ChartValueAxisPlotBandFactory(Container.PlotBands)
            {
                Chart = Container.Chart
            });

            return this;
        }

        /// <summary>
        /// If set to true the value axis direction will be reversed. By default categories are listed from left to right and from bottom to top.
        /// </summary>
        /// <param name="value">The value for Reverse</param>
        public ChartValueAxisBuilder Reverse(bool value)
        {
            Container.Reverse = value;
            return this;
        }

        /// <summary>
        /// If set to true the value axis direction will be reversed. By default categories are listed from left to right and from bottom to top.
        /// </summary>
        public ChartValueAxisBuilder Reverse()
        {
            Container.Reverse = true;
            return this;
        }

        /// <summary>
        /// The title configuration of the value axis.
        /// </summary>
        /// <param name="configurator">The configurator for the title setting.</param>
        public ChartValueAxisBuilder Title(Action<ChartValueAxisTitleSettingsBuilder> configurator)
        {

            Container.Title.Chart = Container.Chart;
            configurator(new ChartValueAxisTitleSettingsBuilder(Container.Title));

            return this;
        }

        /// <summary>
        /// The axis type.The supported values are:
        /// </summary>
        /// <param name="value">The value for Type</param>
        public ChartValueAxisBuilder Type(string value)
        {
            Container.Type = value;
            return this;
        }

        /// <summary>
        /// If set to true the chart will display the value axis. By default the value axis is visible.
        /// </summary>
        /// <param name="value">The value for Visible</param>
        public ChartValueAxisBuilder Visible(bool value)
        {
            Container.Visible = value;
            return this;
        }

        /// <summary>
        /// The value axis notes configuration.
        /// </summary>
        /// <param name="configurator">The configurator for the notes setting.</param>
        public ChartValueAxisBuilder Notes(Action<ChartValueAxisNotesSettingsBuilder> configurator)
        {

            Container.Notes.Chart = Container.Chart;
            configurator(new ChartValueAxisNotesSettingsBuilder(Container.Notes));

            return this;
        }

    }
}
