$(document).ready(function () {
    $('#Session_list').change(() => displaydata());
    $('#Student_list').change(() => displaydata());
});
function displaydata() {
        $('#marks_Details').empty();
        $('#Session_Id_update').text($('#Session_list option:selected').text());
        let html = '';
        for (const fee of Alldata) {

            if (fee.Session_Id == $('#Session_list option:selected').val() && fee.Student_Id == $('#Student_list option:selected').val()) {
                if ($('#marks_Details').is(':empty')) {
                    html += '<thead><tr>';
                    html += '<th>ID</th>';
                    html += '<th>Student Name</th>';
                    html += '<th>Session</th>';
                    html += '<th>Subject</th>';
                    html += '<th>Marks</th>';
                    html += '</tr></thead>';
                    $('#marks_Details').html(html);
                    html += '<tbody>';
                    console.log(Alldata);

                }
                html += `<tr><td>${fee.id}</td>`;
                html += `<td>${fee.Student_Id.trim()}</td>`;
                html += `<td>${fee.Session_Id.trim()}</td>`;
                html += `<td>${fee.Subject_Id.trim()}</td>`;
                html += `<td>${fee.marks.trim()}</td>`;
                console.log(fee.marks);

            }
        }
        html += '</tbody>';
        $('#marks_Details').html(html);
    

}
//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/Showmarks",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.Student_Id + '</td>';
                html += '<td>' + item.Session_Id + '</td>';
                html += '<td>' + item.Subject_Id + '</td>';
                html += '<td>' + item.marks + '</td>';
                html += '<td><a href="#" onclick="getbyID(' + item.id + ')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
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
        Student_Id: $('#Student_Id').val(),        
        Session_Id: $('#Session_Id').val(),
        Subject_Id: $('#Subject_Id').val(),
        marks: $('#marks').val()
        
    };
    $.ajax({
        url: "/Home/Addmarks",
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

    $('#id').css('border-color', 'lightgrey');
    $('#Student_Id').css('border-color', 'lightgrey');
    $('#Session_Id').css('border-color', 'lightgrey');
    $('#Subject_Id').css('border-color', 'lightgrey');
    $('#marks').css('border-color', 'lightgrey');
    
    $.ajax({
        url: "/Home/MarksGetbyID/" + EmpID,
        type: "GET",

        contentType: "application/json;charset=UTF-8",
        dataType: "json",

        success: function (result) {

            $('#id').val(result.id);
            $('#Student_Id').text(result.Student_Id);
            $('#Session_Id').val(result.Session_Id);
            $('#Subject_Id').val(result.Subject_Id);
            $('#update_Marks').text(result.update_Marks);
            

            $('#updateMyModal').modal('show');
            $('#btnupdate').show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//function for updating employee's record  
function Update() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}
    var empObj = {
        id: $('#id').val(),        
        marks: $('#marks_update').val()
        
    };
    $.ajax({
        url: "/Home/Updatemarks",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#updateMyModal').modal('hide');
            $('#id').val("");
            $('#marks').val("");
           
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
            url: "/Home/Deletemarks/" + ID,
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
    $('#Student_Id').val("");
    $('#Session_Id').val("");
    $('#Subject_Id').val("");
    $('#marks').val("");
    $('#btnupdate').hide();
    $('#btnAdd').show();
    $('#Student_Id').css('border-color', 'lightgrey');
    $('#session_Id').css('border-color', 'lightgrey');
    $('#Subject_Id').css('border-color', 'lightgrey');
    $('#marks').css('border-color', 'lightgrey');
    

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#Student_Id').val().trim() == "") {
        $('#Student_Id').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Student_Id').css('border-color', 'lightgrey');
    }
    if ($('#Session_Id').val().trim() == "") {
        $('#Session_Id').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Session_Id').css('border-color', 'lightgrey');
    }
    if ($('#Subject_Id').val().trim() == "") {
        $('#Subject_Id').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Subject_Id').css('border-color', 'lightgrey');
    }
    if ($('#marks').val().trim() == "") {
        $('#marks').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#marks').css('border-color', 'lightgrey');
    }
    
    return isValid;
}