

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

window.modalFunctions = {
    openModal: function (modalId) {
        const modal = document.getElementById(modalId);
        if (modal) {
            modal.style.display = "block";
        }
    },
    closeModal: function (modalId) {
        const modal = document.getElementById(modalId);
        if (modal) {
            modal.style.display = "none";
        }
    },
    setupCloseOnOutsideClick: function (modalId) {
        const modal = document.getElementById(modalId);
        if (modal) {
            window.onclick = function (event) {
                if (event.target === modal) {
                    modal.style.display = "none";
                }
            };
        }
    }
};