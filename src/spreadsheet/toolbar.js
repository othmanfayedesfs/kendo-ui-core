(function(f, define){
    define([ "../kendo.toolbar", "../kendo.colorpicker", "../kendo.combobox", "../kendo.dropdownlist", "../kendo.popup" ], f);
})(function(){

(function(kendo) {
    var ToolBar = kendo.ui.ToolBar;

    var SpreadsheetToolBar = ToolBar.extend({
        init: function(element, options) {
            ToolBar.fn.init.call(this, element, options);
            var handleClick = this._click.bind(this);

            this.bind({
                click: handleClick,
                toggle: handleClick
            });
        },
        _click: function(e) {
            var target = e.target;
            var commandType = target.attr("data-command");
            var value = null;

            if (!commandType) {
                return;
            }

            if (e.checked !== false) {
                value = target.attr("data-value");
            }

            this.trigger("execute", {
                commandType: commandType,
                property: target.attr("data-property"),
                value: value
            });
        },
        events: ToolBar.fn.events.concat([ "execute" ]),
        options: {
            name: "SpreadsheetToolBar"
        },
        bindTo: function(spreadsheet) {
            this.spreadsheet = spreadsheet;
        },
        range: function() {
            var sheet = this.spreadsheet.activeSheet();

            return sheet.range(sheet.activeCell());
        },
        refresh: function() {
            var range = this.range();
            var tools = this._tools();

            function setValue(tool, value) {
                if (tool.toolbar) {
                    tool.toolbar.value(value);
                }

                if (tool.overflow) {
                    tool.overflow.value(value);
                }
            }

            function setToggle(tool, toggle) {
                var toolbar = tool.toolbar;
                var overflow = tool.overflow;
                var toggleable = (toolbar && toolbar.options.toggleable) ||
                                 (overflow && overflow.options.toggleable);

                if (!toggleable) {
                    return;
                }

                if (toolbar) {
                    toolbar.toggle(toggle);
                }

                if (overflow) {
                    overflow.toggle(toggle);
                }
            }

            for (var name in tools) {
                var tool = tools[name];
                var value = range[name]();

                if (tool instanceof Array) { // text alignment tool groups
                    for (var i = 0; i < tool.length; i++) {
                        setToggle(tool[i], tool[i].toolbar.element.attr("data-value") === value);
                    }
                } else if (tool.type === "button") {
                    setToggle(tool, !!value);
                } else if (tool.type === "colorPicker") {
                    setValue(tool, value);
                } else if (tool.type === "fontSize") {
                    setValue(tool, kendo.parseInt(value) || DEFAULT_FONT_SIZE);
                } else if (tool.type === "fontFamily") {
                    setValue(tool, value || DEFAULT_FONT_FAMILY);
                }
            }
        },
        _tools: function() {
            return this.element.find("[data-command]").toArray().reduce(function(tools, element) {
                element = $(element);
                var property = element.attr("data-property");
                var toolGroup;

                if (property) {
                    if (tools[property]) {
                        if (!(tools[property] instanceof Array)) {
                            tools[property] = new Array(tools[property]);
                        }
                        tools[property].push(this._getItem(element));
                    } else {
                        tools[property] = this._getItem(element);
                    }
                }

                return tools;
            }.bind(this), {});
        },
        destroy: function() {
            // TODO: move to ToolBar.destroy to take care of these
            this.element.find("[data-command],.k-button").each(function() {
                var element = $(this);
                var instance = element.data("instance");
                if (instance && instance.destroy) {
                    instance.destroy();
                }
            });

            ToolBar.fn.destroy.call(this);
        }
    });

    var colorPicker = kendo.toolbar.Item.extend({
        init: function(options, toolbar) {
            var colorPicker = $("<input />").kendoColorPicker({
                palette: "basic",
                toolIcon: options.toolIcon,
                change: function(e) {
                    toolbar.trigger("execute", {
                        commandType: "PropertyChangeCommand",
                        property: options.property,
                        value: this.value()
                    });
                }
            }).data("kendoColorPicker");

            this.colorPicker = colorPicker;
            this.element = colorPicker.wrapper;
            this.options = options;
            this.toolbar = toolbar;

            this.element.attr({
                "data-command": "PropertyChangeCommand",
                "data-property": options.property
            });

            this.element.data({
                type: "colorPicker",
                colorPicker: this
            });
        },

        value: function(value) {
            if (value !== undefined) {
                this.colorPicker.value(value);
            } else {
                return this.colorPicker.value();
            }
        }
    });

    kendo.toolbar.registerComponent("colorPicker", colorPicker);

    var FONT_SIZES = [8, 9, 10, 11, 12, 13, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72];
    var DEFAULT_FONT_SIZE = 12;

    var fontSize = kendo.toolbar.Item.extend({
        init: function(options, toolbar) {
            var comboBox = $("<input />").kendoComboBox({
                change: function(e) {
                    toolbar.trigger("execute", {
                        commandType: "PropertyChangeCommand",
                        property: options.property,
                        value: kendo.parseInt(this.value()) + "px"
                    });
                },
                dataSource: options.fontSizes || FONT_SIZES,
                value: DEFAULT_FONT_SIZE
            }).data("kendoComboBox");

            this.comboBox = comboBox;
            this.element = comboBox.wrapper;
            this.options = options;
            this.toolbar = toolbar;

            this.element.width(options.width).attr({
                "data-command": "PropertyChangeCommand",
                "data-property": options.property
            });

            this.element.data({
                type: "fontSize",
                fontSize: this
            });
        },

        value: function(value) {
            if (value !== undefined) {
                this.comboBox.value(value);
            } else {
                return this.comboBox.value();
            }
        }
    });

    kendo.toolbar.registerComponent("fontSize", fontSize);

    var FONT_FAMILIES = ["Arial", "Courier New", "Georgia", "Times New Roman", "Trebuchet MS", "Verdana"];
    var DEFAULT_FONT_FAMILY = "Arial";

    var DropDownTool = kendo.toolbar.Item.extend({
        init: function(options, toolbar) {
            var dropDownList = $("<select />").kendoDropDownList({
                height: "auto"
            }).data("kendoDropDownList");

            this.dropDownList = dropDownList;
            this.element = dropDownList.wrapper;
            this.options = options;
            this.toolbar = toolbar;

            dropDownList.bind("open", this._open.bind(this));
            dropDownList.bind("change", this._change.bind(this));

            this.element.width(options.width).attr({
                "data-command": "PropertyChangeCommand",
                "data-property": options.property
            });
        },
        _open: function() {
            var ddl = this.dropDownList;
            var list = ddl.list;
            var listWidth;

            list.css({
                whiteSpace: "nowrap",
                width: "auto"
            });

            listWidth = list.width();

            if (listWidth) {
                listWidth += 20;
            } else {
                listWidth = ddl._listWidth;
            }

            list.css("width", listWidth + kendo.support.scrollbar());

            ddl._listWidth = listWidth;
        },
        _change: function(e) {
            var value = e.sender.value();
            this.toolbar.trigger("execute", {
                commandType: "PropertyChangeCommand",
                property: this.options.property,
                value: value == "null" ? null : value
            });
        },
        value: function(value) {
            if (value !== undefined) {
                this.dropDownList.value(value);
            } else {
                return this.dropDownList.value();
            }
        }
    });

    kendo.toolbar.registerComponent("fontFamily", DropDownTool.extend({
        init: function(options, toolbar) {
            DropDownTool.fn.init.call(this, options, toolbar);

            var ddl = this.dropDownList;
            ddl.setDataSource(options.fontFamilies || FONT_FAMILIES);
            ddl.value(DEFAULT_FONT_FAMILY);

            this.element.data({
                type: "fontFamily",
                fontFamily: this
            });
        }
    }));

    kendo.toolbar.registerComponent("format", DropDownTool.extend({
        _revertTitle: function(e) {
            e.sender.value("");
            e.sender.wrapper.width("auto");
        },
        init: function(options, toolbar) {
            DropDownTool.fn.init.call(this, options, toolbar);

            var ddl = this.dropDownList;
            ddl.bind("change", this._revertTitle.bind(this));
            ddl.bind("dataBound", this._revertTitle.bind(this));
            ddl.setOptions({
                dataValueField: "format",
                dataValuePrimitive: true,
                valueTemplate: "123",
                template:
                    "#: data.name #" +
                    "# if (data.sample) { #" +
                        "<span class='k-spreadsheet-sample'>#: data.sample #</span>" +
                    "# } #"
            });
            ddl.setDataSource([
                { format: null, name: "Automatic" },
                { format: "?.00", name: "Number", sample: "1,499.99" },
                { format: "?.00%", name: "Percent", sample: "14.50%" },
                { format: '_("$"* #,##0.00_);_("$"* \(#,##0.00\);_("$"* "-"??_);_(@_)', name: "Financial", sample: "(1,000.12)" },
                { format: "$?", name: "Currency", sample: "$1,499.99" },
                { format: "m/d/yyyy", name: "Date", sample: "4/21/2012" },
                { format: "h:mm:ss AM/PM", name: "Time", sample: "5:49:00 PM" },
                { format: "m/d/yyyy h:mm", name: "Date time", sample: "4/21/2012 5:49:00" },
                { format: "[h]:mm:ss", name: "Duration", sample: "168:05:00" }
            ]);

            this.element.data({
                type: "format",
                format: this
            });
        }
    }));

    var PopupTool = kendo.toolbar.ToolBarButton.extend({
        init: function(options, toolbar) {
            options.click = this.open.bind(this);

            kendo.toolbar.ToolBarButton.fn.init.call(this, options, toolbar);

            this.element.data("instance", this);
        },
        popup: function() {
            if (!this._popup) {
                this._popup = $("<div class='k-spreadsheet-window k-action-window' />")
                    .addClass(this.options.className || "")
                    .append(this.template)
                    .appendTo(document.body)
                    .kendoWindow({
                        scrollable: false,
                        resizable: false,
                        maximizable: false,
                        modal: true,
                        visible: false,
                        width: 400,
                        title: this.title,
                        open: function() {
                            this.center();
                        },
                        deactivate: function() {
                            this._popup.destroy();
                            this._popup = null;
                        }.bind(this)
                    })
                    .data("kendoWindow");
            }

            return this._popup;
        },
        destroy: function() {
            if (this._popup) {
                this._popup.destroy();
                this._popup = null;
            }
        },
        open: function() {
            this.popup().open();
        },
        apply: function() {
            this.close();
        },
        close: function() {
            this.popup().close();
        }
    });

    var FormatCellsViewModel = kendo.data.ObservableObject.extend({
        init: function(options) {
            kendo.data.ObservableObject.fn.init.call(this, options);

            this.useCategory(this.category);
        },
        useCategory: function(category) {
            var formats = this.allFormats.filter(function(x) { return x.category == category; });
            this.set("formats", formats);
            this.category = category;
        },
        categoryFor: function(format) {
            var formats = this.allFormats;
            var category = formats[0].category;

            for (var i = 0; i < formats.length; i++) {
                if (formats[i].format == format) {
                    category = formats[i].category;
                    break;
                }
            }

            return category;
        },
        categoryFilter: function(category) {
            if (category !== undefined) {
                this.useCategory(category);
            }

            return this.category || this.categoryFor(this.format);
        },
        categories: function() {
            var category = function (x) { return x.category; };
            var unique = function (x, index, self) { return self.indexOf(x) === index; };

            return this.allFormats.map(category).filter(unique);
        },
        preview: function() {
            var format = this.get("format");
            var value = this.value || 0;

            if (format && format.length) {
                // get formatted text from virtual dom node
                value = kendo.spreadsheet.formatting.format(value, format);
                return value.children[0].nodeValue;
            } else {
                return value;
            }
        }
    });

    var FormatPopupTool = PopupTool.extend({
        init: function(options, toolbar) {
            options = options || {};

            options.className = "k-spreadsheet-format-cells";
            options.formats = options.formats || this.options.formats;

            PopupTool.fn.init.call(this, options, toolbar);
        },
        options: {
            formats: [
                { category: "Number", value: "?.00%", name: "100.00%" },
                { category: "Currency", value: "$?", name: "U.S. Dollar" },
                { category: "Date", value: "m/d", name: "3/14" },
                { category: "Date", value: "m/d/yy", name: "3/14/01" },
                { category: "Date", value: "mm/dd/yy", name: "03/14/01" },
                { category: "Date", value: "d-mmm", name: "14-Mar" },
                { category: "Date", value: "d-mmm-yy", name: "14-Mar-01" },
                { category: "Date", value: "dd-mmm-yy", name: "14-Mar-01" },
                { category: "Date", value: "mmm-yy", name: "Mar-01" },
                { category: "Date", value: "mmmm-yy", name: "March-01" },
                { category: "Date", value: "mmmm dd, yyyy", name: "March 14, 2001" },
                { category: "Date", value: "m/d/yy hh:mm AM/PM", name: "3/14/01 1:30 PM" },
                { category: "Date", value: "m/d/yy h:mm", name: "3/14/01 13:30" },
                { category: "Date", value: "mmmmm", name: "M" },
                { category: "Date", value: "mmmmm-yy", name: "M-01" },
                { category: "Date", value: "m/d/yyyy", name: "3/14/2001" },
                { category: "Date", value: "d-mmm-yyyy", name: "14-Mar-2001" }
            ]
        },
        template: "<button class='k-button k-primary' data-bind='click: apply'>Apply</button>" +

                  "<div class='k-spreadsheet-preview' data-bind='text: preview' />" +

                  "<div class='k-simple-tabs' " +
                      "data-role='tabstrip' " +
                      "data-bind='source: categories, value: categoryFilter' " +
                      "data-animation='false' />" +

                  "<script type='text/x-kendo-template' id='format-item-template'>" +
                      "#: data.name #" +
                  "</script>" +

                  "<ul data-role='staticlist' tabindex='0' " +
                      "class='k-list k-reset' " +
                      "data-template='format-item-template' " +
                      "data-value-primitive='true' " +
                      "data-value-field='value' " +
                      "data-bind='source: formats, value: format' />",
        open: function(e) {
            var formats = this.options.formats.slice(0);
            var range = this.toolbar.range();
            var value = range.value();

            this.viewModel = new FormatCellsViewModel({
                allFormats: formats,
                format: range.format(),
                category: value instanceof Date ? "Date" : null,
                apply: this.apply.bind(this),
                value: value
            });

            PopupTool.fn.open.call(this);

            kendo.bind(this.popup().element, this.viewModel);
        },
        apply: function() {
            var format = this.viewModel.format;

            PopupTool.fn.apply.call(this);

            this.toolbar.trigger("execute", {
                commandType: "PropertyChangeCommand",
                property: "format",
                value: format
            });
        }
    });

    kendo.toolbar.registerComponent("formatPopup", FormatPopupTool);

    var BorderChangeTool = kendo.toolbar.Item.extend({
        init: function(options, toolbar) {
            this.element = $("<a href='#' data-command='BorderChangeCommand' class='k-button k-button-icon'>" +
                                "<span class='k-sprite k-icon k-i-all-borders'>" +
                                "</span><span class='k-icon k-i-arrow-s'></span>" +
                            "</a>");

            this.element.on("click", $.proxy(this.open, this));

            this.options = options;
            this.toolbar = toolbar;

            this._popupElement();
            this._popup();
            this._colorPicker();

            this.popupElement.on("click", ".k-spreadsheet-border-type-palette .k-button", $.proxy(this._click, this));

            this.element.data({
                type: "borders",
                instance: this
            });
        },

        open: function() {
            this.popup.toggle();
        },

        destroy: function() {
            this.popupElement.off("click");
            this.popup.destroy();
            this.popupElement.remove();
        },

        _popupElement: function() {
            var types = [
                "allBorders",
                "insideBorders",
                "insideHorizontalBorders",
                "insideVerticalBorders",
                "outsideBorders",
                "leftBorder",
                "topBorder",
                "rightBorder",
                "bottomBorder",
                "noBorders"
            ];

            var buttons = types.map(function(type) {
                return '<a href="#" data-border-type="' + type + '" class="k-button k-button-icon">' +
                            '<span class="k-sprite k-icon k-i-' + kendo.toHyphens(type) + '">' + type.replace(/([A-Z])/g, ' $1').toLowerCase() + '</span>' +
                       '</a>';
            }).join("");

            var popupElement = $("<div>", {
                "class": "k-spreadsheet-popup k-spreadsheet-border-palette",
                "html": "<div class='k-spreadsheet-border-type-palette'>" + buttons + "</div><div class='k-spreadsheet-border-style-palette'></div>"
            });

            this.popupElement = popupElement;
        },

        _popup: function() {
            var element = this.element;

            this.popup = this.popupElement.kendoPopup({
                anchor: element
            }).data("kendoPopup");
        },

        _colorPicker: function() {
            this.color = "#000";
            this.colorPicker = $("<input />").kendoColorPicker({
                palette: "basic",
                value: this.color,
                change: $.proxy(this._colorChange, this)
            }).data("kendoColorPicker");

            this.popupElement.find(".k-spreadsheet-border-style-palette").append(this.colorPicker.wrapper);
        },

        _colorChange: function(e) {
            this.color = e.value;
            if (this.type) {
                this._execute();
            }
        },

        _click: function(e) {
            this.type = $(e.currentTarget).data("borderType");
            this._execute();
        },

        _execute: function() {
            this.toolbar.trigger("execute", {
                commandType: "BorderChangeCommand",
                border: this.type,
                style: { size: "1px", color: this.color }
            });
        }
    });

    kendo.toolbar.registerComponent("borders", BorderChangeTool);

    kendo.spreadsheet.ToolBar = SpreadsheetToolBar;

    kendo.spreadsheet.toolbar = {
        PopupTool: PopupTool,
        FormatPopupTool: FormatPopupTool,
        FormatCellsViewModel: FormatCellsViewModel
    };

})(kendo);

}, typeof define == 'function' && define.amd ? define : function(_, f){ f(); });
