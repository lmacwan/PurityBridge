var cbpAnimatedHeader = (function () {

    var docElem = document.documentElement,
		header = $(".header"),
		didScroll = false,
		changeHeaderOn = 50;

    function init() {
        window.addEventListener('scroll', function (event) {
            if (!didScroll) {
                didScroll = true;
                setTimeout(scrollPage, 250);
            }
        }, false);
    }

    var qiuckSearchForm = $('.quick-search-form');

    function scrollPage() {
        var sy = scrollY();
        if (sy >= changeHeaderOn) {
            if (!(header.hasClass('header-shrink'))) {
                if ($('#quick-search').hasClass("quick-search-visible")) {
                    qiuckSearchForm.css('top', 44);
                } else {
                    qiuckSearchForm.css('top', -517);
                }
            }
            header.addClass('header-shrink');
        }
        else {
            if (header.hasClass('header-shrink')) {
                if ($('#quick-search').hasClass("quick-search-visible")) {
                    qiuckSearchForm.css('top', 88);
                } else {
                    qiuckSearchForm.css('top', -473);
                }
            }
            header.removeClass('header-shrink');
        }
        didScroll = false;
    }

    function scrollY() {
        return window.pageYOffset || docElem.scrollTop;
    }

    init();

})();