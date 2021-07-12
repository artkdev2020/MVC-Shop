// * Initialization carousel
$(document).ready(() => {
	$('.product-card__favorites-logo img').click((e) => {
		const url = e.target.src.split('/');
		const nameSvg = url[url.length - 1];
		if (nameSvg === 'heart.svg') {
			e.target.src = '/img/icons/heart-fill.svg';
		} else {
			e.target.src = '/img/icons/heart.svg';
		}
	});
});