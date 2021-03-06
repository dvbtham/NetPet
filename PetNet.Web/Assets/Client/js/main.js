jQuery(document).ready(function($){
    
    // jQuery sticky Menu
    
    $.each($(".product-title-summary"), function (i, e) {
        let text = $(e).text();
        text = text.length > 35 ? text.substring(0, 35) + "..." : text;
        $(e).text(text);
    });

    $("[data-toggle=tooltip]").tooltip();
    
    $(".mainmenu-area").sticky({ topSpacing: 0 });
   
    $('.product-carousel').owlCarousel({
        loop:true,
        nav:true,
        margin:20,
        responsiveClass:true,
        responsive:{
            0:{
                items:1,
            },
            600:{
                items:3,
            },
            1000:{
                items:5,
            }
        }
    });  
    
    $('.related-products-carousel').owlCarousel({
        loop:true,
        nav:true,
        margin:20,
        responsiveClass:true,
        responsive:{
            0:{
                items:1,
            },
            600:{
                items:2,
            },
            1000:{
                items:2,
            },
            1200:{
                items:3,
            }
        }
    });  
    
    $('.brand-list').owlCarousel({
        loop:true,
        nav:true,
        margin:20,
        responsiveClass:true,
        responsive:{
            0:{
                items:1,
            },
            600:{
                items:3,
            },
            1000:{
                items:4,
            }
        }
    });    
    
});

