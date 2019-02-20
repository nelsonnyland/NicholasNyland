console.log("MAIN CONNECTED");
"use strict";

/**
 * Adds event listeners to elements on page.
 */
function setEventListener() {
    var acc = document.getElementsByClassName("accordion");
    for (var i = 0; i < acc.length; i++) {
        acc[i].onclick = accordion;
    }
    var slides = document.getElementsByClassName("thumbnail");
    for (var i = 0; i < slides.length; i++) {
        slides[i].onclick = slideshow;
    }
    var arrows = document.getElementsByClassName("arrow");
    for (var i = 0; i < arrows.length; i++) {
        arrows[i].onclick = toggleArrow;
    }
}

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
 * Creates main image depending on current image.
 * @param {event} e the event created by onclick
 */
function slideshow(e) {
    var div = document.getElementById("slide");
    while (div.hasChildNodes()) {
        div.removeChild(div.firstChild);        
    }
    var image = document.createElement("img");
    image.src = e.target.src;
    div.appendChild(image);
}

/**
 * Toggles the arrow selector on the sidebar.
 * @param {event} e the event created by onclick
 */
function toggleArrow(e) {
    var arrow = e.target;
    if (arrow.className == "arrow" ||
        arrow.className == "arrow right") {
        arrow.classList.remove("right");
        arrow.classList.toggle("down");
        arrow.src = "~/Images/triangledown.png";
        var ex = arrow.nextElementSibling
                      .nextElementSibling
                      .nextElementSibling;
        ex.style.display = "block";
    } else {
        arrow.classList.remove("down");
        arrow.classList.toggle("right");
        arrow.src = "~/Images/triangleside.png";
        var ex = arrow.nextElementSibling
                      .nextElementSibling
                      .nextElementSibling;
        ex.style.display = "none";
    }
}

/**
 * Appends main image to carousel.
 * */
function appendImage() {
    var div = document.getElementById("slide");
    var image = document.createElement("img");
    var slides = document.getElementsByClassName("thumbnail");
    image.src = slides[0].src;
    div.appendChild(image);
}

window.onload = function() {
    appendImage();
    setEventListener();
}

