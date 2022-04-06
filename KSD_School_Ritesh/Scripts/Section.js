//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/SectionList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Room + '</td>';
                html += '<td>' + item.StaffId + '</td>';
                html += '<td>' + item.ClassId + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Id + ')">Edit</a> | <a href="#" onclick="Delete(' + item.Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            console.log(errormessage.responseText);
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
    var sectionObj = {
        Room: $('#room').val(),
        StaffId: $('#staff').val(),
        ClassId: $('#class').val(),
    };
    $.ajax({
        url: "/Home/SectionAdd",
        data: JSON.stringify(sectionObj),
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
function getbyID(sectionId) {
    $('#room').css('border-color', 'lightgrey');
    $('#class').css('border-color', 'lightgrey');
    $('#staff').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/SectionGetbyID/" + sectionId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#id').val(result.Id)
            $('#room').val(result.Room);
            $('#staff').val(result.StaffId);
            $('#class').val(result.ClassId);

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
    var sectionObj = {
        Id: $('#id').val(),
        Room: $('#room').val(),
        StaffId: $('#staff').val(),
        ClassId: $('#class').val(),
    };
    $.ajax({
        url: "/Home/SectionUpdate",
        data: JSON.stringify(sectionObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#id').val("");
            $('#room').val("");
            $('#class').val("");
            $('#staff').val("");
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
            url: "/Home/SectionDelete/" + ID,
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
    $('#id').val("");
    $('#room').val("");
    $('#staff').val("");
    $('#class').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#room').css('border-color', 'lightgrey');
    $('#staff').css('border-color', 'lightgrey');
    $('#class').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#room').val().trim() == "") {
        $('#room').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#room').css('border-color', 'lightgrey');
    }
    if ($('#staff').val().trim() == "") {
        $('#staff').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#staff').css('border-color', 'lightgrey');
    }
    if ($('#class').val().trim() == "") {
        $('#class').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#class').css('border-color', 'lightgrey');
    }
    return isValid;
}