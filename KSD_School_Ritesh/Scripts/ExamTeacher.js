$(document).ready(function () {
    $('#session_type').change(() => {
        let html = '';
        for (const question of questionList) {

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

function populateQuestions() {
    let session_id = $('#session_type option:selected').val();
    let class_id = $('#class_type option:selected').val();
    let subject_id = $('#subject_type option:selected').val();

    if (!session_id || !class_id || !subject_id) {
        return;
    }
    exam_id = 0;
    const examDataObj = {
        sessionid,
        class_id,
        subject_id
    }
    // TODO: Add logic to get exam id corresponding to above ids and then use it for questions

    $.ajax({
        url: '/Home/GetExamIdFromData',
        data: JSON.stringify(examDataObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result)
        },
        error: function (errormessage) {
            console.log(errormessage)
            alert(errormessage.responseText);
        }
    })
    $('#question-details').empty();
    let html = '';
    for (const question of questionList) {

        if (question.exam_id === exam_id) {
            console.log(question)
            if ($('#question-details').is(':empty')) {
                html += '<thead><tr>';
                html += '<th>Question No.</th>';
                html += '<th>Question text</th>';
                html += '<th>Subject</th>';
                html += '<th>Class</th>';
                html += '<th>Session</th>';
                html += '</tr></thead>';
                $('#question-details').html(html);
                html += '<tbody>';
            }

            html += `<tr><td>${question.que_no}</td>`;
            html += `<td>${question.que_text}</td>`;
            html += `<td>${question.subject}</td>`;
            html += `<td>${question.class}</td>`;
            html += `<td>${question.session}</td></tr>`;
        }
    }
    html += '</tbody>';
    $('#question-details').html(html);

}
function AddQuestion() {
    const questionObj = {
        que_no: $('#question_no').val().trim(),
        que_text: $('#question_text').val().trim(),
        exam_id: exam_id,
    };

    console.log(questionObj)
    $.ajax({
        url: "/Home/AddQuestion",
        data: JSON.stringify(questionObj),
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

function clearTextBox() {
    $('#question_id').val("");
    $('#question_no').val("");
    $('#question_text').val("");
   
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#question_no').css('border-color', 'lightgrey');
    $('#question_text').css('border-color', 'lightgrey');
    
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