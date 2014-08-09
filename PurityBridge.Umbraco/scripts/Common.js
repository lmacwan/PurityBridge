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

    // Set Cols Width
    if ($('.treatments-row').height() > $('.vc_row-fluid').children().first().height()) {
        var width = 0;
        var elementWidth = 0;
        $('.treatments-row').children().each(function (i, e) {
            elementWidth = $(e).outerWidth() + parseInt($(e).css('margin-left').split('px')[0]);
            if (elementWidth + width >= $('.vc_row-fluid').outerWidth()) {
                $(e).css({ marginLeft: 0 });
                width = 0;
            } else {
                width = elementWidth + width;
                $(e).css({ marginBottom: 30 });
            }
        });
    }

    $("#umbracoPreviewBadge").remove();
});

$(window).load(function () {
    $('#ui-datepicker-div').addClass('widget-calendar');
});