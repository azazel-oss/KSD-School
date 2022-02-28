//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/TimetableList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.SectionId + '</td>';
                html += '<td>' + item.ClassId + '</td>';
                html += '<td>' + item.SubjectId + '</td>';
                html += '<td>' + item.StaffId + '</td>';
                html += '<td>' + item.Period + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Id + ')">Edit</a> | <a href="#" onclick="Delete(' + item.Id + ')">Delete</a></td>';
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
    var timetableObj = {
        SubjectId: $('#subject').val(),
        Period: $('#period').val(),
        SectionId: $('#section').val(),
        StaffId: $('#staff').val(),
        ClassId: $('#classname').val(),
    };
    $.ajax({
        url: "/Home/TimetableAdd",
        data: JSON.stringify(timetableObj),
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
function getbyID(timetableId) {
    $('#period').css('border-color', 'lightgrey');
    $('#classname').css('border-color', 'lightgrey');
    $('#staff').css('border-color', 'lightgrey');
    $('#subject').css('border-color', 'lightgrey');
    $('#section').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/TimetableGetbyID/" + timetableId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#id').val(result.Id)
            $('#period').val(result.Period);
            $('#staff').val(result.StaffId);
            $('#classname').val(result.ClassId);
            $('#subject').val(result.SubjectId);
            $('#section').val(result.SectionId);

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
    var timetableObj = {
        Id: $('#id').val(),
        SubjectId: $('#subject').val(),
        SectionId: $('#section').val(),
        Period: $('#period').val(),
        StaffId: $('#staff').val(),
        ClassId: $('#classname').val(),
    };
    $.ajax({
        url: "/Home/TimetableUpdate",
        data: JSON.stringify(timetableObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#id').val("");
            $('#period').val("");
            $('#classname').val("");
            $('#staff').val("");
            $('#subject').val("");
            $('#section').val("");
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
            url: "/Home/TimetableDelete/" + ID,
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
    $('#period').val("");
    $('#staff').val("");
    $('#classname').val("");
    $('#subject').val("");
    $('#section').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#period').css('border-color', 'lightgrey');
    $('#subject').css('border-color', 'lightgrey');
    $('#section').css('border-color', 'lightgrey');
    $('#staff').css('border-color', 'lightgrey');
    $('#classname').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#period').val().trim() == "") {
        $('#period').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#period').css('border-color', 'lightgrey');
    }
    if ($('#staff').val().trim() == "") {
        $('#staff').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#staff').css('border-color', 'lightgrey');
    }
    if ($('#subject').val().trim() == "") {
        $('#subject').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#subject').css('border-color', 'lightgrey');
    }
    if ($('#section').val().trim() == "") {
        $('#section').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#section').css('border-color', 'lightgrey');
    }
    if ($('#classname').val().trim() == "") {
        $('#classname').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#classname').css('border-color', 'lightgrey');
    }
    return isValid;
}