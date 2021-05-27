$(document).ready(function () {
    $('#escalation').DataTable({
        "scrollY": "25vh",
        "scrollCollapse": true,
    });
    LoadDataEF();
    GetCoursesEF();
    GetNews();
    GetInqs();
    document.getElementById('incorrect').style.display = 'none';
    document.getElementById('incorrect2').style.display = 'none';
    document.getElementById('incorrect3').style.display = 'none';
    document.getElementById('incorrect4').style.display = 'none';
    document.getElementById('incorrect5').style.display = 'none';
    document.getElementById('incorrect6').style.display = 'none';
});

$.each($('a.disabled'), function (index, value) {
    $(this).css('pointer-events', 'none');
    $(this).css('cursor', 'not-allowed');
});

function LoadDataEF() {
    $.ajax({
        url: "/Student/GetEF", //MVC NORMAL
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.user + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.email + '</td>';               
            });
            $('.tbody').html(html);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}

//MÉTODO QUE JALE CURSOS DE LA BASE DE DATOS
function GetCoursesEF() {

    var count;

    $.ajax({
        url: "/Course/GetEF", //MVC NORMAL
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $.each(result, function (key, item) {
                var nuevo = '<p>' + '' + '</p><div id="addedCourse" class="my_scroll_div"><img id="wall" src="images/course-img.jpg" class="img-responsive" alt="">' +
                    '<h4 id = "cId"> ' + item.id + '</h4><h4 id = "cName">' + item.name + '</h4><h4 id = "cName">Ciclo:  ' + item.semester + '</h4><span><i class="fa fa-clock-o"></i>' + ' ' + item.schedule + '</span>'
                    + ' ------------ ' + '<span><i class="fa fa-calendar"></i>' + ' ' + item.schedule + '</span><p>' + item.description + '</p>' +
                    '<button id = "buttonDeleteCourse" type = "submit" name = "delete" onclick = "DeleteCourse()" class="submit-btn form-control" >Eliminar</button></div> ';

                $('#coursesContainer').append(nuevo);
            });
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }

    });

    $.ajax({
        url: "/Student/GetEF", //MVC NORMAL
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $.each(result, function (key, item) {
                const cantidad = $('').val();

                for (var i = 1; i <= cantidad; i++) {
                    var nuevo = '';

                    $('').append(nuevo);
                }
            });
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
        
    });

}

//MÉTODO QUE JALE NOTICIAS DE LA BASE DE DATOS
function GetNews() {

    var count;

    $.ajax({
        url: "/New/GetAllNews", 
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $.each(result, function (key, item) {
                var nuevo = '<div class="panel-body">' +
                    '<ul class="list-group">' +
                    '<li class="list-group-item">' +
                    '<div class="row">' +
                    '<div class="col-xs-2 col-md-1">' +
                    '<img src="https://bootdey.com/img/Content/avatar/avatar1.png" class="img-circle img-responsive img-user" alt="" />' +
                    '</div>' +
                    '<div class="col-xs-10 col-md-11">' +
                    '<div>'+item.title +
                    '<div class="mic-info">' +
                    'Por: ' + item.author + ', '+ item.date+
                    '</div>' +
                    '</div>' +
                    '<div class="comment-text">'+ item.description +'</div>' +
                    '<div class="action">' +
                    '<button type="button" class="btn btn-primary btn-xs" title="Edit"><span class="glyphicon glyphicon-pencil"></span></button><button type="button" class="btn btn-danger btn-xs" title="Delete">Eliminar</button></div></div ></div ></li ></ul ></div > ';

                $('#newsContainer2').append(nuevo);
            });
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }

    });

}

//MÉTODO QUE JALE CONSULTAS DE LA BASE DE DATOS
function GetInqs() {

    var count;

    $.ajax({
        url: "/Inquirie/GetEF",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $.each(result, function (key, item) {
                var nuevo = '<div class="panel-body">' +
                    '<ul class="list-group">' +
                    '<li class="list-group-item">' +
                    '<div class="row">' +
                    '<div class="col-xs-2 col-md-1">' +
                    '<img src="https://bootdey.com/img/Content/avatar/avatar2.png" class="img-circle img-responsive img-user" alt="" />' +
                    '</div>' +
                    '<div class="col-xs-10 col-md-11">' +
                    '<div>' + item.inquirie1 +
                    '<div class="mic-info">' +
                    'Por: ' + item.author + ', ' + item.type +
                    '</div>' +
                    '</div>' +
                    '<div class="comment-text">' + item.professor + '</div>' +
                    '<div class="action">' +
                    '</div></div></div></li></ul></div> ';

                $('#InquiriesContainer2').append(nuevo);
            });
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }

    });

}