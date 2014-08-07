var imageUrl = "";
$('ul.ca-image li').each(function (i, e) {
    imageUrl = $(e).find('img').attr('src');
    $(e).css('background', 'url(' + imageUrl + ')');
});