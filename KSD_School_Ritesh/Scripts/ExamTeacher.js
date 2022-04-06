$(document).ready(function () {
    $('#question-details').empty();
    $('#session_type').change(() => {
        populateQuestions();
    });
    $('#class_type').change(() => {
        populateQuestions();
    });
    $('#subject_type').change(() => {
        populateQuestions();
    });
});

function populateQuestions() {
    $('#question-details').html("")
    let session_id = $('#session_type option:selected').val();
    let class_id = $('#class_type option:selected').val();
    let subject_id = $('#subject_type option:selected').val();

    if (session_id.startsWith('Select') || class_id.startsWith('Select') || subject_id.startsWith('Select')) {
        return;
    }
    exam_id = 0;
    const examDataObj = {
        session_id,
        class_id,
        subject_id
    }

    $.ajax({
        url: '/Home/GetExamIdFromData',
        data: JSON.stringify(examDataObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            exam_id = +result
            if (exam_id === 0) {
                $('#new-question__btn').attr('disabled', true);
                $('#btn-text').attr('hidden', false);
                return;
            }
            else {
                $('#question-details').empty();
                $('#btn-text').attr('hidden', true);
                $('#new-question__btn').attr('disabled', false);

                $.ajax({
                    url: '/Home/GetQuestionsToDisplay',
                    data: JSON.stringify({ examId: exam_id }),
                    type: "POST",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        
                        console.log(i);
                        let html = '';
                        for (const [index, question] of result.entries()) {
                            html += '<div class="card mb-3"><div class="card-body">';
                            html += `<h5 class="card-title">${index + 1}. ${question.Question.que_text}</h5>`;
                            html += `<div class="row"><div class="col-3 text-success">🟢 ${question.CorrectOption.option_.toUpperCase()}  ✓</div>`
                            for (option of question.IncorrectOptions) {
                                html += `<div class="col-3 text-danger">🔴 ${option.option_.toUpperCase()}  ✖</div>`
                            }
                            html += '</div></div></div>';
                        }
                        $('#question-details').html(html)
                    },
                    error: function (errormessage) {
                        alert(errormessage.responseText)
                        console.log(errormessage.responseText)
                    }
                })
            }
        },
        error: function (errormessage) {
            console.log(errormessage)
            alert(errormessage.responseText);
        }
    })
}

function AddQuestion() {
    const questionObj = {
        que_no: $('#question_no').val().trim(),
        que_text: $('#question_text').val().trim(),
        exam_id: exam_id,
    };

    const optionList = [];
    optionList.push({
        is_correct: true,
        option_: $('#correct_option').val().trim()
    })
    optionList.push({
        is_correct: false,
        option_: $('#incorrect1').val().trim()
    })
    optionList.push({
        is_correct: false,
        option_: $('#incorrect2').val().trim()
    })
    optionList.push({
        is_correct: false,
        option_: $('#incorrect3').val().trim()
    })

    $.ajax({
        url: "/Home/AddQuestion",
        data: JSON.stringify({
            "q": JSON.stringify(questionObj),
            "o": JSON.stringify(optionList)
        }),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            populateQuestions();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
            console.log(errormessage.responseText)
        }
    });
}

function clearTextBox() {
    $('#question_id').val("");
    $('#question_no').val("");
    $('#question_text').val("");
    $('#correct_option').val("");
    $('#incorrect1').val("");
    $('#incorrect2').val("");
    $('#incorrect3').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#question_no').css('border-color', 'lightgrey');
    $('#question_text').css('border-color', 'lightgrey');

}

function validate() {
    var isValid = true;
    if ($('#question_no').val().trim() == "") {
        $('#question_no').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#question_no').css('border-color', 'lightgrey');
    }
    if ($('#question_text').val().trim() == "") {
        $('#question_text').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#question_text').css('border-color', 'lightgrey');
    }
    if ($('#correct_option').val().trim() == "") {
        $('#correct_option').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#correct_option').css('border-color', 'lightgrey');
    }
    if ($('#incorrect1').val().trim() == "") {
        $('#incorrect1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#incorrect1').css('border-color', 'lightgrey');
    }
    if ($('#incorrect2').val().trim() == "") {
        $('#incorrect2').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#incorrect2').css('border-color', 'lightgrey');
    }
    if ($('#incorrect3').val().trim() == "") {
        $('#incorrect3').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#incorrect3').css('border-color', 'lightgrey');
    }
    return isValid;
}

function addExamTerm() {
    let session_id = $('#new_session_type option:selected').val();
    let class_id = $('#new_class_type option:selected').val();
    let subject_id = $('#new_subject_type option:selected').val();

    if (session_id.startsWith('Select') || class_id.startsWith('Select') || subject_id.startsWith('Select')) {
        $('#modal-alert').html('<div class="alert alert-danger">Please fill all the fields!!!</div>')
        return;
    }

    let exam_id = 0;
    const examDataObj = {
        session_id,
        class_id,
        subj_id: subject_id
    }
    $.ajax({
        url: '/Home/GetExamIdFromData',
        data: JSON.stringify({
            session_id,
            class_id,
            subject_id
        }),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            exam_id = +result
            console.log(exam_id)
            if (exam_id !== 0) {
                $('#modal-alert').html('<div class="alert alert-danger">This examination has already been created.</div>')
                return;
            }

            $.ajax({
                url: '/Home/AddExamTerm',
                data: JSON.stringify(examDataObj),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    $('#exam-term-modal').modal('hide');
                    console.log("Exam Added")
                },
                error: function (errorMessage) {
                    console.log("Exam not added")
                    console.log(errorMessage.responseJSON);
                    alert(errorMessage.responseJSON)
                }
            })

        } //TODO: Add success fields;
    });
}