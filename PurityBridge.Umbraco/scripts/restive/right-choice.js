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