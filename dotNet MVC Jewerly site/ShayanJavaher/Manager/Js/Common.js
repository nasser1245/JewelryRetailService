
$(function () {
//    $(".treeBox .header").each(function () {
//        $(this).next().slideToggle();

//    });

    $(".treeBox .header").click(function () {
        $(this).next().slideToggle();
    });

    $('.head').click(function () {
        $(this).next().Toggle();
    });
});