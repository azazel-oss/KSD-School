$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/ListItem",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ItemCode + '</td>';
                html += '<td>' + item.ItemName + '</td>';
                html += '<td>' + item.Price + '</td>';
                html += '<td>' + item.RemainingQuantity + '</td>';
                html += '<td><a href="#" onclick="return GetItemByID(' + item.Id + ')">Edit</a> | <a href="#" onclick="DeleteItem(' + item.Id + ')">Delete</a></td>';
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
function AddItem() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var itemObj = {
        ItemCode: $('#code').val(),
        ItemName: $('#name').val(),
        Price: $('#price').val(),
        RemainingQuantity: $('#quantity').val(),
    };
    console.log(itemObj);
    $.ajax({
        url: "/Home/AddItem",
        data: JSON.stringify(itemObj),
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
function GetItemByID(itemId) {
    $('#code').css('border-color', 'lightgrey');
    $('#name').css('border-color', 'lightgrey');
    $('#price').css('border-color', 'lightgrey');
    $('#quantity').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/GetItemByID/" + itemId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#id').val(result.Id);
            $('#code').val(result.ItemCode);
            $('#name').val(result.ItemName);
            $('#price').val(result.Price);
            $('#quantity').val(result.RemainingQuantity);

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
function UpdateItem() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var itemObj = {
        Id: $('#id').val(),
        ItemCode: $('#code').val(),
        ItemName: $('#name').val(),
        Price: $('#price').val(),
        RemainingQuantity: $('#quantity').val(),
    };
    console.log(itemObj);
    $.ajax({
        url: "/Home/UpdateItem",
        data: JSON.stringify(itemObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#id').val("");
            $('#code').val("");
            $('#name').val("");
            $('#price').val("");
            $('#quantity').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function DeleteItem(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/DeleteItem/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                console.log(errormessage.responseText);
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#id').val("");
    $('#code').val("");
    $('#name').val("");
    $('#price').val("");
    $('#quantity').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#id').css('border-color', 'lightgrey');
    $('#code').css('border-color', 'lightgrey');
    $('#name').css('border-color', 'lightgrey');
    $('#price').css('border-color', 'lightgrey');
    $('#quantity').css('border-color', 'lightgrey');

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    //if ($('#id').val().trim() == "") {
    //    $('#id').css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $('#id').css('border-color', 'lightgrey');
    //}
    if ($('#code').val().trim() == "") {
        $('#code').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#code').css('border-color', 'lightgrey');
    }
    if ($('#name').val().trim() == "") {
        $('#name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#name').css('border-color', 'lightgrey');
    }
    if ($('#price').val().trim() == "") {
        $('#price').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#price').css('border-color', 'lightgrey');
    }
    if ($('#quantity').val().trim() == "") {
        $('#quantity').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#quantity').css('border-color', 'lightgrey');
    }
    
    return isValid;
}