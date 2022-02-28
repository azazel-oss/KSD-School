$(document).ready(function () {
    $('#session_type').change(() => {
        $('#fee-details').empty();
        $('#session_label').text($('#session_type option:selected').text());
        let html = '';
        for (const fee of feeList) {

            if (fee.SessionId === +$('#session_type option:selected').val()) {
                console.log(fee)
                if ($('#fee-details').is(':empty')) {
                    html += '<thead><tr>';
                    html += '<th>Fee Type</th>';
                    html += '<th>Amount</th>';
                    html += '<th>Duration</th>';
                    html += '<th>Comments</th>';
                    html += '</tr></thead>';
                    $('#fee-details').html(html);
                    html += '<tbody>';

                }

                html += `<tr><td>${fee.FeeType}</td>`;
                html += `<td>${fee.FeeAmount}</td>`;
                html += `<td>${fee.Duration}</td>`;
                html += `<td>${fee.comments}</td></tr>`;
            }
        }
        html += '</tbody>';
        $('#fee-details').html(html);
    });
});
function AddFee() {
    const path = $(location).attr('pathname').split('/');
    const feeObj = {
        FeeType: $('#fee_type').val().trim(),
        Student_id: path[path.length - 1],
        SessionId: $('#session_type').val().trim(),
        FeeAmount: $('#FeeAmount').val().trim(),
        Duration: $('#duration').val().trim(),
        comments: $('#comment').val().trim(),
    };

    console.log(feeObj)
    $.ajax({
        url: "/Home/feAdd",
        data: JSON.stringify(feeObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function AddSession() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var sessionObj = {
        sessionName: $('#session').val(),
        startDate: $('#startDate').val(),
    };
    $.ajax({
        url: "/Home/AddSession",
        data: JSON.stringify(sessionObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function validate() {
    var isValid = true;
    if ($('#session').val().trim() == "") {
        $('#session').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#session').css('border-color', 'lightgrey');
    }
    if ($('#startDate').val().trim() == "") {
        $('#startDate').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#startDate').css('border-color', 'lightgrey');
    }
    return isValid;
}