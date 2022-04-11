
//$(document).ready(function () {
//    $("nav-item a").click(function (e) {
//        $(".nav-item > a ").removeClass("active1");
//        $(this).addClass("active1");
//    })
   
  
//})

$(document).ready(function () {
    $(".nav-item").click(function () {
        var pageContact = this.children[0].href;
        sessionStorage.setItem('page', pageContact);
    })
    
});

$(function () {
    var page = sessionStorage.getItem('page');
    var navbar = document.querySelectorAll('.nav-item');
    if (page == null) {
        $(navbar[0]).addClass('active1');
    } else {
        navbar.forEach((item, index) => {
            if (item.children[0].href == page) {
                $(item).addClass('active1').siblings().removeClass('active1');
            }
        });
    }
})



