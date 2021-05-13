$(document).ready(function () {
    $('#escalation').DataTable({
        "scrollY": "25vh",
        "scrollCollapse": true,
    });
    LoadDataEF();
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