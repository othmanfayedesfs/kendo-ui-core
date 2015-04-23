using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI ChartValueAxisTitleSettings class
    /// </summary>
    public partial class ChartValueAxisTitleSettings 
    {
        public string Background { get; set; }

        public ChartValueAxisTitleBorderSettings Border { get; } = new ChartValueAxisTitleBorderSettings();

        public string Color { get; set; }

        public string Font { get; set; }

        public ChartValueAxisTitleMarginSettings Margin { get; } = new ChartValueAxisTitleMarginSettings();

        public ChartValueAxisTitlePaddingSettings Padding { get; } = new ChartValueAxisTitlePaddingSettings();

        public string Position { get; set; }

        public double? Rotation { get; set; }

        public string Text { get; set; }

        public bool? Visible { get; set; }

        public ClientHandlerDescriptor Visual { get; set; }


        public Chart Chart { get; set; }

        protected Dictionary<string, object> SerializeSettings()
        {
            var settings = new Dictionary<string, object>();

            if (Background?.HasValue() == true)
            {
                settings["background"] = Background;
            }

            var border = Border.Serialize();
            if (border.Any())
            {
                settings["border"] = border;
            }

            if (Color?.HasValue() == true)
            {
                settings["color"] = Color;
            }

            if (Font?.HasValue() == true)
            {
                settings["font"] = Font;
            }

            var margin = Margin.Serialize();
            if (margin.Any())
            {
                settings["margin"] = margin;
            }

            var padding = Padding.Serialize();
            if (padding.Any())
            {
                settings["padding"] = padding;
            }

            if (Position?.HasValue() == true)
            {
                settings["position"] = Position;
            }

            if (Rotation.HasValue)
            {
                settings["rotation"] = Rotation;
            }

            if (Text?.HasValue() == true)
            {
                settings["text"] = Text;
            }

            if (Visible.HasValue)
            {
                settings["visible"] = Visible;
            }

            if (Visual?.HasValue() == true)
            {
                settings["visual"] = Visual;
            }

            return settings;
        }
    }
}
