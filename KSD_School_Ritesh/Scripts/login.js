

function login() {
    
    var empObj = {
        Username: $('#Username').val(),
        Password: $('#Password').val()

    };

    console.log(empObj);

    $.ajax({
        url: "/Auth/Login",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
        },
        error: function (errormessage) {
            console.log('Error')
            alert(errormessage.responseText);
        }
    });
}
