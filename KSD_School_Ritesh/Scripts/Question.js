
$(document).ready(function () {
    loadData();

});

function addRadioButtonsForm(arr) {

    const a = document.getElementsByClassName('a')[0];

    let form = document.createElement('form');
    form.setAttribute('name', 'test');
    form.setAttribute('id', 'form');

    for (element of arr) {
        let radio = document.createElement('input');
        radio.setAttribute('type', 'radio');
        radio.setAttribute('id', element);
        radio.setAttribute('value', element);
        radio.setAttribute('name', 'Options');
        form.appendChild(radio);
   
        let label = document.createElement('label');
        label.setAttribute('for', element);
        label.textContent = element;
        form.appendChild(label);

        let linebreak = document.createElement('br');
        form.appendChild(linebreak);
    }

    a.appendChild(form);
}

var allEnt;

function loadData() {
    $.ajax({
        url: "/Home/Listque",
        type: "GET",
        
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            var numberofQue = 0;
            var html = '';
            const params = new Proxy(new URLSearchParams(window.location.search), {
                get: (searchParams, prop) => searchParams.get(prop),
            });
            let value = params.qno
            var res = result.entries();
            for (var entry of result) {
                allEnt = entry;


                if (entry.que_no == value && entry.exam_id == sessionStorage.getItem("Examid")) {

                    let arr = [entry.Option[0], entry.Option[1], entry.Option[2], entry.Option[3]];

                    html += '<tr>';
                    html += '<td id = "que_id" style="display: none;" >' + entry.que_id + '</td>';
                    html += '<td>' + entry.que_no + '</td>';
                    html += '<td id = "exam_id" style="display:none;">' + entry.exam_id + '</td>';
                    html += '<td>' + entry.que_text + '</td>';               
                    html += '<tr>';
                    html += '</tr>';
                    html += '</tr>';
                    
                    addRadioButtonsForm(arr);
                    break
                    
                }               
            }

            console.log(sessionStorage.getItem("Examid"));

            $('.tbody').html(html);
     
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

//Add Data Function   
function Addans() {
    var studentidd = privilage;
    var empObj = {
        Que_id: allEnt.que_id,
        exam_id: allEnt.exam_id,
        Student_id: studentidd,
        Selected_ans: $("input[type='radio'][name='Options']:checked").val(),
    };
    console.log(empObj);
    $.ajax({
        url: "/Home/Addans",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
           
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
            $('#Student_id').val(result.Student_id);
            $('#exam_id').val(result.exam_id);
            $('#que_text').val(result.que_text);
            $('#Option').val(result.Option);
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

