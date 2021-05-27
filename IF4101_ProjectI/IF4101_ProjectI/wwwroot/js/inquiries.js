var inq;

function AddInq() {

    var days = document.getElementById('typeI');
    var selectedD = days.options[days.selectedIndex].text;

    inq = {
        inquirie1: $('#inquirie').val(),
        author: $('#authorNameI').val(),
        professor: $('#professorName').val(),
        type: selectedD,

    };

    $.ajax({
        url: "/Inquirie/Insert",
        data: JSON.stringify(inq),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var nuevo = '<div class="panel-body"> ' +
                '<ul class="list-group">' +
                '<li class="list-group-item">' +
                '<div class="row">' +
                '<div class="col-xs-2 col-md-1">' +
                '<img src="https://bootdey.com/img/Content/avatar/avatar2.png" class="img-circle img-responsive img-user" alt="" />' +
                '</div>' +
                '<div class="col-xs-10 col-md-11">' +
                '<div>' + inq.inquirie1 +
                '<div class="mic-info">' +
                'Por: ' + inq.author + ', ' + inq.type +
                '</div>' +
                '</div>' +
                '<div class="comment-text">' + inq.professor + '</div>' +
                '<div class="action">' +
                '</div></div></div></li></ul></div>';

            $('#InquiriesContainer2').append(nuevo);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}