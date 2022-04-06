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
                html += '<td>' + item.FeeType + '</td>';
                html += '<td>' + item.FeeFeeAmount + '</td>';
                html += '<td>' + item.Student_id + '</td>';
                html += '<td>' + item.SessionId + '</td>';
                html += '<td>' + item.Duration + '</td>';
                html += '<td>' + item.comments + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Fee_id + ')">Edit</a> | <a href="#" onclick="Delete(' + item.Fee_id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            console.log(errormessage.responseText)
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
        SessionId: $('#SessionId').val(),
        FeeAmount: $('#FeeAmount').val(),
        comments: $('#comments').val(),
        Duration: $('#Duration').val(),
        Fee_id: $('#Fee_id').val(),
        FeeType: $('#FeeType').val()
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
    $('#Student_id').css('border-color', 'lightgrey');
    $('#SessionId').css('border-color', 'lightgrey');
    $('#FeeAmount').css('border-color', 'lightgrey');
    $('#comments').css('border-color', 'lightgrey');
    $('#Duration').css('border-color', 'lightgrey');
    $('#FeeType').css('border-color', 'lightgrey');
    $('#Fee_id').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/fegetbyID/" + EmpID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Student_id').val(result.Student_id);
            $('#SessionId').val(result.SessionId);
            $('#FeeAmount').val(result.FeeAmount);
            $('#comments').val(result.comments);
            $('#Duration').val(result.Duration);
            $('#FeeType').val(result.FeeType);
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
        SessionId: $('#SessionId').val(),
        FeeAmount: $('#FeeAmount').val(),
        comments: $('#comments').val(),
        Duration: $('#Duration').val(),
        FeeType: $('#FeeType').val(),
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
            $('#SessionId').val("");
            $('#FeeAmount').val("");
            $('#comments').val("");
            $('#Duration').val("");
            $('#FeeType').val("");
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
    $('#SessionId').val("");
    $('#FeeAmount').val("");
    $('#comments').val("");
    $('#Duration').val("");
    $('#Fee_id').val("");
    $('#FeeType').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#FeeAmount').css('border-color', 'lightgrey');
    $('#comments').css('border-color', 'lightgrey');
    $('#Duration').css('border-color', 'lightgrey');
    $('#Fee_id').css('border-color', 'lightgrey');
    $('#FeeType').css('border-color', 'lightgrey');

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    
    if ($('#Student_id').val().trim() == "") {
        $('#Student_id').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Student_id').css('border-color', 'lightgrey');
    }
    if ($('#FeeAmount').val().trim() == "") {
        $('#FeeAmount').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FeeAmount').css('border-color', 'lightgrey');
    }
    if ($('#comments').val().trim() == "") {
        $('#comments').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#comments').css('border-color', 'lightgrey');
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