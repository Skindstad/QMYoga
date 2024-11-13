

    function scrollCarousel(direction, id) {
            const carouselContainer = document.getElementById('carouselContainer' + id);
    const imageWidth = 220; // Assuming fixed image width + margin
    const imagesToShow = 1;
    const scrollAmount = direction * imageWidth * imagesToShow;
    carouselContainer.scrollBy({
        left: scrollAmount,
    behavior: 'smooth'
            });
        }