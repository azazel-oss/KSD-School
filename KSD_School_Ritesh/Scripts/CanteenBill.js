$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/ShowCanteenBills",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.ItemCode + '</td>';
                html += '<td>' + item.Student_id + '</td>';
                html += '<td>' + item.Quantity + '</td>';
                html += '<td>' + item.Amount + '</td>';
                html += '<td>' + item.BillingDate + '</td>';
                html += '<td><a href="#" onclick="return getBillByID(' + item.Id + ')">Edit</a> | <a href="#" onclick="DeleteBill(' + item.Id + ')">Delete</a></td>';
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
        var billObj = {
        ItemCode: $('#code').val(),
        Quantity: $('#quantity').val(),
        Student_id: $('#student').val(),
        Amount: $('#amount').val(),
        BillingDate: $('#dob').val(),
    };
    console.log(billObj);
    $.ajax({
        url: "/Home/AddBill",
        data: JSON.stringify(billObj),
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
function getBillByID(billID) {
    $('#code').css('border-color', 'lightgrey');
    $('#quantity').css('border-color', 'lightgrey');
    $('#student').css('border-color', 'lightgrey');
    $('#amount').css('border-color', 'lightgrey');
    $('#dob').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/getBillByID/" + billID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            $('#Id').val(result.Id);
            $('#code').val(result.ItemCode);
            $('#quantity').val(result.Quantity);
            $('#student').val(result.Student_id);
            $('#amount').val(result.Amount);
            $('#dob').val(result.BillingDate);

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
    var billObj = {
        Id: $('#Id').val(),
        ItemCode: $('#code').val(),
        Quantity: $('#quantity').val(),
        Student_id: $('#student').val(),
        Amount: $('#amount').val(),
        BillingDate: $('#dob').val(),
    };
    console.log(billObj);
    $.ajax({
        url: "/Home/UpdateBill",
        data: JSON.stringify(billObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Id').val("");
            $('#code').val("");
            $('#quantity').val("");
            $('#student').val("");
            $('#amount').val("");
            $('#dob').val("");
            
        },
        error: function (errormessage) {

            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function DeleteBill(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/DeleteBill/" + ID,
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
    $('#code').val("");
    $('#quantity').val("");
    $('#student').val("");
    $('#amount').val("");
    $('#dob').val("");

    
    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#code').css('border-color', 'lightgrey');
    $('#quantity').css('border-color', 'lightgrey');
    $('#student').css('border-color', 'lightgrey');
    $('#amount').css('border-color', 'lightgrey');
    $('#dob').css('border-color', 'lightgrey');

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#code').val().trim() == "") {
        $('#code').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#code').css('border-color', 'lightgrey');
    }
    if ($('#quantity').val().trim() == "") {
        $('#quantity').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#quantity').css('border-color', 'lightgrey');
    }
    if ($('#student').val().trim() == "") {
        $('#student').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#student').css('border-color', 'lightgrey');
    }
    if ($('#amount').val().trim() == "") {
        $('#amount').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#amount').css('border-color', 'lightgrey');
    }
    if ($('#dob').val().trim() == "") {
        $('#dob').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#dob').css('border-color', 'lightgrey');
    }
    return isValid;
}