var currentTab;

$(document).ready(function () {
    $("#reloadCaptcha").click(function () {
        $.ajax({
            type: 'post',
            url: location.protocol + '//' + location.host + "/Accounting/getCaptchaReload",
            data: { date: Math.round(new Date().getTime() / 1000.0) },
            cache: false,
            dataType: "html",
            success: function (data) {
                $(".captcha .value").html(data.toString().toFaDigit());
                return false;
            }
        });
    });

    $("#loginusers").click(function () {
        overlay(1, 'black', 1, 649);
        $('.overlay_content').load(location.protocol + '//' + location.host + '/Home/Login', function () {
            $.ajax({
                type: 'post',
                url: location.protocol + '//' + location.host + "/Accounting/getCaptchaReload",
                data: { date: Math.round(new Date().getTime() / 1000.0) },
                cache: false,
                dataType: "html",
                success: function (data) {
                    $(".captcha .value").html(data.toString().toFaDigit());

                    $(".loginBox #UserName").focus();

                    $(".loginBox").keypress(function (event) {
                        if (event.which == 13) {
                            $(".loginBox #login").click();
                        }
                    });

                    return false;
                }
            });
        });
    });

    $(".RegisterWindow").click(function () {
        currentTab = $(this).attr("action");
        overlay(1, 'black', 1);
        //$('.overlay_content').html('<iframe width="590" height="590" frameborder="0" scrolling="no" src="ShowOptionList.aspx?User=' + querySt("User") + '&Type=' + $(this).attr('option') + '"></iframe>');
        $('.overlay_content').load(location.protocol + '//' + location.host + '/Asist', {},
        function () {
            $(".formTab .tab").click(function () {
                $(".formTab .tab").removeClass("active");
                $(".tabContent").removeClass("active");

                $(this).addClass("active");
                $("." + $(this).attr("id")).addClass("active");
            });
            $("#" + currentTab).addClass("active");
            $("." + currentTab).addClass("active");
        });
        return false;
    });
    
    $(".registerusers").click(function () {
        //var windowElement = $('#RegisterWindow');
        //windowElement.data('tWindow').center().open(); $("#alertgo2").slideUp(1);
        overlay(1, 'black', 1);
        $('.overlay_content').load(location.protocol + '//' + location.host + '/Home/Register #RegisterUser', {}, function () { });
        return false;
    });

    $("#forgot").click(
        function () {
            $("#forgoten").slideToggle(1000, "easeInOutBack");

        }
    );

    //////////////////////////////reset Click
    $("#reset").click(
        function () {
            $.getJSON(location.protocol + '//' + location.host + '/Accounting/Change', {
                UserName: $("#ForgotUserName").val(),
                Email: $("#ForgotEmail").val()
            },
         function (msg) {
             $.each(msg, function (index, item) {
                 if (item.log == "true") {
                     showMsg('accept', item.mess, "#alertgo1");


                 } else {
                     showMsg('warning', item.mess, "#alertgo1");
                 }
             });
         });

            $("#forgoten").slideUp(1000, "easeInOutBack");
            return false;
        }
    );
    
});

function signup() {
    if ($("#MyUserName").val().length < 6 ||
            $("#MyPassword").val().length < 6 || ($("#MyPassword").val() != $("#RepeatPassword").val()) ||
            $("#UsersName").val().length < 2 || $("#Family").val().length < 2
            ) {
        showMsg('warning', "لطفا به موارد گفته شده دقت نمایید.", "#alertgo2");
        return;
    }

    $.getJSON(location.protocol + '//' + location.host + '/Accounting/SignUp', { UserName: $("#MyUserName").val(),
        Password: $("#MyPassword").val(),
        RepeatPassword: $("#RepeatPassword").val(),
        UsersName: $("#UsersName").val(),
        Family: $("#Family").val(),
        MelliCode: $("#MelliCode").val(),
        Phone: $("#Phone").val(),
        Email: $("#Email").val(),
        IsNewsMan: 0, //$('#IsNewsMan').is(':checked')
        NewsTypeID: $("#NewsTypeS").val()

    }, function (msg) {

        $.each(msg, function (index, item) {
            if (item.log == "true") {
                showMsg('accept', item.mess, "#alertgo2");

            } else {
                showMsg('warning', item.mess, "#alertgo2");
            }
        });

    });

    // return false;
}

function sendContact() {
    if (
            $("#namecontact").val().length < 1 ||
            $("#Tellcontact").val().length < 7 ||
            $("#Emailcontact").val().length < 6 ||
            $("#Subjectcontact").val().length < 1
        ) {
        showMsg('warning', "مقادیر را به صورت صحیح وارد نمایید.", "#alertgo2");
        return;
    }

    $.getJSON(location.protocol + '//' + location.host + '/Home/SendContactForm', {
        namecontact: $("#namecontact").val(),
        Tellcontact: $("#Tellcontact").val(),
        Emailcontact: $("#Emailcontact").val(),
        Subjectcontact: $("#Subjectcontact").val(),
        textcontact: $("#textcontact").val()

    }, function (msg) {
        $.each(msg, function (index, item) {
            if (item.log == "true") {
                showMsg('accept', item.mess, "#alertgo2");

            } else {
                showMsg('warning', item.mess, "#alertgo2");
            }
        });

    });

    return false;
}

function login() {
    $.getJSON(location.protocol + '//' + location.host + '/Accounting/Login', { UserName: $("#UserName").val(), Password: $("#Password").val(), userCaptcha: $("#userCaptcha").val() }, function (msg) {
        $.each(msg, function (index, item) {
            if (item.log == "true") {
                // alert("as");
                $("#usersing").attr("myval", "yes");
                $("#usersing").html("yes");
                showMsg('accept', item.mess, "#alertgo1");

                if (item.role == "1" || item.role == "2" || item.role == "3" || item.role == "6") {
                    $.cookie('LoadSubCatNews', 'ok', { expires: 1 });
                    window.location = location.protocol + '//' + location.host + "/admin";
                }
                else
                    window.location = location.protocol + '//' + location.host + "/home";


            } else {
                //                    $.getJSON(location.protocol + '//' + location.host + '/Accounting/GetCaptchaReload', {}, function (msg) {
                //                        $.each(msg, function (index, item) {
                //                            $("#imgCaptcha").attr("src", item.img);
                //                        });
                //                    });
                $.ajaxSetup({
                    cache: false
                });

                $.ajax({
                    type: 'post',
                    url: location.protocol + '//' + location.host + "/Accounting/getCaptchaReload",
                    data: { date: Math.round(new Date().getTime() / 1000.0) },
                    cache: false,
                    dataType: "html",
                    success: function (data) {
                        $(".captcha .value").html(data.toString().toFaDigit());
                        return false;
                    }
                });



                showMsg('warning', item.mess, "#alertgo1");
            }
        });
    });
    var src = "";

    //  $.getJSON(location.protocol + '//' + location.host + '/Accounting/getcaptcha', {}, function () { });
    return false;
}