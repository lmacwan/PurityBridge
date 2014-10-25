
var timer;
$(document).ready(function () {

    //nojs
    $("body").removeClass("no-js");

    //------------------------------------------------------------------------//

    //fakelink
    $('a[href="#"]').on('click', function (e) { e.preventDefault(); });

    //------------------------------------------------------------------------//

    //placeholder
    $('input[placeholder], textarea[placeholder]').placeholder();

    //------------------------------------------------------------------------//

    // tab
    $(function () {
        $('.tabs').delegate('li:not(.active)', 'click', function () {
            $(this).addClass('active').siblings().removeClass('active').parents('.tab').find('.box').hide().eq($(this).index()).fadeIn(250);
            $('.mask .mask-wrapper').first().html($($('.tabs li.active').parents('.tab').find('.box')[$('.tabs li.active').index()]).find('img').clone());
        })

        $('.mask .mask-wrapper').first().html($($('.tabs li.active').parents('.tab').find('.box')[$('.tabs li.active').index()]).find('img').clone());

        timer = setInterval(function () {
            changeImageInterval();
        }, 5000);
    });

    // tab arrows
    if ($(".tab").has(".tab-prev").length || $(".tab").has(".tab-next").length) {
        $('.tab-prev, .tab-next').click(function () {
            var $active = $(this).parents(".tab").find(".tabs .active");
            $next = $(this).hasClass('tab-prev') ? $active.prev() : $active.next();
            if (!$next.length) $next = $(this).hasClass('tab-prev') ? $(this).parents(".tab").find('.tabs li:last') : $(this).parents(".tab").find('.tabs li:first');
            $next.click();
            return false;
        });
    }


    $('.comments.clearfix').mouseenter(null, stopInterval);
    $('.comments.clearfix').mouseleave(null, startInterval);

    //------------------------------------------------------------------------//

});//document ready

function changeImageInterval() {
    var total = $('.tabs li').length;
    $($('.tabs li')[($('.tabs li.active').index() + 1) % total]).addClass('active').siblings().removeClass('active').parents('.tab').find('.box').hide().eq($('.tabs li.active').index()).fadeIn(250);
    $('.mask .mask-wrapper').first().html($($('.tabs li.active').parents('.tab').find('.box')[$('.tabs li.active').index()]).find('img').clone());
}

function stopInterval() {
    if (timer != undefined) {
        clearInterval(timer);
    }
}

function startInterval() {
    timer = setInterval(changeImageInterval, 5000);
}