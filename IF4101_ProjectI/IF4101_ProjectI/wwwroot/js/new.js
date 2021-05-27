var news;

function AddNew() {

    news = {
        title: $('#newsTitle').val(),
        date: $('#newsDate').val(),
        description: $('#desciption').val(),
        author: $('#authorName').val(),   
        image: null,   

    };

    $.ajax({
        url: "/New/AddUpdateNew",
        data: JSON.stringify(news),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var nuevo = '<div class="panel-body"> ' +
            '<ul class="list-group">' +
                '<li class="list-group-item">' +
                '<div class="row">' +
                '<div class="col-xs-2 col-md-1">' +
                '<img src="https://bootdey.com/img/Content/avatar/avatar1.png" class="img-circle img-responsive img-user" alt="" />' +
                '</div>' +
                '<div class="col-xs-10 col-md-11">' +
                '<div>' + news.title +
                '<div class="mic-info">' +
                'Por: ' + news.author + ', ' + news.date +
                '</div>' +
                '</div>' +
                '<div class="comment-text">' + news.description + '</div>' +
                '<div class="action">' +
                            '<button type="button" class="btn btn-primary btn-xs" title="Edit"><span class="glyphicon glyphicon-pencil"></span></button><button type="button" class="btn btn-danger btn-xs" title="Delete">Eliminar</button></div></div ></div ></li ></ul ></div>';

            $('#newsContainer2').append(nuevo);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function DeleteNew() {

    $.ajax({
        url: "/Home/DeleteNew/",
        type: "GET",
        data: { value: news.id },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

           
        },
        error: function (errorMessage) {
            
        }
    });

}