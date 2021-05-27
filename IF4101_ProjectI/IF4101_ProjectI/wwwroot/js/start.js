$(document).ready(function () {
    $('#escalation').DataTable({
        "scrollY": "25vh",
        "scrollCollapse": true,
    });
    LoadDataEF();
    GetCoursesEF();
    document.getElementById('incorrect').style.display = 'none';
    document.getElementById('incorrect2').style.display = 'none';
    document.getElementById('incorrect3').style.display = 'none';
    document.getElementById('incorrect4').style.display = 'none';
    document.getElementById('incorrect5').style.display = 'none';
    document.getElementById('incorrect6').style.display = 'none';
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