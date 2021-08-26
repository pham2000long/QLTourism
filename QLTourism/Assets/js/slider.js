const slider = document.getElementById('slider');

const images = [
    {
        img: 'https://images.unsplash.com/photo-1629593733199-a01d1902778c?ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxNHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60',
    },
    {
        img: 'https://images.unsplash.com/photo-1629627262826-7e2e7c4db12e?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80',
    },
    {
        img: 'https://images.unsplash.com/photo-1599420186946-7b6fb4e297f0?ixid=MnwxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHwxMXx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60',
    },
    {
        img: 'https://images.unsplash.com/photo-1629617949872-5f6a1b44ff33?ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxN3x8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60',
    },
    {
        img: 'https://images.unsplash.com/photo-1629364964671-053e86d40e63?ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxOHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60',
    },
    {
        img: 'https://images.unsplash.com/photo-1629583703355-d15a8fa1f160?ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyMXx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60',
    },
];

function createItem(url) {
    let itemSlider = document.createElement('div');
    itemSlider.className = 'itemSlider';

    let img = document.createElement('img');
    img.src = url;
    img.style = 'height: 100px; width: 100%; object-fit: cover; cursor: pointer';

    itemSlider.appendChild(img);
    return itemSlider;
}

for (let i = 0; i < images.length; i++) {
    slider.appendChild(createItem(images[i].img));
}
