/**/
/* on load event */
/**/
$(function()
{
	$('#tuner-switcher').on('click', function()
	{
	    $('#tuner').toggleClass('tuner-visible');
	    $('#tuner label:first-child div').text('Width = ' + $(window).innerWidth());
	});
	
	$('#tuner').on('click', '.colors li', function()
	{
		$(this).addClass('active').siblings().removeClass('active');
		/*$('#logo img').attr('src', 'Content/img/' + $(this).data('color') + '/logo.png');*/
		$('head').append('<link rel="stylesheet" href="/Content/css/color-' + $(this).data('color') + '.css">');
	});
	
	$('#tuner').on('click', '.layouts li', function()
	{
		$(this).addClass('active').siblings().removeClass('active');
		if( $(this).data('layout') == 'boxed' )
			$('.page').addClass('page-boxed');
		else
			$('.page').removeClass('page-boxed');
	});
});