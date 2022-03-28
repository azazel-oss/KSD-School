//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
   });


//Load Data function  
function loadData() {
    $.ajax({
        url: "/Home/Listque",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            const params = new Proxy(new URLSearchParams(window.location.search), {
                get: (searchParams, prop) => searchParams.get(prop),
            });
            let value = params.qno
            console.log(value);
            var res = result.entries();
            for (var entry of result) {
                console.log(entry);
                if (entry.que_no == value) {
                    html += '<tr>';
                    html += '<td style="display: none;">' + entry.que_id + '</td>';
                    html += '<td>' + entry.que_no + '</td>';
                    html += '<td style="display:none;">' + entry.exam_id + '</td>';
                    html += '<td>' + entry.que_text + '</td>';
                    html += '<tr>';
                    html += '<input type="radio" name="' + entry.Option[0] + '"/>';
                    html += '</tr>';
                    html += '<tr>';
                    html += '<td>' + entry.Option[0]; + '</td>';
                    html += '</tr>';
                    html += '<tr>';
                    html += '<td>' + entry.Option[1]; + '</td>';
                    html += '</tr>';
                    html += '<tr>';
                    html += '<td>' + entry.Option[2]; + '</td>';
                    html += '</tr>';
                    html += '<tr>';
                    html += '<td>' + entry.Option[3]; + '</td>';
                    html += '</tr>';

                    html += '<tr>';

                    html += '</tr>';
                    html += '</tr>';
                    break
                }

            }
            //$.each(result, function (key, item) {
            //    html += '<tr>';
            //    //html += '<td style="display: none;">' + item.que_id + '</td>';
            //    //html += '<td>' + item.que_no + '</td>';
            //    //html += '<td style="display:none;">' + item.exam_id + '</td>';
            //    //html += '<td>' + item.que_text + '</td>';
            //    //html += '<tr>';
            //    //html += '<td>' + item.Option[0]; + '</td>';
            //    //html += '</tr>';
            //    //html += '<tr>';
            //    //html += '<td>' + item.Option[1]; + '</td>';
            //    //html += '</tr>';
            //    //html += '<tr>';
            //    //html += '<td>' + item.Option[2]; + '</td>';
            //    //html += '</tr>';
            //    //html += '<tr>';
            //    //html += '<td>' + item.Option[3]; + '</td>';
            //    html += '</tr>';

            //    html += '<tr>';

            //    html += '</tr>';
            //    //html += '</tr>';
            //    console.log(result);
            //});
            
        $('.tbody').html(html);
                
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

