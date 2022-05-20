function ShowCloseMenu() {
    //$(".nav-content").toggle("slow");
    if ($(".nav-content").css("display") == "none") {
        $(".nav-content").css("display", "block");
    } else {
        $(".nav-content").css("display", "none");
    }
}