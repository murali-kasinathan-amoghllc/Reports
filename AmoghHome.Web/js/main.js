$(document).ready(function () {
    var input = $('.validate-input .input100');
    //var RootUrl = '@Url.Content("~/")';

    $('.validate-form').on('submit',function(){
        var isValid = true;
        $("#divErrorMsg").css("display", "none");
        for(var i=0; i<input.length; i++) {
            if(validate(input[i]) == false){
                showValidate(input[i]);
                isValid=false;
            }
        }
        if (isValid) {
            $(".validate-input,.input100").removeClass('alert-validate');
            var mail = $("#txtEmail").val();
            var pwd = $("#txtPassword").val();
            $.ajax({
                type: "POST",
                //url: '/Home/GetUserData',
                url: document.getElementById('hdnURL').value + "Home/GetUserData",
                //contentType: "application/json; charset=utf-8", 
                data: { emailId: mail, secret: pwd},
                //data: JSON.stringify('{"emailId":"' + $("#txtEmail").val() + '","secret":"' + $("#txtPassword").val() + '"}'),
                //data: '{"emailId":"' + $("#txtEmail").val() + '","secret":"' + $("#txtPassword").val() + '"}',
                dataType: "json",
                success: function (response) {
                    if (response == false) {
                        $("#divErrorMsg").css("display", "block");
                    }
                    else {
                        window.location = document.getElementById('hdnURL').value + "Home/ProjectsList";
                    }
                    //$("#dataDiv").html(result);
                },
                error: function (xhr, status, error) {
                }
            }); 
        }
        return false;
        });

            //$('.validate-form .input100').each(function(){
            //    $(this).focus(function(){
            //       hideValidate(this);
            //    });
    //});

    function validate (input) {
        if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if($(input).val().trim() == ''){
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();
        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();
        $(thisAlert).removeClass('alert-validate');
    }

    $("#btnLogOut").bind("click", function () {
        $.ajax({
            type: "POST",
            url: '/Home/LogOut',
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (response) {
              
            },
            error: function (xhr, status, error) {
            }
        }); 
    });
});



