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

$(window).load(function () {
    $('.quick-search-form').css("top", 88 - parseFloat($('#quick-search').css("height").split("px")[0]));
    $('#quick-search-switcher').unbind('click');
    $('#quick-search-switcher').on('click', function () {
        switcherClick();
    });
});

function switcherClick() {
    var sliderHeight = parseFloat($('#slider').css("height").split("px")[0]);
    var searchHeight = parseFloat($('#quick-search').css("height").split("px")[0]);
    var extraPadding = 0;
    if (sliderHeight > searchHeight) {
        extraPadding = ((sliderHeight - searchHeight) / 2);
    }
    //else if (sliderHeight < searchHeight) {
    //    extraPadding = ((searchHeight - sliderHeight) / 2);
    //}
    $(".quick-search-form").find(".container").find(".grid-row").first().css('paddingTop', extraPadding);
    $(".quick-search-form").find(".container").find(".grid-row").last().css('paddingBottom', extraPadding);
    if ($("#quick-search").hasClass("quick-search-visible")) {
        if ($(".header").hasClass("header-shrink")) {
            $('.quick-search-form').animate({ 'top': 44-parseFloat($('.quick-search-form').css("height").split("px")[0]) });
        }
        else {
            $('.quick-search-form').animate({ 'top': 88-parseFloat($('.quick-search-form').css("height").split("px")[0]) });
        }
        $("#quick-search").removeClass("quick-search-visible");
    } else {
        if ($(".header").hasClass("header-shrink")) {
            $('.quick-search-form').animate({ 'top': 44 });
        }
        else {
            $('.quick-search-form').animate({ 'top': 88 });
        }
        $("#quick-search").addClass("quick-search-visible");
    }
}