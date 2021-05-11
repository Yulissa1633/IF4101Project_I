// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
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

$('#buttonRegister').click(function () {
    $('input[type="text"]').val('');
    $('input[type="password"]').val('');
    $('input[type="email"]').val('');
});

$('#buttonLog').click(function () {
    $('input[type="text"]').val('');
    $('input[type="password"]').val('');
});

function togglePopup() {
    document.getElementById("RegisterSection").classList.toggle("active");
}

function togglePopupEditProfile() {
    document.getElementById("EditProfileSection").classList.toggle("active");
}

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
                html += '<td><a href="#" onclick="return Get(' + item.id + ')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
            });
            $('.tbody').html(html);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}

function Log() {

    var param = {
        user: $('#name2').val(),
        password: $('#password2').val()
    };

    $.ajax({
        url: "/Home/Get",
        data: JSON.stringify(param),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
                $.each($('a.disabled'), function (index, value) {
                    $(this).css('pointer-events', 'auto');
                    $(this).css('cursor', 'auto');
                });
                document.getElementById('incorrect5').style.display = 'none';
                document.getElementById('incorrect6').style.display = 'none';
            }
            else {
                document.getElementById('incorrect5').style.display = 'block';
                document.getElementById('incorrect6').style.display = 'block';
            }
        },
        error: function (errorMessage) {
            document.getElementById('incorrect5').style.display = 'block';
            document.getElementById('incorrect6').style.display = 'block';
        }
    });
   
}

function Add() {

    var student = {
        user: $('#user').val(),
        name: $('#name').val(),
        email: $('#email').val(),
        password: $('#password').val()
        

    };

    $.ajax({
        url: "/Home/Insert",
        data: JSON.stringify(student),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
                alert("Ingresa");
                document.getElementById('incorrect').style.display = 'none';
                document.getElementById('incorrect2').style.display = 'none';
                document.getElementById('incorrect3').style.display = 'none';
                document.getElementById('incorrect4').style.display = 'none';
            }
            else {
                document.getElementById('incorrect').style.display = 'block';
                document.getElementById('incorrect2').style.display = 'block';
                document.getElementById('incorrect3').style.display = 'block';
                document.getElementById('incorrect4').style.display = 'block';
            }
        },
        error: function (errorMessage) {
            document.getElementById('incorrect').style.display = 'block';
            document.getElementById('incorrect2').style.display = 'block';
            document.getElementById('incorrect3').style.display = 'block';
            document.getElementById('incorrect4').style.display = 'block';
        }
    });
}
