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
        $(".popup-head").html("<h1>Olimpiyat Stadı</h1>");
        $(".popup-body").html("<p>Getirdiği yenilikçi anlayış ile futbolu ve futbol seyircisini sadece karşılaşmalarda değil, her zaman bir arada bulunduracak olan UEFA ve FIFA standartlarındaki stadyum; 3 adet antrenman sahası, kapalı­açık otopark ve dükkanlardan oluşan çağdaş bir spor kompleksidir.</p>");
        $(".popup-image-main").html("<img src='https://dynamic-media-cdn.tripadvisor.com/media/photo-o/06/64/4f/c3/ataturk-olimpiyat-stadi.jpg?w=1200&h=-1&s=1' class='popup-image'>")
    })

    $("#popup3").click(function(){
        $(".popup").show()
        $(".popup-head").html("<h1>Lübnan Elektrik Santrali</h1>");
        $(".popup-body").html("<p>4.500 GWH yıllık enerji üretimi kapasitesinin yanında 630 MWe kurulu güce sahip olan santral 20.11.2021 tarihinde ilk defa faaliyete geçmiştir.</p>");
        $(".popup-image-main").html("<img src='https://www.elektrikde.com/wp-content/uploads/2019/12/T%C3%BCrkiyenin-Termik-Santralleri.jpg' class='popup-image'>")
    })

    $("#popup4").click(function(){
        $(".popup").show()
        $(".popup-head").html("<h1>Silivri Konutları</h1>");
        $(".popup-body").html("<p>Silivri İlçesi’nde Ortalama kat brüt alanları 86 m2 olan 474 adet 2+1 açık mutfak, 92 m2 olan 702 adet 2+1 kapalı mutfak, 111 m2 olan 220 adet 3+1 olmak üzere toplam 32 bloklu 1.396 konuttan oluşan projede 50 cadde üstü dükkan ve 1 adet kreş bulunuyor.</p>");
        $(".popup-image-main").html("<img src='https://www.kiptas.istanbul/storage/31-tipi-alt-1.jpg' class='popup-image'>")
    })

    $("#popup5").click(function(){
        $(".popup").show()
        $(".popup-head").html("<h1>Ankara Natura Konutları</h1>");
        $(".popup-body").html("<p>Şehrin karmaşasından uzakta ama bir o kadar da şehirle iç içe yaşam herkesin hayalidir. Bu yüzden özellikle çalışan insanlar hafta sonu olunca şehrin gürültüsünü geride bırakmak, doğaya karışmak, sevdikleri ile dinlenmek istiyor. Alacaatlı, yeşil alanları, tertemiz havası, çağdaş yapılaşması sebebiyle sadece hafta sonları dinlenmek için değil yaşamak için de öncelikli olarak tercih ediliyor.</p>");
        $(".popup-image-main").html("<img src='http://www.naturaalacaatli.com/frontend/uploads/001_1634680479.jpg' class='popup-image'>")
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



