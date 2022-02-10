//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/staList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td style="display: none;">' + item.Staff_id + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.DOB + '</td>';
                html += '<td>' + item.DO_joining + '</td>';
                html += '<td>' + item.DO_relieve + '</td>';
                html += '<td>' + item.Is_teacher + '</td>';
                html += '<td>' + item.Is_retired + '</td>';
                html += '<td>' + item.Role + '</td>';
                html += '<td>' + item.Mobile_no + '</td>';
                html += '<td>' + item.Emergency_Contact + '</td>';
                html += '<td>' + item.Salary + '</td>';
                html += '<td>' + item.Department + '</td>';
                html += '<td><a href="#" onclick="return stagetbyID(' + item.Staff_id + ')">Edit</a> | <a href="#" onclick="staDelete(' + item.Staff_id + ')">Delete</a></td>';
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
        Staff_id: $('#Staff_id').val(),
        Name: $('#Name').val(),
        DOB: $('#DOB').val(),
        DO_joining: $('#DO_joining').val(),
        DO_relieve: $('#DO_relieve').val(),
        Emergency_Contact: $('#Emergency_Contact').val(),
        Address: $('#Address').val(),
        Mobile_no: $('#Mobile_no').val(),
        Department: $('#Department').val(),
        Salary: $('#Salary').val(),
        Is_teacher: $('input[name="Is_teacher"]:checked').val(),
        Is_retired: $('input[name="Is_retired"]:checked').val(),
        Role: $('#Role').val()
    };
    $.ajax({
        url: "/Home/staAdd",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('.modal-backdrop').remove();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function stagetbyID(EmpID) {
    $('#Name').css('border-color', 'lightgrey');
    $('#DOB').css('border-color', 'lightgrey');
    $('#DO_joining').css('border-color', 'lightgrey');
    $('#DO_relieve').css('border-color', 'lightgrey');
    $('#Emergency_Contact').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Role').css('border-color', 'lightgrey');
    $('#Is_retired').css('border-color', 'lightgrey');
    $('#Is_teacher').css('border-color', 'lightgrey');
    $('#Salary').css('border-color', 'lightgrey');
    $('#Department').css('border-color', 'lightgrey');
    $('#Mobile_no').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/stagetbyID/" + EmpID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Staff_id').val(result.Staff_id);
            $('#Name').val(result.Name);
            $('#DOB').val(result.DOB);
            $('#DO_joining').val(result.DO_joining);
            $('#Emergency_Contact').val(result.Emergency_Contact);
            $('#Address').val(result.Address);
            $('#DO_relieve').val(result.DO_relieve);
            $('#Is_retired').val(result.Is_retired);
            $('#Is_teacher').val(result.Is_teacher);
            $('#Department').val(result.Department);
            $('#Mobile_no').val(result.Mobile_no);
            $('#Role').val(result.Role);
            $('#Salary').val(result.Salary);

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
        Staff_id: $('#Staff_id').val(),
        Name: $('#Name').val(),
        DOB: $('#DOB').val(),
        DO_joining: $('#DO_joining').val(),
        Emergency_Contact: $('#Emergency_Contact').val(),
        Address: $('#Address').val(),
        Is_teacher: $('input[name="Is_teacher"]:checked').val(),
        Is_retired: $('input[name="Is_retired"]:checked').val(),
        Salary: $('#Salary').val(),
        Mobile_no: $('#Mobile_no').val(),
        DO_relieve: $('#DO_relieve').val(),
        Role: $('#Role').val(),
        Department: $('#Department').val()
    };
    $.ajax({
        url: "/Home/staUpdate",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Staff_id').val("");
            $('#Name').val("");
            $('#DOB').val("");
            $('#DO_joining').val("");
            $('#Emergency_Contact').val("");
            $('#Address').val("");
            $('#DO_relieve').val("");
            $('#Is_teacher').val("");
            $('#Is_retired').val("");
            $('#Salary').val("");
            $('#Role').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function staDelete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/staDelete/" + ID,
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
    $('#Staff_id').val("");
    $('#Name').val("");
    $('#DOB').val("");
    $('#DO_joining').val("");
    $('#Emergency_Contact').val("");
    $('#Address').val("");
    $('#DO_relieve').val("");
    $('#Is_teacher').val("");
    $('#Is_retired').val("");
    $('#Salary').val("");
    $('#Role').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#DOB').css('border-color', 'lightgrey');
    $('#DO_joining').css('border-color', 'lightgrey');
    $('#Emergency_Contact').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Salary').css('border-color', 'lightgrey');
    $('#Is_retired').css('border-color', 'lightgrey');
    $('#Is_teacher').css('border-color', 'lightgrey');
    $('#DO_relieve').css('border-color', 'lightgrey');
    $('#Role').css('border-color', 'lightgrey');

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
    if ($('#DOB').val().trim() == "") {
        $('#DOB').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DOB').css('border-color', 'lightgrey');
    }
    if ($('#DO_joining').val().trim() == "") {
        $('#DO_joining').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DO_joining').css('border-color', 'lightgrey');
    }
    if ($('#Emergency_Contact').val().trim() == "") {
        $('#Emergency_Contact').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Emergency_Contact').css('border-color', 'lightgrey');
    }
    if ($('#Role').val().trim() == "") {
        $('#Role').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Role').css('border-color', 'lightgrey');
    }
    if ($('#Salary').val().trim() == "") {
        $('#Salary').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Salary').css('border-color', 'lightgrey');
    }
    if ($('#DO_relieve').val().trim() == "") {
        $('#DO_relieve').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DO_relieve').css('border-color', 'lightgrey');
    }
    if ($('#Department').val().trim() == "") {
        $('#Department').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Department').css('border-color', 'lightgrey');
    }
    if ($('#Mobile_no').val().trim() == "") {
        $('#Mobile_no').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Mobile_no').css('border-color', 'lightgrey');
    }
    return isValid;
}