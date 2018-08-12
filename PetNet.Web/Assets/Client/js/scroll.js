$(function(){
	$(window).scroll(function(){
		if ($(this).scrollTop() < 100 ) {
			$('.scroll-up').addClass('scroll-hide');
			
			return false;

		} else 
		{
			$('.scroll-up').removeClass('scroll-hide');
			return false;
		}
	});

    $('.scroll-up').click(function (event) {
        event.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, 800);
	});
})