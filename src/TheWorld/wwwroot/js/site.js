// Site.js

(function () {

    ////var ele = document.getElementById("username");
    //var ele = $("#username");

    ////ele.innerHTML = "Luke Skywalker";
    //ele.text("Luke Skywalker");

    //var main = $("#main");

    //main.on("mouseenter", function () {
    //    main.style.backgroundColor = "#888";
    //});

    //main.on("mouseleave", function () {
    //    main.style.backgroundColor = "";
    //});

    ////Handling more than one item being returned by CSS Selectors
    //var menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {

    //    var me = $(this);
    //    alert(me.text());

    //});

    //This will return a wrapped set of elements with the below selector as the "," acts as an "and" operator
    var $sidebarAndWrapper = $("#sidebar,#wrapper");
    var $icon = $("#sidebarToggle i.fa");

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");  //Adds a class if doesn't exist or removes a class if it does exist

        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        } else {
            $icon.addClass("fa-angle-left");
            $icon.removeClass("fa-angle-right");
        }

    });


})();