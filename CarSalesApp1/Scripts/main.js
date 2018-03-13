(function ($) {
    var expr = $("title").html();
    switch (expr) {
        default :
            $(".home-link").addClass("active");
            break;
        case "Home":
            $(".home-link").addClass("active");
            break;
        case "About":
            $(".about-link").addClass("active");
            break;
        case "Store":
            $(".store-link").addClass("active");
            break;
        case "Sign Up":
            $(".signup-link").addClass("active");
            break;
        case "Login":
            $(".login-link").addClass("active");
            break;
        case "Merchandise":
            $(".merchandise-link").addClass("active");
            break;
    }
    // Handler for .ready() called

}(jQuery));
