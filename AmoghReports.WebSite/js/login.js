$(document).ready(function () {

    $(document).bind('keydown', function (e) {
        if (e.which === 13) { 
            $('#btnLoginEvent').trigger('click');
        }
    });

    $("#btnLoginEvent").click(function () {
        $('#errorMsg').css('display', 'none');
        var mail = $("#txtEmail").val();
        var pwd = $("#txtPassword").val();

        if ((mail == "") || (pwd == "")) {
            $('#errorMsg').css('display', 'block');
            $('#errorMsg').text('Enter the Email/Password');
            return false;
        }
        else {
            if (IsEmail(mail) == false) {
                $('#errorMsg').css('display', 'block');
                $('#errorMsg').text('Enter the Valid Email');
                return false;
            }
        }

        $.ajax({
            type: "POST",
            url: document.getElementById('hdnURL').value + "Home/GetUserData",
            data: JSON.stringify({ emailId: mail, secret: pwd }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response == false) {
                    $("#errorMsg").css("display", "block");
                    $('#errorMsg').text('Invalid User');
                    return false;
                }
                else {
                    window.location = document.getElementById('hdnURL').value + "Home/ProjectsList";
                }
            },
            error: function (xhr, status, error) {
                //if (xhr.status == 500) {
                    window.location = document.getElementById('hdnURL').value + "Home/Error"; //redirect to Error url
                //}
            }
        });

    });

    function IsEmail(email) {
        var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (!regex.test(email)) {
            return false;
        } else {
            return true;
        }
    }

    $("#btnSignupEvent").click(function () {
        $('#errorMsg').css('display', 'none');
        var mail = $("#inputEmail").val();

        if (mail == "") {
            $('#errorMsg').css('display', 'block');
            $('#errorMsg').text('Enter the Email');
            return false;
        }
        else {
            if (IsEmail(mail) == false) {
                $('#errorMsg').css('display', 'block');
                $('#errorMsg').text('Enter the Valid Email');
                return false;
            }
        }

        $.ajax({
            type: "POST",
            url: document.getElementById('hdnURL').value + "Home/Signup",
            data: JSON.stringify({ emailId: mail }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                //if (response == false) {
                //    $("#errorMsg").css("display", "block");
                //    $('#errorMsg').text('Invalid User');
                //    return false;
                //}
                //else {
                //    window.location = document.getElementById('hdnURL').value + "Home/ProjectsList";
                //}
                if (response == true) {
                    alert("Please check your register Email. We'll send you a link to Create Account!");
                    window.location = document.getElementById('hdnURL').value + "Home/Login"; 
                }
            },
            error: function (xhr, status, error) {
                window.location = document.getElementById('hdnURL').value + "Home/Error"; //redirect to Error url
            }
        });

    });

    $("#btnResetEvent").click(function () {
        $('#errorMsg').css('display', 'none');
        var mail = $("#inputEmail").val();

        if (mail == "") {
            $('#errorMsg').css('display', 'block');
            $('#errorMsg').text('Enter the Email');
            return false;
        }
        else {
            if (IsEmail(mail) == false) {
                $('#errorMsg').css('display', 'block');
                $('#errorMsg').text('Enter the Valid Email');
                return false;
            }
        }

        $.ajax({
            type: "POST",
            url: document.getElementById('hdnURL').value + "Home/ForgetPasswordLink",
            data: JSON.stringify({ emailId: mail }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response == true) {
                    //$.dialog({
                    //    "body": "Please check your register Email. We'll send you a link to reset your password!",
                    //    "title": "Forget Password",
                    //    "show": true
                    //});
                    alert("Please check your register Email. We'll send you a link to reset your password!");
                    window.location = document.getElementById('hdnURL').value + "Home/Login"; 
                }
            },
            error: function (xhr, status, error) {
                window.location = document.getElementById('hdnURL').value + "Home/Error"; //redirect to Error url
            }
        });

    });
});