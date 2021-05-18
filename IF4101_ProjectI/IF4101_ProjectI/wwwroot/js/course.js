function AddCourse() {
    $.ajax({
        url: "/Student/GetEF", //MVC NORMAL
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var nuevo = '<img src="images/tst-image1.jpg" class="img-responsive" alt="">';

            $('#coursesContainer').append(nuevo);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function togglePopupAddCourse() {
    document.getElementById("AddCourseSection").classList.toggle("active");
}