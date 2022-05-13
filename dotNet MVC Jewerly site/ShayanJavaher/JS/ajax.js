function GetSubs(IdGroup,ddlSubs,gType,page) {
    //alert(IdGroup+ddlSubs+gType+page);
    if (IdGroup > 0) {
        var SubGroups = ddlSubs.get(0);
        SubGroups.options.length = 0;
        SubGroups.options[0] = new Option("در حال بارگزاری...", "-1");
        $.ajax({
            type: "POST",
            url: page + "/GetSubs",
            data: "{IdGroup:" + IdGroup + ",gType:" + gType + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg) {
                SubGroups.options.length = 0;
                SubGroups.options[0] = new Option("انتخاب کنید", "-1");
                
                $.each(msg.d, function(index, item) {
                    SubGroups.options[SubGroups.options.length] = new Option(item.Display, item.Value);
                });
            },
            error: function() {
                showMsg('warning','بروز خطای نا مشخص.لطفا لحظاتی بعد مجددا سعی نمایید!');
            }
        });
    }
    else {
        SubGroups.options.length = 0;
        SubGroups.options[0] = new Option("ــــــــ", "-1");
    }
}