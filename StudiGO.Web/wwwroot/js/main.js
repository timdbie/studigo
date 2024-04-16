const now = new Date();
const localDate = now.toISOString().split('T')[0];
const localTime = now.toLocaleTimeString('en', {hour12: false, hour: '2-digit', minute: '2-digit'});

$('.planner_date input').val(localDate);
$('.planner_time input').val(localTime);

$(".banner_tabs div").on("click", function() {
    if(!$(this).hasClass("banner_tabs-selected")) {
        $(".banner_tabs div").not(this).removeClass("banner_tabs-selected");
        $(this).addClass("banner_tabs-selected");

        $(".banner_content").children().css("display", "none");
        var targetSection = $(this).attr("id").replace('banner_', '');
        $(".banner_" + targetSection).css("display", "block");
    }
});

