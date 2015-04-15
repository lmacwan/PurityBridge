function onDocumentReady() {

    var pageId = $('head meta[id=pageId]').attr('content');

    /* Right Choice Page */
    if (pageId == "2239") {
        $('body').restive({
            breakpoints: ['767', '1023', '1024', '1240', '1280', '1440', '1920', '10000'],
            classes: ['nb767', 'nb1023', 'nb1024', 'nb1240', 'nb1280', 'nb1440', 'nb1920', 'nb'],
            platform: 'all',
            force_dip: true
        });
    }
    else if (pageId == "2477" || pageId == "2482") {
        $('body').restive({
            breakpoints: ['567', '767', '1023', '1024', '1240', '1280', '1440', '1920', '10000'],
            classes: ['nb567', 'nb767', 'nb1023', 'nb1024', 'nb1240', 'nb1280', 'nb1440', 'nb1920', 'nb'],
            platform: 'all',
            force_dip: true
        });
    }
    else if (pageId == "2621") {
        $('body').restive({
            breakpoints: ['562', '685','965', '1023', '1190', '1240', '1280', '1440', '1920', '10000'],
            classes: ['nb562', 'nb685','nb965', 'nb1023', 'nb1024', 'nb1240', 'nb1280', 'nb1440', 'nb1920', 'nb'],
            platform: 'all',
            force_dip: true
        });
    }
    else if (pageId == "2000") {
        $('body').restive({
            breakpoints: ['567', '980', '10000'],
            classes: ['nb567', 'nb980', 'nb'],
            platform: 'all',
            force_dip: true
        });
    }
    else if (pageId == "1801") {
        $('body').restive({
            breakpoints: ['1230', '10000'],
            classes: ['nb1230','nb'],
            platform: 'all',
            force_dip: true
        });
    }
    else {
        $('body').restive({
            breakpoints: ['567', '626', '736', '980', '1024', '1240', '1280', '1440', '1920', '10000'],
            classes: ['nb567', 'nb626', 'nb320', 'nb768', 'nb1024', 'nb1240', 'nb1280', 'nb1440', 'nb1920', 'nb'],
            platform: 'all',
            force_dip: true
        });
    }

    BindSidebarClick();

    if (Object.prototype.toString.call(window.HTMLElement).indexOf('Constructor') > 0) {
        //Safari
        $('head').append($('<link rel="stylesheet" type="text/css" />').attr('href', '/Content/css/safari.css'));
    }

    $('#tuner label:first-child').prepend('<div>Width = ' + $(window).innerWidth() + '</div>');

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

    // beautify
    $('.beautify').find("article").each(function (i, e) {
        $(e).addClass("widget");
        $(e).find("h3").addClass("widget-title");
    });


    // Set Cols Width
    if ($('#page-content .vc_row-fluid').height() > $('#page-content .vc_row-fluid').children().first().height()) {
        var width = 0;
        var elementWidth = 0;
        $('#page-content .vc_row-fluid').children().each(function (i, e) {
            elementWidth = $(e).outerWidth() + parseInt($(e).css('margin-left').split('px')[0]);
            if (elementWidth + width >= $('#page-content .vc_row-fluid').width()) {
                $(e).css({ marginLeft: 0 });
                width = 0;
            } else {
                width = elementWidth + width;
            }
            $(e).css({ marginBottom: 30 });
            setMargin(e);
        });
    }

    $('.vc_parent').css('margin-left', 0);
    $('.photo-comaprisions-row li').first().css('margin-left', 0);

    $("#photo-tour.category .pic").each(function (i, e) {
        $(e).css('background', "url(" + $(e).find("img").attr("src") + ")");
    });

    $(".treatments-category .pic").each(function (i, e) {
        $(e).css('background', "url(" + $(e).find("img").attr("src") + ")");
    });

    $("#umbracoPreviewBadge").remove();
}

function OnWindowLoaded() {
    /* Sidebar */
    var pageId = $('head meta[id=pageId]').attr('content');
    if (pageId == "2000") {
        BindGridCallBack();
    }
}

