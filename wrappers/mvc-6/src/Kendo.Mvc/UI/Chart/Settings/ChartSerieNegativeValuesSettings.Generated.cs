using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI ChartSerieNegativeValuesSettings class
    /// </summary>
    public partial class ChartSerieNegativeValuesSettings 
    {
        public string Color { get; set; }

        public bool? Visible { get; set; }


        public Chart Chart { get; set; }

        protected Dictionary<string, object> SerializeSettings()
        {
            var settings = new Dictionary<string, object>();

            if (Color?.HasValue() == true)
            {
                settings["color"] = Color;
            }

            if (Visible.HasValue)
            {
                settings["visible"] = Visible;
            }

            return settings;
        }
    }
}
