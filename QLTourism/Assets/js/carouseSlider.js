const carouselSlider = document.getElementById('carousel-slider');
const itemSliders = document.getElementsByClassName('itemSlider');

const sliders = [
    [
        'https://images.unsplash.com/photo-1629617949872-5f6a1b44ff33?ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxN3x8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60',
        'https://images.unsplash.com/photo-1629628840830-f2d4a67e3be7?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80',
        'https://images.unsplash.com/photo-1622495894289-f47b79f0836c?ixid=MnwxMjA3fDF8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80',
        'https://images.unsplash.com/photo-1628191081071-a2b761bf21d9?ixid=MnwxMjA3fDF8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80',
    ],
    [
        'https://images.unsplash.com/photo-1593642702821-c8da6771f0c6?ixid=MnwxMjA3fDF8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1489&q=80',
        'https://images.unsplash.com/photo-1629611922501-be886eb34705?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1351&q=80',
        'https://images.unsplash.com/photo-1629577582606-8ca8a689e4e3?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80',
    ],
    [
        'https://images.unsplash.com/photo-1622495965794-16c9a3afef96?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=926&q=80',
        'https://images.unsplash.com/photo-1627662234702-d9a86170325e?ixid=MnwxMjA3fDF8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80',
        'https://images.unsplash.com/photo-1629576350035-8ccec375adcd?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80',
    ],
];

function createItemSlider(url) {
    let itemSlider = document.createElement('div');
    itemSlider.className = 'carousel-item';

    let img = document.createElement('img');
    img.src = url;
    img.className = 'd-block w-100 h-100';

    itemSlider.appendChild(img);
    return itemSlider;
}

for (let i = 0; i < itemSliders.length; i++) {
    itemSliders[i].addEventListener('click', function (event) {
        renderSlider(i, event);
    });
}

for (let i = 0; i < sliders[0].length; i++) {
    let item = createItemSlider(sliders[0][i]);
    if (i === 0) {
        item.classList.add('active');
    }
    carouselSlider.appendChild(item);
}

function renderSlider(index, event) {
    removeAllChildNodes(carouselSlider);
    if (!sliders[index]) {
        index = 0;
    }
    for (let i = 0; i < sliders[index].length; i++) {
        let item = createItemSlider(sliders[index][i]);
        if (i === 0) {
            item.classList.add('active');
        }
        carouselSlider.appendChild(item);
        event.preventDefault();
    }
}

function removeAllChildNodes(parent) {
    while (parent.firstChild) {
        parent.removeChild(parent.firstChild);
    }
}
