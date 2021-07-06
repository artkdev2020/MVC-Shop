const host = 'https://localhost:5001';

// * Get categories from server
async function getCategories() {
	let result;
	try {
		const response = await fetch(`${host}/api/Categories`);
		result = await response.json();
	} catch (error) {
		console.error('Error: ', error);
	}

	return result;
}

// * Create 'li' with 'a' for menus
function createSubitem(name) {
	const li = document.createElement('li');
	const a = document.createElement('a');

	a.href = '#';
	a.innerText = name;
	a.className = 'submenu__link';

	li.appendChild(a);
	return li;
}

// * Get subcategories from server
async function getSubcategories(id) {
	let result;
	try {
		const response = await fetch(`${host}/api/Subcategories/category/${id}`);
		result = await response.json();
	} catch (error) {
		console.error('Error: ', error);
	}
	return result;
}

// * Add subcategories to navigation
async function setSubCategories(item, id) {
	let subItem;
	const ul = document.createElement('ul');
	ul.className = 'sub-dropdown-content';

	const subItems = await getSubcategories(id);
	Object.values(subItems).forEach((s) => {
		subItem = createSubitem(s.Name);
		ul.appendChild(subItem);
	});
	item.appendChild(ul);
}

// * Add categories to navigation
async function setCategories(categoriesMenu, ul) {
	const categories = await getCategories();
	Object.values(categories).forEach((c) => {
		const item = createSubitem(c.Name);

		setSubCategories(item, c.Id);
		item.className = 'dropdown-parent';

		ul.appendChild(item);
		categoriesMenu.appendChild(ul);
	});
}

// * Image swapping event for owl-card__icon
async function addClickChangeOwlCardIcon() {
	const cards = document.querySelectorAll('.owl-carousel .owl-card');
	Object.values(cards).forEach((c) => {
		const img = c.querySelector('.owl-card__icon img');
		c.addEventListener('mouseover', (e) => {
			if (e.target.className === 'owl-card_tile') {
				img.src = e.target.src;
			}
		});
	});
}

// * Image swapping event for icon favorite
async function addClickChangeIconFavorite() {
	const images = document.querySelectorAll('.owl-card__favorites-logo img');

	Object.values(images).forEach((i) => {
		i.addEventListener('click', (e) => {
			const url = e.target.src.split('/');
			const nameSvg = url[url.length - 1];
			if (nameSvg === 'heart.svg') {
				e.target.src = '/src/assets/images/common/heart-fill.svg';
			} else {
				e.target.src = '/src/assets/images/common/heart.svg';
			}
		});
	});
}

// * Returns the number including the discount
// * Used to form a product card in the carousel
function getDiscount(disc, price) {
	if (disc) {
		return price - disc / 100;
	}
	return price;
}

// * Sets the main picture in the carousel card
async function setCarouselIcon(id, icon) {
	fetch(`${host}/api/ProductImages/${id}`).then((r) => r.blob()).then((b) => {
		const img = icon;
		img.src = URL.createObjectURL(b);
	});
}

// * Sets the values and necessary classes for the correct display
// * of price and discount in the carousel card
function setCarouselDiscount(rowSale, sale, products, count) {
	const disc = getDiscount(products[count].Discount, products[count].Price);
	const saleTmp = sale;
	if (disc !== products[count].Price) {
		rowSale.classList.add('owl-card__row_discount');
		saleTmp.textContent = `${disc}$`;
	} else {
		rowSale.classList.add('owl-card__row_no_discount');
		saleTmp.style.display = 'none';
	}
}

// * Sets all settings in the carousel cards
async function setCarouselCards() {
	fetch(`${host}/api/Products`).then((j) => j.json()).then((p) => {
		const products = [];
		const size = p.length - 1;
		for (let i = size; i > 1; i--) {
			products.push(p[i]);
		}
		const cards = document.getElementsByClassName('owl-card');
		let count = 1;
		Object.values(cards).forEach((c) => {
			const icon = c.querySelectorAll('.owl-card__icon img')[0];
			const title = c.querySelectorAll('.owl-card__title')[0];
			const rowSale = c.querySelectorAll('.owl-card__row')[0];
			const price = c.querySelectorAll('.owl-card__price')[0];
			const sale = c.querySelectorAll('.owl-card__sale')[0];
			const logo = c.querySelectorAll('.owl-card__favorites-logo img')[0];

			setCarouselIcon(products[count].Id, icon);
			title.textContent = products[count].Name;
			price.textContent = `${products[count].Price}$`;
			logo.src = '/src/assets/images/common/heart.svg';
			logo.alt = products[count].Name;

			setCarouselDiscount(rowSale, sale, products, count);

			count++;
			if (count === 5) {
				count = 0;
			}
		});
	});
}

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

// * When page dom loaded get categories from server
// * Begin here
window.onload = function load() {
	const categoriesMenu = document.getElementById('categories');
	const ul = document.createElement('ul');

	ul.classList.add('dropdown-content');
	setCategories(categoriesMenu, ul);
	addClickChangeOwlCardIcon();
	addClickChangeIconFavorite();

	setCarouselCards();
};
