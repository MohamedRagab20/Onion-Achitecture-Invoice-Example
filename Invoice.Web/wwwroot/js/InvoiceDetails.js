
$(document).ready(function () {

    //Initialize datatable
    var TableEditable = function () {
        var handleTable = function () {
            function restoreRow(oTable, nRow) {
                var aData = oTable.fnGetData(nRow);
                var jqTds = $('>td', nRow);

                for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
                    oTable.fnUpdate(aData[i], nRow, i, false);
                }
                oTable.fnDraw();
            }

            var count = 0;
            function editRow(oTable, nRow) {
                var aData = oTable.fnGetData(nRow);
                var jqTds = $('>td', nRow);
                var selectItemsHtml = '<select id=Items_' + count + ' class="form-control">';
                $.ajax({
                    url: "/Home/GetItems",
                    data: {},
                    success: function (data) {
                        var objCount = data.length;
                        for (var x = 0; x < objCount; x++) {

                            var curitem = data[x];
                            selectItemsHtml += '<option value="' + curitem['id'] + '">' + curitem['itemName'] + '</option >';
                        }
                        selectItemsHtml += '</select>';
                        jqTds[0].innerHTML = selectItemsHtml;
                        var selectUnitsHtml = '<select id=Units_' + count + ' class="form-control">';
                        $.ajax({
                            url: "/Home/GetUnits",
                            data: {},
                            success: function (unitData) {
                                var unitsCount = unitData.length;
                                for (var x = 0; x < unitsCount; x++) {
                                    var unitcuritem = unitData[x];
                                    selectUnitsHtml += '<option id=' + unitcuritem['id'] + ' value="' + unitcuritem['id'] + '" > ' + unitcuritem['unitName'] + '</option > ';
                                }
                                selectUnitsHtml += '</select>';
                                jqTds[1].innerHTML = selectUnitsHtml;
                                jqTds[2].innerHTML = '<input value="0" class="form-control input-small Price_' + count + '" id=Price_' + count + ' type="number"  value="' + aData[2] + '">';
                                jqTds[3].innerHTML = '<input value="0" class="form-control input-small Qty_' + count + '" id=Qty_' + count + ' type="number" value="' + aData[3] + '">';
                                jqTds[4].innerHTML = '<input value="0" class="form-control input-small Total Total_' + count + '" id=Total_' + count + ' type="number"  value="' + aData[4] + '">';
                                jqTds[5].innerHTML = '<input value="0" class="form-control input-small Discount_' + count + '" id=Discount_' + count + ' type="number"  value="' + aData[5] + '">';
                                jqTds[6].innerHTML = '<input value="0" id=Net_' + count + ' type="number" class="Net form-control input-small" value="' + aData[6] + '">';
                                jqTds[7].innerHTML = '<a href="javascript:void(0)" class="delete">Delete</a>';

                                var rownumber = count;
                                $('.Discount_' + rownumber).change(function () {
                                    CalcuateInvoiceNetAndTital(rownumber);
                                });
                                $('.Total_' + rownumber).change(function () {
                                    CalcuateInvoiceNetAndTital(rownumber);
                                });
                                $('.Price_' + rownumber).change(function () {
                                    CalcuateInvoiceNetAndTital(rownumber);
                                });
                                $('.Qty_' + rownumber).change(function () {
                                    CalcuateInvoiceNetAndTital(rownumber);
                                });

                                count++;
                            }
                        }
                        );
                    }
                }
                );

            }

            function saveRow(oTable, nRow) {
                var jqInputs = $('input', nRow);
                oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
                oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
                oTable.fnUpdate(jqInputs[2].value, nRow, 2, false);
                oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
                oTable.fnUpdate(jqInputs[4].value, nRow, 4, false);
                oTable.fnUpdate(jqInputs[5].value, nRow, 5, false);
                oTable.fnUpdate(jqInputs[6].value, nRow, 6, false);
                oTable.fnDraw();
            }

            function cancelEditRow(oTable, nRow) {
                var jqInputs = $('input', nRow);
                oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
                oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
                oTable.fnUpdate(jqInputs[2].value, nRow, 2, false);
                oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
                oTable.fnUpdate(jqInputs[4].value, nRow, 4, false);
                oTable.fnUpdate(jqInputs[5].value, nRow, 5, false);
                oTable.fnUpdate(jqInputs[6].value, nRow, 6, false);
                oTable.fnDraw();
            }

            var table = $('#sample_editable_1');

            var oTable = table.dataTable({

                "lengthMenu": [
                    [5, 15, 20, -1],
                    [5, 15, 20, "All"] // change per page values here
                ],

                // set the initial value
                "pageLength": 10,

                "language": {
                    "lengthMenu": " _MENU_ records"
                },
                "columnDefs": [{ // set default column settings
                    'orderable': true,
                    'targets': [0]
                }, {
                    "searchable": true,
                    "targets": [0]
                }],
                "order": [
                    [0, "asc"]
                ] // set first column as a default sort by asc
            });

            var tableWrapper = $("#sample_editable_1_wrapper");

            tableWrapper.find(".dataTables_length select").select2({
                showSearchInput: true //hide search box with special css class
            }); // initialize select2 dropdown

            var nEditing = null;
            var nNew = false;

            $('#sample_editable_1_new').click(function (e) {
                e.preventDefault();

                var aiNew = oTable.fnAddData(['', '', '', '', '', '', '', '']);
                var nRow = oTable.fnGetNodes(aiNew[0]);
                editRow(oTable, nRow);
                nEditing = nRow;
                nNew = true;
            });

            table.on('click', '.delete', function (e) {
                e.preventDefault();

                var nRow = $(this).parents('tr')[0];
                oTable.fnDeleteRow(nRow);
            });

            table.on('click', '.cancel', function (e) {
                e.preventDefault();
                if (nNew) {
                    oTable.fnDeleteRow(nEditing);
                    nEditing = null;
                    nNew = false;
                } else {
                    restoreRow(oTable, nEditing);
                    nEditing = null;
                }
            });

            table.on('click', '.edit', function (e) {
                e.preventDefault();

                /* Get the row as a parent of the link that was clicked on */
                var nRow = $(this).parents('tr')[0];

                if (nEditing !== null && nEditing != nRow) {
                    /* Currently editing - but not this row - restore the old before continuing to edit mode */
                    restoreRow(oTable, nEditing);
                    editRow(oTable, nRow);
                    nEditing = nRow;
                } else if (nEditing == nRow && this.innerHTML == "Save") {
                    /* Editing this row and want to save it */
                    saveRow(oTable, nEditing);
                    nEditing = null;
                    alert("Updated! Do not forget to do some ajax to sync with backend :)");
                } else {
                    /* No edit in progress - let's start one */
                    editRow(oTable, nRow);
                    nEditing = nRow;
                }
            });
        };

        return {

            //main function to initiate the module
            init: function () {
                handleTable();
            }
        };

    }();

    TableEditable.init();
});

