//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/feList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Fee_id + '</td>';
                html += '<td>' + item.Transaction_id + '</td>';
                html += '<td>' + item.Amount + '</td>';
                html += '<td>' + item.Student_id + '</td>';
                html += '<td>' + item.Amount_pending + '</td>';
                html += '<td>' + item.Duration + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Fee_id + ')">Edit</a> | <a href="#" onclick="Delete(' + item.Fee_id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        Student_id: $('#Student_id').val(),
        Transaction_id: $('#Transaction_id').val(),
        Amount: $('#Amount').val(),
        Amount_pending: $('#Amount_pending').val(),
        Duration: $('#Duration').val(),
        Fee_id: $('#Fee_id').val()
    };
    $.ajax({
        url: "/Home/feAdd",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getbyID(EmpID) {
    $('#Transaction_id').css('border-color', 'lightgrey');
    $('#Amount').css('border-color', 'lightgrey');
    $('#Amount_pending').css('border-color', 'lightgrey');
    $('#Duration').css('border-color', 'lightgrey');
    $('#Fee_id').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/fegetbyID/" + EmpID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Student_id').val(result.Student_id);
            $('#Transaction_id').val(result.Transaction_id);
            $('#Amount').val(result.Amount);
            $('#Amount_pending').val(result.Amount_pending);
            $('#Adress').val(result.Duration);
            $('#Fee_id').val(result.Fee_id);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        Student_id: $('#Student_id').val(),
        Transaction_id: $('#Transaction_id').val(),
        Amount: $('#Amount').val(),
        Amount_pending: $('#Amount_pending').val(),
        Duration: $('#Duration').val(),
        Fee_id: $('#Fee_id').val()
    };
    $.ajax({
        url: "/Home/feUpdate",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Student_id').val("");
            $('#Transaction_id').val("");
            $('#Amount').val("");
            $('#Amount_pending').val("");
            $('#Duration').val("");
            $('#Fee_id').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/feDelete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#Student_id').val("");
    $('#Transaction_id').val("");
    $('#Amount').val("");
    $('#Amount_pending').val("");
    $('#Duration').val("");
    $('#Fee_id').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Transaction_id').css('border-color', 'lightgrey');
    $('#Amount').css('border-color', 'lightgrey');
    $('#Amount_pending').css('border-color', 'lightgrey');
    $('#Duration').css('border-color', 'lightgrey');
    $('#Fee_id').css('border-color', 'lightgrey');

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    
    if ($('#Transaction_id').val().trim() == "") {
        $('#Transaction_id').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Transaction_id').css('border-color', 'lightgrey');
    }
    if ($('#Amount').val().trim() == "") {
        $('#Amount').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Amount').css('border-color', 'lightgrey');
    }
    if ($('#Amount_pending').val().trim() == "") {
        $('#Amount_pending').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Amount_pending').css('border-color', 'lightgrey');
    }
    if ($('#Duration').val().trim() == "") {
        $('#Duration').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Duration').css('border-color', 'lightgrey');
    }
    return isValid;
}