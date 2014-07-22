$(document).ready(function () {

    // Active Menu-Item
    $("header .active").removeClass("active");
    var loc = window.location.href.toString().split('/');
    var controllerName = "";
    var i = 0;
    if (loc[i] == "http:" || loc[i] == "https:") {
        i = i + 2;
    }
    i++;
    controllerName = loc[i];
    $("header a[controller=" + controllerName + "]").addClass("active");
    $("#umbracoPreviewBadge").remove();
});

$(window).load(function () {
    $('#ui-datepicker-div').addClass('widget-calendar');
});