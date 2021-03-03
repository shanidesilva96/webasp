//Click Submit Button in JS
<button type="submit" name="submitbutton" value="XLS" class="btn btn-success btn-width">Export To Excel</button>

document.getElementById('btnLoad2').click();



$('select').select2({
  minimumInputLength: 3 // only start searching when the user has input 3 or more characters
});


//ADD ROW in to table with .DATATABLE
$(document).ready(function () {
    var t = $('#facTbl').DataTable();
    var counter = 1;

    $('#addRow').on('click', function () {
        t.row.add([
            counter + '.1',
            counter + '.2',
            counter + '.3',
            counter + '.4',
            counter + '.5',
            counter + '.6',
            counter + '.7',
            counter + '.8',
            counter + '.9'
        ]).draw(false);

        counter++;
    });


    $('#addRow').click();
});
