function onDocumentReady() {
	
	if( Object.prototype.toString.call(window.HTMLElement).indexOf('Constructor') > 0) {
		//Safari
		$('head').append( $('<link rel="stylesheet" type="text/css" />').attr('href', '/Content/css/safari.css') );
	}
    

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
    $.ajax({
        url: "/gallery/photos/get/"+photoId,
        success: function (data) {
            $('#' + photoId).fancybox({
                content: data,
                autoSize: false,
                height: 650,
                width: 850
            });
            $('#' + photoId).click();
		$('.fancybox-content .pic .image-div').each(function(i, e) {
  $(e).css({lineHeight: $(e).parentsUntil('.pic').last().find('.before .mask').first().height()+'px'});
	 });
        },
        error: function (data) {
            alert("Error : " + data);
        }
    });
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

    // PhototextContent
    var height = 0;
    //$('.spannedItems .wpb_text_column.wpb_content_element').each(function (i, e) {
    //    height = $(e).find('img').first().outerHeight() - $(e).find('p').first().outerHeight();
    //    if ($(e).find('img').first().outerHeight() > $(e).outerHeight()) {
    //        $(e).children().last().css({ paddingBottom: height });
    //    }
    //});
});
