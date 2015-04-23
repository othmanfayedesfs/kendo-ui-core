using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI ChartSerieLabelsToPaddingSettings class
    /// </summary>
    public partial class ChartSerieLabelsToPaddingSettings 
    {
        public double? Bottom { get; set; }

        public double? Left { get; set; }

        public double? Right { get; set; }

        public double? Top { get; set; }


        public Chart Chart { get; set; }

        protected Dictionary<string, object> SerializeSettings()
        {
            var settings = new Dictionary<string, object>();

            if (Bottom.HasValue)
            {
                settings["bottom"] = Bottom;
            }

            if (Left.HasValue)
            {
                settings["left"] = Left;
            }

            if (Right.HasValue)
            {
                settings["right"] = Right;
            }

            if (Top.HasValue)
            {
                settings["top"] = Top;
            }

            return settings;
        }
    }
}
