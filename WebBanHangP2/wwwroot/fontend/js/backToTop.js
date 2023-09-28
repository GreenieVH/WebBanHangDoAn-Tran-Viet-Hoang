const backToTop = document.querySelector(".back-to-top i");

window.addEventListener("scroll", function () {
    console.log("vl");
    var y = window.scrollY;
    if (y >= 100) {
        backToTop.classList.add("show")
    } else {
        backToTop.classList.remove("show");
    }
})

backToTop.addEventListener("click", function () {
    window.scroll({
        top: 0,
        behavior: "smooth",
    });
});
