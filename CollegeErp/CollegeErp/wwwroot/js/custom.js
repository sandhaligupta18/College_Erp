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

function IsName(name) {
    debugger;
    const regex = /^[a-zA-Z]+$/;
    if (!regex.test(name)) {
        return false;
    }
    else {
        return true;
    }

}

