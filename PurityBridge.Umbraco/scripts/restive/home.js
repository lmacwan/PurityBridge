function pagePreDocumentReady() {
    $.restive.startMulti();
    //$('body').restive({
    //    breakpoints: ['1240', '1280', '10000'],
    //    classes: ['nb1240', 'nb1280', 'nb'],
    //    platform: 'ios'
    //});
    $('body').restive({
        breakpoints: ['1024', '1240', '1280', '1440', '1920', '10000'],
        classes: ['nb1024', 'nb1240', 'nb1280', 'nb1440', 'nb1920', 'nb'],
        platform: 'all'
    });
    $.restive.endMulti();
    //alert($.restive.getPlatform());
}

function pagePostDocumentReady() {

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