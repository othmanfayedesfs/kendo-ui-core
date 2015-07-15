(function(f, define){
    define([ "../kendo.core" ], f);
})(function(){

(function(kendo) {
    var Property = kendo.Class.extend({
        init: function(list) {
            this.list = list;
        },

        get: function(index) {
            return this.list.value(index, index);
        },

        set: function(start, end, value) {
            if (value === undefined) {
                value = end;
                end = start;
            }

            this.list.value(start, end, value);
        },

        copy: function(start, end, dst) {
            this.list.copy(start, end, dst);
        },

        iterator: function(start, end) {
            return this.list.iterator(start, end);
        }
    });

    var JsonProperty = Property.extend({
        get: function(index) {
            return JSON.parse(this.list.value(index, index));
        },

        set: function(start, end, value) {
            this.list.value(start, end, JSON.stringify(value));
        }
    });

    var ValueProperty = Property.extend({
        init: function(values, formats) {
            Property.prototype.init.call(this, values);

            this.formats = formats;
        },

        set: function(start, end, value, parseStrings) {
            var result = kendo.spreadsheet.Sheet.parse(value, parseStrings);

            if (result.type === "date") {
                this.formats.value(start, end, toExcelFormat(kendo.culture().calendar.patterns.d));
            }

            this.list.value(start, end, result.value);
        }
    });

    function toExcelFormat(format) {
        return format.replace(/M/g, "m").replace(/'/g, '"').replace(/tt/, "am/pm");
    }

    kendo.spreadsheet.PropertyBag = kendo.Class.extend({
        specs: [
            { property: ValueProperty, name: "value", value: null, sortable: true, serializable: true, depends: "format" },
            { property: Property, name: "format", value: null, sortable: true, serializable: true },
            { property: Property, name: "formula", value: null, sortable: true, serializable: true },
            { property: Property, name: "compiledFormula", value: null, sortable: true, serializable: false },
            { property: Property, name: "background", value: null, sortable: true, serializable: true },
            { property: JsonProperty, name: "borderBottom", value: null, sortable: false, serializable: true },
            { property: JsonProperty, name: "borderRight", value: null, sortable: false, serializable: true },
            { property: Property, name: "fontColor", value: null, sortable: true, serializable: true },
            { property: Property, name: "fontFamily", value: null, sortable: true, serializable: true },
            { property: Property, name: "fontLine", value: null, sortable: true, serializable: true },
            { property: Property, name: "fontSize", value: null, sortable: true, serializable: true },
            { property: Property, name: "fontStyle", value: null, sortable: true, serializable: true },
            { property: Property, name: "fontWeight", value: null, sortable: true, serializable: true },
            { property: Property, name: "horizontalAlignment", value: null, sortable: true, serializable: true },
            { property: Property, name: "verticalAlignment", value: null, sortable: true, serializable: true },
            { property: Property, name: "wrap", value: null, sortable: true, serializable: true }
        ],

        init: function(cellCount) {
            this.properties = {};

            this.lists = {};

            this.specs.forEach(function(spec) {
               this.lists[spec.name] = new kendo.spreadsheet.SparseRangeList(0, cellCount, spec.value);
            }, this);

            this.specs.forEach(function(spec) {
                this.properties[spec.name] = new spec.property(this.lists[spec.name], this.lists[spec.depends]);
            }, this);
        },

        get: function(name, index) {
            if (index === undefined) {
                return this.lists[name];
            }

            return this.properties[name].get(index);
        },

        set: function(name, start, end, value, parseStrings) {
            this.properties[name].set(start, end, value, parseStrings);
        },

        fromJSON: function(index, value) {
            for (var si = 0; si < this.specs.length; si++) {
                var spec = this.specs[si];

                if (spec.serializable) {
                    if (value[spec.name] !== undefined) {
                        this.set(spec.name, index, index, value[spec.name], false);
                    }
                }
            }
        },

        copy: function(sourceStart, sourceEnd, targetStart) {
            this.specs.forEach(function(spec) {
                this.properties[spec.name].copy(sourceStart, sourceEnd, targetStart);
            }, this);
        },

        iterator: function(name, start, end) {
            return this.properties[name].iterator(start, end);
        },

        sortable: function() {
            return this.specs.filter(function(spec) { return spec.sortable; })
                              .map(function(spec) {
                                return this.lists[spec.name];
                              }, this);
        },

        iterators: function(start, end, serializableOnly) {
            var specs = this.specs;

            if (serializableOnly) {
                specs = this.specs.filter(function(spec) {
                    return spec.serializable;
                });
            }

            return specs.map(function(spec) {
                var iterator = this.iterator(spec.name, start, end);

                return {
                    name: spec.name,
                    value: spec.value,
                    at: iterator.at.bind(iterator)
                };
            }, this);
        },

        forEach: function(start, end, callback, serializableOnly) {
            var iterators = this.iterators(start, end, serializableOnly);

            for (var index = start; index <= end; index++) {
                var values = {};

                iterators.forEach(function(iterator) {
                    var value = iterator.at(index);

                    if (value !== iterator.value) {
                        values[iterator.name] = value;
                    }
                });

                callback(values);
            }
        }
    });

})(kendo);

}, typeof define == 'function' && define.amd ? define : function(_, f){ f(); });
