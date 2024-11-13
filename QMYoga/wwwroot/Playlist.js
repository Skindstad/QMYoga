

    function scrollCarousel(direction) {
            const carouselContainer = document.getElementById('carouselContainer');
    const imageWidth = 210; // Assuming fixed image width + margin
    const imagesToShow = 5;
    const scrollAmount = direction * imageWidth * imagesToShow;
    carouselContainer.scrollBy({
        left: scrollAmount,
    behavior: 'smooth'
            });
        }