// * Initialization carousel
$(document).ready(() => {
	const carousel = $('.owl-carousel');
	carousel.owlCarousel({
		items: 2,
		loop: true,
		dots: false,
		nav: false,
		responsive: {
			0: {
				items: 1,
				margin: 2,
			},
			576: {
				items: 2,
				margin: 2,
			},
			768: {
				items: 3,
			},
			992: {
				items: 4,
			},
		},
	});
	// Custom Navigation Events
	$('.carousel__next').click(() => {
		carousel.trigger('next.owl.carousel');
	});
	$('.carousel__prev').click(() => {
		carousel.trigger('prev.owl.carousel');
	});
});