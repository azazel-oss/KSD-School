//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});
function splitdata(item) {
    let option = item;

    var fields = option.split(',');

    var option1 = fields[0];
    var option2 = fields[1];
    var option3 = fields[2];
    var option4 = fields[3];

    return fields;

}


//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/Listque",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                
                html += '<tr>';
                html += '<td style="display: none;">' + item.que_id + '</td>';
                html += '<td>' + item.que_no + '</td>';
                html += '<td style="display:none;">' + item.exam_id + '</td>';
                html += '<td>' + item.que_text + '</td>';
                //html += '<td>' + item.Option + '</td>';
                html += '<tr>';
                html += '<td>' + splitdata(item.Option)[0]; + '</td>';
                html += '</tr>';
                html += '<tr>';
                html += '<td>' + splitdata(item.Option)[1]; + '</td>';
                html += '</tr>';
                html += '<tr>';
                html += '<td>' + splitdata(item.Option)[2]; + '</td>';
                html += '</tr>';
                html += '<tr>';
                html += '<td>' + splitdata(item.Option)[3]; + '</td>';
                html += '</tr>';
                html += '<tr>';
                html += '</tr>';
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
        que_id: $('#que_id').val(),
        que_no: $('#que_no').val(),
        exam_id: $('#exam_id').val(),
        que_text: $('#que_text').val(),
        Option: $('#Option').val(),
       
    };
    $.ajax({
        url: "/Home/Addque",
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
function queGetbyID(EmpID) {
    $('#que_no').css('border-color', 'lightgrey');
    $('#exam_id').css('border-color', 'lightgrey');
    $('#que_text').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/queGetbyID/" + EmpID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#que_id').val(result.que_id);
            $('#que_no').val(result.que_no);
            $('#exam_id').val(result.exam_id);
            $('#que_text').val(result.que_text);
            $('#Option').val(result.Option);
           

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
        que_id: $('#que_id').val(),
        que_no: $('#que_no').val(),
        exam_id: $('#exam_id').val(),
        que_text: $('#que_text').val()
    };
    $.ajax({
        url: "/Home/Updateque",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#que_id').val("");
            $('#que_no').val("");
            $('#exam_id').val("");
            $('#que_text').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Deleteque(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/Deleteque/" + ID,
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
    $('#que_id').val("");
    $('#que_no').val("");
    $('#exam_id').val("");
    $('#que_text').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#que_no').css('border-color', 'lightgrey');
    $('#exam_id').css('border-color', 'lightgrey');
    $('#que_text').css('border-color', 'lightgrey');

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#que_no').val().trim() == "") {
        $('#que_no').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#que_no').css('border-color', 'lightgrey');
    }
    if ($('#exam_id').val().trim() == "") {
        $('#exam_id').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#exam_id').css('border-color', 'lightgrey');
    }
    if ($('#que_text').val().trim() == "") {
        $('#que_text').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#que_text').css('border-color', 'lightgrey');
    }
    
    return isValid;
}