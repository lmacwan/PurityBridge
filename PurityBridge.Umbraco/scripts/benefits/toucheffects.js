function slideHeading() {
    $('ul.grid > li > figure' ).each( function( i, e ) {
        $(e).find('figcaption > a' ).addEventListener( 'touchstart', function(e) {
            e.stopPropagation();
        }, false );
        el.addEventListener('touchstart', function (e) {
            classie.addClass( this, 'cs-hover' );
        }, false );
    } );
}