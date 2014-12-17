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