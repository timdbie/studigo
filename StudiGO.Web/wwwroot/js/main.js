// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(".banner_tabs div").on("click", function() {
    if(!$(this).hasClass("banner_tabs-selected")) {
        $(".banner_tabs div").not(this).removeClass("banner_tabs-selected");
        $(this).addClass("banner_tabs-selected");

        $(".banner_content").children().css("display", "none");
        var targetSection = $(this).attr("id").replace('banner_', '');
        $(".banner_" + targetSection).css("display", "block");
    }
});

// Write your JavaScript code.
