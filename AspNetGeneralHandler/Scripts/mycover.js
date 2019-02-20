$(function () {
    $(window).resize(function () {
        if ($(".holder").css("display") == "block") {
            showCover();
        }
    });
});
function showCover() {
    closeCover();
    var height = ($(window).height() - 300) / 2;
    var width = ($(window).width() - 200) / 2;
    var $holder = $(".holder").css({ "top": height, "left": width, "display": "block" });
    $("body").css("background-color", "gray");
    $("body").append($holder);
}
function closeCover() {
    $(".holder").css("display", "none");
    $("body").css("background-color", "white");
}