$(function () {
    $("#sidebar-container a").filter(function () {
        return this.href === location.href;
    }).addClass("active");
});



$(function () {
    let menu = document.querySelector('#menu-bars');
    let header = document.querySelector('header');

    menu.onclick = () => {
        menu.classList.toggle('fa-times');
        header.classList.toggle('active');
    }

    window.onscroll = () => {
        menu.classList.remove('fa-times');
        header.classList.remove('active');
    }

});



$(function () {
    var routes = String(location.href).split("/");
    if (routes[routes.length - 1] === "PersonalBlogs" || routes[routes.length - 1] === "TechnicalBlogs") {
        if (!$("#collapseExample").hasClass("show")) {
            $("#collapseExample").addClass("show");
        }
    } else {
        if ($("#collapseExample").hasClass("show")) {
            $("#collapseExample").removeClass("show");
        }
    }
});


$("#themeIcon").click(function () {
    if ($(this).hasClass("fa-moon")) {

        $(this).removeClass("fa-moon");

        $(this).addClass("fa-sun");

        $("body").css("background-color", "black");

        $("body").css("color", "white");

    } else if ($(this).hasClass("fa-sun")) {

        $(this).removeClass("fa-sun");

        $(this).addClass("fa-moon");

        $("body").css("background-color", "floralwhite");

        $("body").css("color", "black");

    }
});


$("#collapsable").click(function () {
    if ($("#collapseExample").hasClass("show")) {
        $("#collapseExample").removeClass("show");
    } else {
        $("#collapseExample").addClass("show");
    }
});