function CalcuateInvoiceNetAndTital(count) {

    if ($("#Qty_" + count).val() != null && $("#Price_" + count).val() != null) {
        $("#Total_" + count).val(parseInt($("#Qty_" + count).val()) * parseInt($("#Price_" + count).val()));
    }

    if ($("#Total_" + count).val() != null && $("#Discount_" + count).val() != null) {
        $("#Net_" + count).val(parseInt($("#Total_" + count).val() - parseInt($("#Discount_" + count).val())));
    }

    var invoiceTotal = 0;
    $('.Total').each(function (index, value) {
        if ($(this).val() != null && $(this).val() != "")
            invoiceTotal += parseInt($(this).val());
    });
    $("#invoiceTotal").val(invoiceTotal);

    var invoiceNet = 0;
    $('.Net').each(function (index, value) {
        if ($(this).val() != null && $(this).val() != "")
            invoiceNet += parseInt($(this).val());
    });
    $("#invoiceNet").val(invoiceNet);

}

function SaveInvoice() {
    debugger;
    var count = 0;
    var invoiceDetails = new Array();
    $("#sample_editable_1 tbody tr").each(function (e) {

        var element = $(this);
        invoiceDetails.push({
            Total: $(element).find("#Total_" + count).val(),
            Qty: $(element).find("#Qty_" + count).val(),
            Price: $(element).find("#Price_" + count).val(),
            Discount: $(element).find("#Discount_" + count).val(),
            Net: $(element).find("#Net_" + count).val(),
            ItemId: $(element).find("#Items_" + count).val(),
            UnitId: $(element).find("#Units_" + count).val()
        });

        count++;
    });

    var Invoice = new Array();

    Invoice.push({
        InvoiceNo: $("#txtInvoiceNo").val(),
        StoreId: $("#StoresList").val(),
        Total: $("#invoiceTotal").val(),
        Taxes: $("#invoiceTaxes").val(),
        Net: $("#invoiceNet").val(),
        InvoiceDetails: invoiceDetails
    });

    $.ajax({
        url: "/Home/SaveInvoice",
        type: "POST",
        data: JSON.stringify(Invoice),
        cache: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {

            if (result == true) {

                alert('Invoice Added');

                setTimeout(function () { window.location = "/Home"; }, 2000);
            }
            else {
                alert('Please enter correct data');
            }
        }
    });
}
