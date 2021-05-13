$('#buttonRegister').click(function () {
    $('input[type="text"]').val('');
    $('input[type="password"]').val('');
    $('input[type="email"]').val('');
});

$('#buttonLog').click(function () {
    $('input[type="text"]').val('');
    $('input[type="password"]').val('');
});

$('#buttonUpdateProfile').click(function () {
    $('input[type="text"]').val('');
    $('input[type="radio"]').val('');
    $('input[type="file"]').val('');
    $('input[type="date"]').val('');
});

function togglePopup() {
    document.getElementById("RegisterSection").classList.toggle("active");
}

var param;

function Log() {

    param = {
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

                LoadUserEF();
                
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

function LoadUserEF() {

    var param2 = {
        user: param.user,
        password: param.password
    };

    
    $.ajax({
        url: "/User/GetUserProfile", //MVC NORMAL
        type: "GET",
        data: JSON.stringify(param2),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {               
                var boton = document.getElementById("userProfile");
            boton.innerHTML = result.user;
                var boton = document.getElementById("nameProfile");
            boton.innerHTML = result.name;
                var boton = document.getElementById("emailProfile");
            boton.innerHTML = result.email;
                var boton = document.getElementById("dateProfile");
            boton.innerHTML = result.date;
                var boton = document.getElementById("genderProfile");
            boton.innerHTML = result.gender;                 
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}

var student;

function Add() {

    student = {
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
                document.getElementById('incorrect').style.display = 'none';
                document.getElementById('incorrect2').style.display = 'none';
                document.getElementById('incorrect3').style.display = 'none';
                document.getElementById('incorrect4').style.display = 'none';
                CreateUser();
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

var userp

function CreateUser() {

    userp = {
        user: student.user,
        name: student.name,
        email: student.email,
        date: null,
        image: null,
        gender: null
    };

    $.ajax({
        url: "/User/Insert",
        data: JSON.stringify(userp),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
               
            }
            else {
               
            }
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function UpdateUser() {

    var userp2 = {
        name: $('#nameUser').val(),
        user: $('#userP').val(),
        email: $('#emailUser').val(),
        date: $('#dateUser').val(),
        image: $('#image').val(),
        gender: null
    };

    $.ajax({
        url: "/User/Update",
        data: JSON.stringify(userp2),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
               
            }
            else {

            }
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}
