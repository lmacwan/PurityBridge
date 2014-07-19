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

    function scrollPage() {
        var sy = scrollY();
        if (sy >= changeHeaderOn) {
            if (!(header.hasClass('page-header-shrink'))) {
                if ($('#quick-search').hasClass("quick-search-visible")) {
                    qiuckSearchForm.css('top', 56);
                } else {
                    qiuckSearchForm.css('top', -146);
                }
            }
            header.addClass('page-header-shrink');
        }
        else {
            if (header.hasClass('page-header-shrink')) {
                if ($('#quick-search').hasClass("quick-search-visible")) {
                    qiuckSearchForm.css('top', 112);
                } else {
                    qiuckSearchForm.css('top', -202);
                }
            }
            header.removeClass('page-header-shrink');
        }
        didScroll = false;
    }

    function scrollY() {
        return window.pageYOffset || docElem.scrollTop;
    }

    init();

})();