// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
        $('#escalation').DataTable({
            "scrollY": "25vh",
            "scrollCollapse": true,
        });
});

$.each($('a.disabled'), function (index, value) {
    $(this).css('pointer-events', 'none');
    $(this).css('cursor', 'not-allowed');
});



function togglePopup() {
    document.getElementById("RegisterSection").classList.toggle("active");
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
                alert("Ingresa");
                $.each($('a.disabled'), function (index, value) {
                    $(this).css('pointer-events', 'auto');
                    $(this).css('cursor', 'auto');
                });
            }
            else {
                alert("No ingresa");
            }
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
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
            //aca recibo el resultafo del backend (datos,objetos,mensajes)
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}
