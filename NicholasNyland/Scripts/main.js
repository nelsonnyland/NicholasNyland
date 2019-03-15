console.log("MAIN CONNECTED");
"use strict";

/**
 * Slide index is the beginning index a 4 thumbnail set in an 
 * array of thumbnails.
 * */
var slideIndex = 0;

/**
 * Global array of slides.
 * */
var slides = document.getElementsByClassName("thumbnail");

/**
 * Handles side pop-out menu animation.
 * */
function accordion() {    
    var panel = this.nextElementSibling;
    if (panel.style.display === "block") {
        panel.style.display = "none";
    } else {
        panel.style.display = "block";
    }
}

/**
 * Appends main image to carousel.
 * */
function appendImage() {
    var div = document.getElementById("slide");
    var image = document.createElement("img");
    image.id = "img";
    image.src = slides[0].src;
    image.classList += "fill";
    div.appendChild(image);
}

/**
 * Sets thumbnails by beginning index.
 * @param {any} n
 */
function changeThumbnails(slideIndex) {
    for (var i = 0; i < slides.length; ++i) {
        slides[i].style.display = "none";
    }
    // get correct end index
    var space = (slides.length - 1) - slideIndex;
    if (space < 4) {
        var size = slides.length;
    } else {
        var size = slideIndex + 4;
    }
    // show correct set of 4 thumbnails
    for (var i = slideIndex; i < size; ++i) {
        slides[i].style.display = "block";
    }
    // |       |       |
    // 0 1 2 3 4 5 6 7 8 9
}

/**
 * Advances slides backwards and forwards.
 */
function getPreviousSlides() {
    if (slideIndex > 3) {
        slideIndex -= 4;
        changeThumbnails(slideIndex);
    }
}

/**
 * Advances slides backwards and forwards.
 */
function getNextSlides() {
    if ((slideIndex + 4) > (slides.length - 1)) {
        slideIndex = slides.length - 4;
        if (slideIndex < 0) {
            slideIndex = 0;
        }
    } else {
        slideIndex += 4;
        changeThumbnails(slideIndex);
    }
}

/**
 * Adds event listeners to elements on page.
 */
function setEventListener() {
    var acc = document.getElementsByClassName("accordion");
    for (var i = 0; i < acc.length; i++) {
        acc[i].onclick = accordion;
    }
    for (var i = 0; i < slides.length; i++) {
        slides[i].onclick = slideshow;
    }
    var arrows = document.getElementsByClassName("arrow");
    for (var i = 0; i < arrows.length; i++) {
        arrows[i].onclick = toggleArrow;
    }
    var dates = document.getElementsByClassName("date");
    for (var i = 0; i < dates.length; i++) {
        dates[i].onclick = toggleArrow;
    }
    var prev = document.getElementById("prev");
    prev.onclick = getPreviousSlides;
    var next = document.getElementById("next");
    next.onclick = getNextSlides;
}

/**
 * Sets thumbnails on load.
 * */
function setThumbnails() {
    if (screen.width < 900) {        
        for (var i = 0; i < slides.length; ++i) {
            slides[i].style.display = "block";
        }
    }
}

/**
 * Creates main image depending on current image.
 * @param {event} e the event created by onclick
 */
function slideshow(e) {
    var div = document.getElementById("slide");
    while (div.hasChildNodes()) {
        div.removeChild(div.firstChild);        
    }
    var image = document.createElement("img");
    image.id = "img";
    image.src = e.target.src;
    image.classList += "fill";
    div.appendChild(image);
}

/**
 * Toggles the arrow selector on the sidebar.
 * @param {event} e the event created by onclick
 */
function toggleArrow(e) {
    var arrow = e.target;
    if (arrow.className == "date") {
        arrow = arrow.previousElementSibling;
    }
    if (arrow.className == "arrow" ||
        arrow.className == "arrow right") {
        arrow.classList.remove("right");
        arrow.classList.toggle("down");
        arrow.src = "/Images/triangledown.png";
        var ex = arrow.nextElementSibling
                      .nextElementSibling
                      .nextElementSibling;
        ex.style.display = "block";
    } else {
        arrow.classList.remove("down");
        arrow.classList.toggle("right");
        arrow.src = "/Images/triangleside.png";
        var ex = arrow.nextElementSibling
                      .nextElementSibling
                      .nextElementSibling;
        ex.style.display = "none";
    }
}

window.onload = function() {
    appendImage();
    setThumbnails();
    setEventListener();
}

