function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}


function showMsg(imgClass, text) {
   
    var isOk = (imgClass != 'warning');
    var color = isOk ? 'green' : 'red';
    if (text == "err") { text = "بروز خطای نا مشخص.لطفا لحظاتی بعد مجددا سعی نمایید!"; }
    $("#imgAlert").addClass(imgClass);
    $(".text span").css('color', color);
    $(".text span").html(text);
    $('html, body').animate({ scrollTop: '100px' }, 500);
    $("#alert").fadeIn(800);
}



function querySt(q) {
    var url = window.location.search.substring(1);
    var arr = url.split("&");
    var result = "";

    for (i = 0; i < arr.length; i++) {
        ft = arr[i].split("=");
        if (ft[0] == q) {
            result = ft[1];
        }
    }

    if (result == "")
        return ""
    else
        return result;
}

function HighLightRequired() {
    $('.required').append('<span>*</span>');
}

function overlay(status, bgcolor, addContent, width, height, bgcontentcolor, loadingMessage,outByClick) {
    if (status == 1) {
        var docHeight = $(document).height();
        $("body").append("<div id='overlay'></div>");
        $("#overlay")
          .height(docHeight)
          .css({
              'display': 'none',
              'opacity': 0.4,
              'position': 'absolute',
              'top': 0,
              'left': 0,
              'background-color': bgcolor,
              'width': '100%',
              'z-index': 5000
          })
          .fadeIn()
          .click(function () {
              if (outByClick == true)
                  overlay(0, '');
          });

          if (addContent == 1)
            $('body').append("<div class='overlay_content'>" + (loadingMessage != undefined ? loadingMessage : "") + "</div>");

        $(".overlay_content")
                .css({
                    'width': width != null ? width : $(".overlay_content").width(),
                    'height': height != null ? height : "auto"
                });
        
        $(".overlay_content")
                .css({
                    'top': $(window).scrollTop() + 100,
                    'left': (($(window).width() - $(".overlay_content").width()) / 2) + $(window).scrollLeft(),
                    'background-color': bgcontentcolor
                });
        
    } else {
        $("#overlay,.overlay_content,.message").fadeOut(function () { $("#overlay,.overlay_content,.message").remove(); });
    }
}

function Message(status, caption, text) {
    if (status == 1) {
        overlay(1, "black", 0);
        $("body").append("<div class='message'><div class='header'>" + caption + "<span class='close'>X</span></div><div class='contain'><div>" + text + "</div></div></div>");
        $('.message .close').click(function () { overlay(0, '') });
    } else {
        overlay(0, '', 0);
        $('.message').fadeOut();
    }
}

function validateLength(text, curLength) {
    if (text != "undefined" && text.length > curLength)
        return true;
    else {
        showMsg('warning', 'لطفا مقدار معتبری وارد نمایید');
        return false;
    }
}

function Popup(src, name, width, height) {
    width = typeof (width) != 'undefined' ? width : 500;
    height = typeof (height) != 'undefined' ? height : 400;

    if (src != "undefined" && src != "")
        myRef = window.open(src, name, 'left=' + (screen.width - width) / 2 + ',top=100,scrollbars=1,toolbar=0,resizable=1,width=' + width + ',height=' + height);
}

function fileUpload(form, div_id, type) {
    //alert(div_id+"*"+action_url+"*"+type);
    setParams(type);
    // Create the iframe...

    var iframe = document.createElement("iframe");
    iframe.setAttribute("id", "upload_iframe");
    iframe.setAttribute("name", "upload_iframe");
    iframe.setAttribute("width", "0");
    iframe.setAttribute("height", "0");
    iframe.setAttribute("border", "0");
    iframe.setAttribute("style", "width: 0; height: 0; border: none;");

    // Add to document...
    form.parentNode.appendChild(iframe);
    window.frames['upload_iframe'].name = "upload_iframe";

    iframeId = document.getElementById("upload_iframe");

    // Add event...
    var eventHandler = function () {

        if (iframeId.detachEvent)
            iframeId.detachEvent("onload", eventHandler);
        else
            iframeId.removeEventListener("load", eventHandler, false);

        // Message from server...
        if (iframeId.contentDocument) {
            content = iframeId.contentDocument.body.innerHTML;
        } else if (iframeId.contentWindow) {
            content = iframeId.contentWindow.document.body.innerHTML;
        } else if (iframeId.document) {
            content = iframeId.document.body.innerHTML;
        }

        if (content != '0') {
            if (document.getElementById(div_id)) {
                document.getElementById(div_id).style.visibility = 'visible';
                document.getElementById(div_id).style.display = 'block';
            }

            document.getElementById(div_id).innerHTML = "<img id='imgUpload' height='100px' alt='' onclick='openImage($(this).attr(\"src\"));' src='uploads/" + image_folder + "/" + content + "' /><a id='linkUpload' href='#' class='btnmain' onclick='RemoveUpload(" + type + ",true,false);return false'>حذف تصویر</a>";
            uName = content
        }
        else
            showMsg('warning', 'ارسال تصویر با خطا مواجه شد.');

        // Del the iframe...
        setTimeout('iframeId.parentNode.removeChild(iframeId);', 250);
    }

    if (iframeId.addEventListener)
        iframeId.addEventListener("load", eventHandler, true);
    if (iframeId.attachEvent)
        iframeId.attachEvent("onload", eventHandler);

    // Set properties of form...
    form.setAttribute("target", "upload_iframe");
    form.setAttribute("action", resource + "?isUpload=true");
    form.setAttribute("method", "post");
    form.setAttribute("enctype", "multipart/form-data");
    form.setAttribute("encoding", "multipart/form-data");

    // Submit the form...
    form.submit();
}

function ajaxReq(url) {
    $.ajax({
        url: url,
        //--------------for cross domain request
        xhrFields: {
            withCredentials: true
        },
        success: function (data) {
            return data;
        },
        error: function () {
            showMsg('warning', 'بروز خطای نا مشخص.لطفا لحظاتی بعد مجددا سعی نمایید!');
            return "";
        }
    });
}
