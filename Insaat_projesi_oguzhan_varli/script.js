let sliderNo = 0;
let getSlides = $(".slide").toArray();
let getDots = $(".dot").toArray();






$(document).ready(function () {

    showSlide(sliderNo);

    $(".projects-details").mousemove(function () {
        $("#hide-navbar").show("slow")
    })

    $("#hide-navbar-ul").mouseleave(function () {
        $("#hide-navbar").slideToggle(500);
    })


    $("#prevSlide").click(function () {
        if (sliderNo == 0) {
            sliderNo = getSlides.length
        }
        showSlide(--sliderNo);
    })
    $("#nextSlide").click(function () {
        if (sliderNo == getSlides.length - 1) {
            sliderNo = -1;
        }
        showSlide(++sliderNo);
    })
    $(".dot").click(function () {
        sliderNo = $(this).index();
        showSlide(sliderNo);
    })

    function showSlide(n) {
        for (let i = 0; i < getSlides.length; i++) {

            $(".slide").eq(i).hide();
            getDots[i].classList.remove("active")
        }


        $(".slide").eq(n).fadeTo(1000, 0.8)
        getDots[n].classList.add("active")
    }

    $("#popup1").click(function(){
        $(".popup").show()
        $(".popup-head").html("<h1>Orman Evleri İnşaatı</h1>");
        $(".popup-body").html("<p>Ağva iki nehrin arasında konumlanmış bir delta olup, Yeşilçay ve Göksu nehri arasında şirin bir kasabadır.Ağva'yı güzel kılan faktörler arasında hem dere aktivitelerinin burada yapılabiliyor olması, hem de çok kısa bir yolculukla denize ulaşmanın mümkün olmasıdır.</p>");
        $(".popup-image-main").html("<img src='http://theswanparkhotel.com/images/upload/galeri/otel/11.jpg' class='popup-image'>")
    })

    $("#popup2").click(function(){
        $(".popup").show()
        $(".popup-head").html("<h1>Orman Evleri İnşaatı</h1>");
        $(".popup-body").html("<p>Ağva iki nehrin arasında konumlanmış bir delta olup, Yeşilçay ve Göksu nehri arasında şirin bir kasabadır.Ağva'yı güzel kılan faktörler arasında hem dere aktivitelerinin burada yapılabiliyor olması, hem de çok kısa bir yolculukla denize ulaşmanın mümkün olmasıdır.</p>");
        $(".popup-image-main").html("<img src='http://theswanparkhotel.com/images/upload/galeri/otel/11.jpg' class='popup-image'>")
    })

    $(".popup-close").click(function(){
        $(".popup").hide()
    })

    $("html").click(function(e){
        var clicked = $(e.target).attr("class");
        if (clicked == "popup-container") {
            $(".popup").hide()
        }
    })






})



