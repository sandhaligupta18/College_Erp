$(document).ready(function () {
    debugger
    alert("Hello");
});

function IsEmail(email) {
    debugger;   
    const regex = /^([a-zA-Z0-9_.+-])+(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (!regex.test(email)) {
        return false;
    }
    else {
        return true;
    }
}

//$('.AlphabetsOnly').keypress(function (e) {
//    var regex = new RegExp(/^[a-zA-Z\s]+$/);
//    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
//    if (regex.test(str)) {
//        return true;
//    }
//    else {
//        e.preventDefault();
//        return false;
//    }
//});

function IsName(e) {
    debugger;

    var regex = new RegExp(/^[a-zA-Z\s]+$/);
    var str = $('#e').val();
    if (regex.test(str)) {
        return true;
    }
    else {
        e.preventDefault();
        return false;
    }
}

    //const regex = /^[a-zA-Z]+$/;
    //if (!regex.test(e)) {
    //    return false;
    //}
    //else {
    //    return true;
    //}

  





