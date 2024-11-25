function isElementInOverflowContainer(element, container) {
    const elementRect = element.getBoundingClientRect();
    const containerRect = container.getBoundingClientRect();

    const fix = 1;
    return (
        elementRect.top >= containerRect.top &&
        elementRect.left >= containerRect.left - fix &&
        elementRect.bottom <= containerRect.bottom &&
        elementRect.right <= containerRect.right + fix
    );
}

function getPrevElement(e) {
    const con = e.parentElement.querySelector(".subcategory-container");
    const elems = e.parentElement.querySelector(".subcategory-list").children;
    let found = false;
    for (let i = elems.length - 1; i >= 0; i--) {
        if (found && !isElementInOverflowContainer(elems[i], con)) {
            return elems[i];
        }

        if (isElementInOverflowContainer(elems[i], con)) {
            found = true;
        }
    }
}
function getNextElement(e) {
    const con = e.parentElement.querySelector(".subcategory-container");
    const elems = e.parentElement.querySelector(".subcategory-list").children;
    let found = false;
    for (let i = 0; i < elems.length; i++) {
        if (found && !isElementInOverflowContainer(elems[i], con)) {
            return elems[i];
        }

        if (isElementInOverflowContainer(elems[i], con)) {
            found = true;
        }
    }
}

function next(e) {
    const elem = getNextElement(e);
    if (!elem) {
        return;
    }

    elem.scrollIntoView({
        behavior: "smooth",
    });
}

function prev(e) {
    const elem = getPrevElement(e);
    if (!elem) {
        return;
    }
    elem.scrollIntoView({
        behavior: "smooth",
    });
}
