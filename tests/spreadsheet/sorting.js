(function() {
    var sheet;
    var defaults = kendo.ui.Spreadsheet.prototype.options;

    module("sorting", {
        setup: function() {
            sheet = new kendo.spreadsheet.Sheet(3, 3, defaults.rowHeight, defaults.columnWidth);
        }
    });

    test("sort sorts the range by ascending order", function() {
        sheet.range("A1:A3")
             .values([
              [ 3 ] ,
              [ 2 ],
              [ 1 ]
            ])
        .sort();

        var values = sheet.range("A1:A3").values();

        equal(values[0], 1);
        equal(values[1], 2);
        equal(values[2], 3);
    });

    test("sort triggers the change event of the sheet", 1, function() {
        sheet.bind("change", function() {
            ok(true);
        }).range("A1:A3").sort();
    });

    test("sorting a range by arbitrary column", function() {
        sheet.range("A1:B3")
             .values([
              [ 0, 3 ] ,
              [ 0, 2 ],
              [ 0, 1 ]
            ])
        .sort(1);

        var values = sheet.range("B1:B3").values();
        equal(values[0], 1);
        equal(values[1], 2);
        equal(values[2], 3);
    });

    test("sort by spec object", function() {
        sheet.range("A1:B3")
             .values([
              [ 0, 3 ] ,
              [ 0, 2 ],
              [ 0, 1 ]
            ])
        .sort({ column: 1 });

        var values = sheet.range("B1:B3").values();
        equal(values[0], 1);
        equal(values[1], 2);
        equal(values[2], 3);
    });

    test("multiple column sort", function() {
        sheet.range("A1:B3").values(
            [
                [1, 1],
                [0, 2],
                [1, 0]
            ]
        ).sort([{ column: 0 }, { column: 1 }]);

        var values = sheet.range("A1:B3").values();
        equal(values[0][0], 0);
        equal(values[0][1], 2);
        equal(values[1][1], 0);
        equal(values[2][1], 1);
    });

    test("sorts properties", function() {
        sheet.range("A1").value("foo");
        sheet.range("A2").value(2)
                         .fontColor("green")
                         .fontFamily("Arial")
                         .fontLine("underline")
                         .fontSize("1px")
                         .fontStyle("italic")
                         .fontWeight("bold")
                         .format("#")
                         .background("green")
                         .horizontalAlignment("right")
                         .verticalAlignment("top")
                         .wrap(false)
                         .borderBottom({size: "3px", color: "green"})
                         .borderRight({size: "3px", color: "green"})

        sheet.range("A1:A2").sort();

        equal(sheet.range("A1").fontColor(), "green");
        equal(sheet.range("A1").fontFamily(), "Arial");
        equal(sheet.range("A1").fontLine(), "underline");
        equal(sheet.range("A1").fontSize(), "1px");
        equal(sheet.range("A1").fontStyle(), "italic");
        equal(sheet.range("A1").fontWeight(), "bold");
        equal(sheet.range("A1").background(), "green");
        equal(sheet.range("A1").wrap(), false);
        equal(sheet.range("A1").horizontalAlignment(), "right");
        equal(sheet.range("A1").verticalAlignment(), "top");
        equal(sheet.range("A1").format(), "#");
        equal(sheet.range("A1").borderBottom(), null);
        equal(sheet.range("A1").borderRight(), null);


        sheet.range("A1").value("foo");
        sheet.range("A2").value(2).formula("=1");

        sheet.range("A1:A2").sort();

        equal(sheet.range("A1").formula(), "=1");
    });

    test("descending sort", function() {
        sheet.range("A1:B3")
             .values([
              [ 0, 1 ] ,
              [ 0, 2 ],
              [ 0, 1 ]
            ])
        .sort({ column: 1, ascending: false });

        var values = sheet.range("B1:B3").values();
        equal(values[0], 2);
        equal(values[1], 1);
        equal(values[2], 1);
    });

    test("sorting sets the sort state of the sheet", function() {
        sheet.range("A1:B3").values(
            [
                [1, 1],
                [0, 2],
                [1, 0]
            ]
        ).sort([{ column: 0 }, { column: 1 }]);

        var sort = sheet._sort;
        equal(sort.ref.toString(), "A1:B3");
        equal(sort.columns.length, 2);
        equal(sort.columns[1].index, 1);
    });
})();
