//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Father_name + '</td>';
                html += '<td>' + item.Father_contact + '</td>';
                html += '<td>' + item.Student_id + '</td>';
                html += '<td>' + item.Emergency_Contact + '</td>';
                html += '<td>' + item.Address + '</td>';
                html += '<td>' + item.Class_id + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Student_id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.Student_id + ')">Delete</a></td>';
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
        Name: $('#Name').val(),
        Father_name: $('#Father_name').val(),
        Father_contact: $('#Father_contact').val(),
        Emergency_Contact: $('#Emergency_Contact').val(),
        Address: $('#Address').val(),
        Class_id: $('#Class_id').val()
    };
    $.ajax({
        url: "/Home/Add",
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
    $('#Name').css('border-color', 'lightgrey');
    $('#Father_name').css('border-color', 'lightgrey');
    $('#Father_contact').css('border-color', 'lightgrey');
    $('#Emergency_Contact').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Class_id').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/getbyID/" + EmpID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Student_id').val(result.Student_id);
            $('#Name').val(result.Name);
            $('#Father_name').val(result.Father_name);
            $('#Father_contact').val(result.Father_contact);
            $('#Emergency_Contact').val(result.Emergency_Contact);
            $('#Adress').val(result.Address);
            $('#Class_id').val(result.Class_id);

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
        Name: $('#Name').val(),
        Father_name: $('#Father_name').val(),
        Father_contact: $('#Father_contact').val(),
        Emergency_Contact: $('#Emergency_Contact').val(),
        Address: $('#Address').val(),
        Class_id: $('#Class_id').val()
    };
    $.ajax({
        url: "/Home/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Student_id').val("");
            $('#Name').val("");
            $('#Father_name').val("");
            $('#Father_contact').val("");
            $('#Emergency_Contact').val("");
            $('#Address').val("");
            $('#Class_id').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/Delete/" + ID,
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
    $('#Name').val("");
    $('#Father_name').val("");
    $('#Father_contact').val("");
    $('#Emergency_Contact').val("");
    $('#Address').val("");
    $('#Class_id').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Father_name').css('border-color', 'lightgrey');
    $('#Father_contact').css('border-color', 'lightgrey');
    $('#Emergency_Contact').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Class_id').css('border-color', 'lightgrey');

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Father_name').val().trim() == "") {
        $('#Father_name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Father_name').css('border-color', 'lightgrey');
    }
    if ($('#Father_contact').val().trim() == "") {
        $('#Father_contact').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Father_contact').css('border-color', 'lightgrey');
    }
    if ($('#Emergency_Contact').val().trim() == "") {
        $('#Emergency_Contact').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Emergency_Contact').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    } if ($('#Class_id').val().trim() == "") {
        $('#Class_id').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Class_id').css('border-color', 'lightgrey');
    }
    return isValid;
}