function OnWindowResized() {
    /* Sidebar */
    var pageId = $('head meta[id=pageId]').attr('content');
    if (pageId == "2621") {
        BindSidebarClick();
    }
    else if (pageId == "2000") {
        BindGridCallBack();
    }

    /* Home Slider */
    var homeSliderTabs = $('.comments .box');
    homeSliderTabs.removeClass('home-slider').removeClass('large').removeClass('xlarge').removeClass('xxlarge');
    if ($(window).width() > 507) {
        homeSliderTabs.addClass('home-slider large');
    } else if ($(window).width() > 369) {
        homeSliderTabs.addClass('home-slider xlarge');
    } else if ($(window).width() > 319) {
        homeSliderTabs.addClass('home-slider xxlarge');
    } else {
        homeSliderTabs.addClass('home-slider');
    }
}

function handlePadding() {
    if (window.location.href.split('clinic/').length > 1) {
        var cols = $('.vc_row-fluid.spannedItems').children().length;
        var cols2 = $('.vc_row-fluid.spannedItems').children();
        $('.wpb_text_column.wpb_content_element').each(function (i, e) {

            if (i % cols == 0) {
                cols2.each(function (ai, ae) {
                    var len2 = 0;
                    var arr2 = $(ae).find('.wpb_text_column.wpb_content_element');
                    if (arr2.length >= i) {
                        len2 = $(arr2[i]).outerHeight();
                        if (len2 > $(e).outerHeight()) {
                            $(e).siblings('.leftwarpper').css({ paddingTop: len2 - $(e).outerHeight() });
                        } else {
                            $(arr2[i]).siblings('.leftwarpper').css({ paddingTop: $(e).outerHeight() - len2 });
                        }
                    }
                });
            } $(e).css('padding-bottom', '20px');
        });
    }
    $('.read-more').fancybox({
        autoDimensions: true
    });
}

function handleBlogPadding() {
    $('.wpb_text_column.wpb_content_element').each(function (i, e) {
        var arr2 = $(e).find('img');
        if ($(arr2).outerHeight() > $(e).outerHeight()) {
            $(e).css({ paddingBottom: $(arr2).outerHeight() - $(e).outerHeight() - 28 });
        }
    });
}

function setMargin(parent) {
    var width = 0;
    var elementWidth = 0;
    $(parent).find(".vc_child").first().css({ marginLeft: 0 });
    $(parent).children().each(function (i, e) {
        elementWidth = $(e).outerWidth() + parseInt($(e).css('margin-left').split('px')[0]);
        if (elementWidth + width >= $(parent).outerWidth()) {
            $(e).css({ marginLeft: 0 });
            width = 0;
        } else {
            width = elementWidth + width;
        }
    });
}

function getPhoto(photoId) {
    var pageId = $('head meta[id=pageId]').attr('content');
    if (pageId == "2000" && !($('section#photo-tour').first().hasClass('photo-tour-3'))) {
        return false;
    }
    else {
        $.ajax({
            url: "/gallery/photos/get/" + photoId,
            success: function (data) {
                $('#' + photoId).fancybox({
                    content: data,
                    autoSize: false,
                    height: 650,
                    width: 850
                });
                $('#' + photoId).click();
                $('.fancybox-content .pic .image-div').each(function (i, e) {
                    $(e).css({ lineHeight: $(e).parentsUntil('.pic').last().find('.before .mask').first().height() + 'px' });
                });
            },
            error: function (data) {
                alert("Error : " + data);
            }
        });
    }
}

function subscribeNewsLetter() {
    var subscribeEmail = $('.newsletter-form input[type=email]').first().val();
    if (subscribeEmail.length > 0) {
        var subscribeUrl = $('.newsletter-form form').attr('action');
        $.ajax({
            cache: false,
            url: subscribeUrl,
            type: "POST",
            data: { email: subscribeEmail },
            beforeSend: function () {
                $('.subscription-msg').text($("div#email-procssing").text());
            },
            success: function (data) {
                if (data.success == true) {
                    $('.subscription-msg').text($('div#email-procssing-success').text());
                } else {
                    $('.subscription-msg').text($('div#email-procssing-error').text());
                }
            }
        });
    }
}

function sendAppointmentEmail() {
    var fullName = $('#appointment-full-name').val();
    var phoneno = $('#appointment-phone').val();
    var email = $('#appointment-email').val();
    var message = $('#appointment-message').val();
    if (fullName != "" && email != "") {
        $.ajax({
            url: "/umbraco/surface/subscription/BookAppointment/",
            data: { fullName: fullName, phone: phoneno, email: email, message: message },
            success: function (data) {
                alert(data.message);
                if (data.success) {
                    $('#appointment-full-name').val("");
                    $('#appointment-phone').val("");
                    $('#appointment-email').val("");
                    $('#appointment-message').val("");
                }
            },
            error: function (data) {
                alert(data);
            }
        });
    }
    else {
        alert("Please provide your full name and email address.");
    }
    return false;
}

