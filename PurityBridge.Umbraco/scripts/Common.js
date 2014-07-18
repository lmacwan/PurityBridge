$(document).ready(function () {
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

    if ($(".benefits").length == 0) {
        $(".grid-row").first().css("margin-top", "60px");
    }

    $(".accordian").accordion({
        collapsible: true,
        active: false,
        icons: { "header": "fa fa-plus", "activeHeader": "fa fa-minus" },
        heightStyle: "100%"
    });
});

var quickSearchForm = $('.quick-search-form');
quickSearchForm.css('top', -473);

$('#quick-search-switcher').unbind('click');
$('#quick-search-switcher').on('click', function () {
    var top = 0;
    if ($(".header").hasClass("header-shrink")) {
        top = -44;
    }
    if ($("#quick-search").hasClass("quick-search-visible")) {
        quickSearchForm.animate({ 'top': top - 473 });
    } else {
        quickSearchForm.animate({ 'top': top  + 90});
    }
});