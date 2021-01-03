function ValidateForm() {


    var result = true;

    $('span[data-valmsg-for="FName"]').text('');
    if ($('#FName').val() == "") {
        $('span[data-valmsg-for="FName"]').text('First Name can not be empty.');
        result = false;
    }

    if (/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test($('#Email').val())) {
        //return (true)
    } else {
        $('span[data-valmsg-for="Email"]').text('Email address invalid.');
        result = false;
    }

    if (/^\d*$/.test($('#MobileNo').val())) {
        //return (true)
    } else {
        $('span[data-valmsg-for="Email"]').text('Please enter number.');
        result = false;
    }

    $('span[data-valmsg-for="NIC"]').text('');
    if ($('#NIC').val() == "") {
        $('span[data-valmsg-for="NIC"]').text('NIC can not be empty.');
        result = false;
    }

    $('span[data-valmsg-for="Email"]').text('');
    if ($('#Email').val() == "") {
        $('span[data-valmsg-for="Email"]').text('Email can not be empty.');
        result = false;
    }

    $('span[data-valmsg-for="MobileNo"]').text('');
    if ($('#MobileNo').val() == "") {
        $('span[data-valmsg-for="MobileNo"]').text('MobileNo can not be empty.');
        result = false;
    }


    $('span[data-valmsg-for="Birthday"]').text('');
    if ($('#Birthday').val() == "") {
        $('span[data-valmsg-for="Birthday"]').text('Birthday can not be empty.');
        result = false;
    }

    $('span[data-valmsg-for="Address"]').text('');
    if ($('#Address').val() == "") {
        $('span[data-valmsg-for="Address"]').text('Address can not be empty.');
        result = false;
    }

    return result;
}



function Save(b) {

    ValidateForm();
    if (ValidateForm()) {
        document.getElementById('idSave').click();
    }

}