function sendContactUsEmail() {
    var fullName = $('#inquiry-form-name').val();
    var email = $('#inquiry-form-email').val();
    var message = $('#inquiry-form-message').val();
    if (fullName != "" && email != "") {
        $.ajax({
            url: "/umbraco/surface/subscription/ContactUs/",
            data: { fullName: fullName, email: email, message: message },
            success: function (data) {
                alert(data.message);
                if (data.success) {
                    $('#inquiry-form-name').val("");
                    $('#inquiry-form-email').val("");
                    $('#inquiry-form-message').val("");
                }
            },
            error: function (data) {
                alert(data);
            }
        });
    }
    else {
        alert("Please provide your full name and email address.");
    }
    return false;
}

function BindSidebarClick() {
    HandleColFullWidth();
    var sidebar = $('.sidebar');
    var triger = $('.more');
    if (sidebar != undefined) {
        var attr = sidebar.first().attr('data-sidebar');
        if (attr != "") {
            if (parseInt(attr) >= $(window).width()) {
                sidebar.first().addClass('active');
                triger.die('click');
                triger.addClass('pbElement').removeAttr('disabled');
                sidebar.first().css('padding-bottom', (sidebar.parent().outerHeight() - sidebar.outerHeight()) + 50);
                $('.more').live('click', function (e) {
                    var mainContent = $('main .grid-row .grid-col.grid-col-9').first();
                    var activeSidebar = $('.sidebar.active').first();
                    if (mainContent.outerHeight() < activeSidebar.outerHeight()) {
                        mainContent.css({ paddingBottom: (activeSidebar.height() - mainContent.height()) + 80 })
                    }
                    activeSidebar.toggleClass('opened');
                    activeSidebar.css({ marginLeft: -(activeSidebar.width() + 80), top: mainContent.position().top });
                });
            }
            else {
                triger.die('click');
                $('.sidebar').css('padding-bottom', '0').removeClass('active').removeClass('opened');
                triger.addClass('pbElement').attr('disabled', 'disabled');
            }
        }
    }
}

function HandleColFullWidth() {
    $('main .grid-row').each(function () {
        var width = $(this).width();
        $(this).find('.grid-col').each(function (i, e) {
            if (width >= $(e).outerWidth()) {
                $(e).removeClass('no-border');
            } else {
                $(e).addClass('no-border');
            }
        });
    });
}

function BindGridCallBack() {
    var bodyClasses = $('body').attr('class').split(' ');
    var target = $('section#photo-tour').first();
    if (bodyClasses.length > 0) {
        if (bodyClasses[0] == 'nb980') {
            target.removeClass('photo-tour-3').removeClass('photo-tour-1').addClass('photo-tour-2');
        }
        else if (bodyClasses[0] == 'nb567') {
            target.removeClass('photo-tour-3').removeClass('photo-tour-2').addClass('photo-tour-1');
        }
        else {
            target.removeClass('photo-tour-2').removeClass('photo-tour-1').addClass('photo-tour-3');
        }

        $('#photo-tour .grid').isotope({
            masonry: { columnWidth: $('#photo-tour .item').outerWidth() }
        });
    }
}

jQuery.cachedScript = function (url, options) {
    // Allow user to set any option except for dataType, cache, and url
    options = $.extend(options || {}, {
        dataType: "script",
        cache: true,
        url: url
    });
    // Use $.ajax() since it is more flexible than $.getScript
    // Return the jqXHR object so we can chain callbacks
    return jQuery.ajax(options);
};

$(window).load(function () {
    $('#ui-datepicker-div').addClass('widget-calendar');

    if (window.location.href.toString().indexOf('/blog') > 0) {
        handleBlogPadding();
    }
    else {
        handlePadding();
    }

    var i = $('#postPageBody img:not(.align)');
    if (i.length == 0) {
        $('#postPageBody .wpb_wrapper').hide();
    } else {
        i.first().hide();
        $('#postPageBody .wpb_wrapper img').attr('src', i.first().attr('src'));
    }

    if ($(window).width() <= 615) {
        $('footer .vc_span5').addClass('full-width');
    }
    else {
        $('footer .vc_span5').removeClass('full-width');
    }
});

