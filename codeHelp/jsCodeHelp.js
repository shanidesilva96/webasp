//Add row
function addRow() {

    ValidateFormAddingRowCMP();
    if (ValidateFormAddingRowCMP()) {

        var ItemId = $('#IDComponentsItemCode').val();

        var Item_name = $("#IDComponentsItemDesc").val();
        //var emp_name = $('#Quantity option:selected').text();

        if ((ItemId != null && ItemId != 0) && (IDAssetCode != null && IDAssetCode != 0)) {
            //if (ValidateRes(ItemId)) {
            $('.tblClz').append(
                      '<tr>' +
                      '<td  style="display:none"> <input type="text" class="" id="ItemId" value="' + ItemId + ' ">' + ItemId + '</td>' +
                      '<td>' + Item_name + '</td>' +
                      '<td><button type="button" class="btn btn-danger btn-xs" onclick="removeRes(this)">Remove</button></td>' +
                      '</tr>');
            $('#IDComponentsItemCode').val(0).trigger('change');

            //}


        }
    }
}

//Remove
function removeRes(btnRemove) {
    if (typeof (btnRemove) == "object") {
        $(btnRemove).closest("tr").remove();
    }
}



// Save js
function OLDSaveAssetFunction() {

    ValidateForm();
    if (ValidateForm()) {
		
        Components = [];		
		
        var row_count = $('.tblClz tr').length;
        for (var i = 1; i < row_count; i++) {
            var ItemId = $('.tblClz tr:nth-child(' + i + ') td:nth-child(1)').text();
            var Qty = $('.tblClz tr:nth-child(' + i + ') td:nth-child(2)').text();
            var item = {
                ItemId: ItemId,
                Qty: Qty
            }
            Components.push(item);
        }
		
		var param = {
            IDAssetCode: $('#IDAssetCode').val(),
			
			Components: Components,
        }
		
		$.ajax({
            url: $("#SaveFunction").val(),
            type: "POST",
            dataType: "JSON",
            data: { model: param },
            success: function (data) {
                console.log(data);
                if (data != null) {
                    if (data == true) {
                        $.niftyNoty({
                            type: 'success',
                            container: 'floating',
                            title: 'Success',
                            message: 'Successfully saved your records.',
                            closeBtn: true,
                            floating: {
                                position: "top-right",
                                animationIn: "lightSpeedIn",
                                animationOut: "lightSpeedOut"
                            },
                            timer: 3000,
                            onShown: function () {
                                location.reload();
                            }

                        });
                    } else {
                        $.niftyNoty({
                            type: 'danger',
                            container: 'floating',
                            title: 'Error',
                            message: 'Sorry. Something went wrong',
                            closeBtn: true,
                            floating: {
                                position: "top-right",
                                animationIn: "lightSpeedIn",
                                animationOut: "lightSpeedOut"
                            },
                            timer: 3000,
                            onShown: function () {
                                location.reload();
                            }

                        });
                    }
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR);
            }


        });
	}
}



//validation
function ValidateForm() {


    var result = true;

    $('span[data-valmsg-for="IDAssetCode"]').text('');
    if ($('#IDAssetCode').val() == "") {
        $('span[data-valmsg-for="IDAssetCode"]').text('Asset Code is required.');
        result = false;
    }

    $('span[data-valmsg-for="IDDetailsStatus"]').text('');
    if ($('#IDDetailsStatus option:selected').text() == "Select Status") {
        $('span[data-valmsg-for="IDDetailsStatus"]').text('Select Status.');
        result = false;
    }

    return result;
}

