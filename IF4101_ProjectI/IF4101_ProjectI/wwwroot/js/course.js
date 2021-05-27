var course;

function AddCourse() {

    var hours = document.getElementById('schedule1');
    var selectedH = hours.options[hours.selectedIndex].text;

    var days = document.getElementById('schedule2');
    var selectedD = days.options[days.selectedIndex].text;

    course = {
        id: $('#courseId').val(),
        name: $('#courseName').val(),
        schedule: selectedH + " " + selectedD,
        semester: $('#courseSemester').val(),
        description: $('#courseDescription').val(),
        
    };

    $.ajax({
        url: "/Course/Insert",
        data: JSON.stringify(course),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var nuevo = '<p>' + '' +'</p><div id="addedCourse" class="my_scroll_div"><img id="wall" src="images/course-img.jpg" class="img-responsive" alt="">'+
                '<h4 id = "cId"> ' + course.id + '</h4><h4 id = "cName">' + course.name + '</h4><h4 id = "cName">Ciclo:  ' + course.semester +'</h4><span><i class="fa fa-clock-o"></i>' + ' ' + selectedH + '</span>'
                + ' ------------ ' + '<span><i class="fa fa-calendar"></i>' + ' ' + selectedD + '</span><p>' + course.description + '</p>'+
                '<button id = "buttonDeleteCourse" type = "submit" name = "delete" onclick = "DeleteCourse()" class="submit-btn form-control" >Eliminar</button></div> '; 

            $('#coursesContainer').append(nuevo);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function DeleteCourse() {

    $.ajax({ 
        url: "/Course/DeleteP/",
        type: "GET",
        data: { value: course.id },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
          
           
        },
        error: function (errorMessage) {
          
        }
    });

}

function togglePopupAddCourse() {
    document.getElementById("AddCourseSection").classList.toggle("active");
}