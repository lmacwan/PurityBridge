var cbpAnimatedHeader = (function () {

    var docElem = document.documentElement,
		header = $(".header"),
		didScroll = false,
		changeHeaderOn = 150;

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
        var headerHeight = header.height();
        var sy = scrollY();
        if (sy >= changeHeaderOn) {
            if (!(header.hasClass('header-shrink'))) {
                if ($('#quick-search').hasClass("quick-search-visible")) {
                    qiuckSearchForm.css('top', headerHeight - 44);
                } else {
                    qiuckSearchForm.css('top', -47);
                }
            }
            header.addClass('header-shrink');
        }
        else {
            if (header.hasClass('header-shrink')) {
                if ($('#quick-search').hasClass("quick-search-visible")) {
                    qiuckSearchForm.css('top', headerHeight + 44);
                } else {
                    qiuckSearchForm.css('top', 0);
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