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
    studentId = $('#Student_id').val();
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
            sessionStorage.setItem("Examid", exam_id);
           
        
            if (exam_id === 0) {
                $('#new-question__btn').attr('disabled', true);
                $('#btn-text').attr('hidden', false);
                return;
            }
            else {
                $('#question-details').empty();
                $('#btn-text').attr('hidden', true);
                $('#new-question__btn').attr('disabled', false);

            //    $.ajax({
            //        url: '/Home/GetQuestionsToDisplay',
            //        data: JSON.stringify({ examId: exam_id }),
            //        type: "POST",
            //        contentType: "application/json;charset=utf-8",
            //        dataType: "json",
            //        success: function (result) {
                        
                        
            //            let html = '';
                        
            //            $('#question-details').html(html)
            //        },
            //        error: function (errormessage) {
            //            alert(errormessage.responseText)
            //            console.log(errormessage.responseText)
            //        }
            //    })
            }
        },
        error: function (errormessage) {
            console.log(errormessage)
            alert(errormessage.responseText);
        }

    })
    
}




