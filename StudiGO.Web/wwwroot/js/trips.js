$(".planner").submit(function(event) {
    var dateVal = $(".planner_date input").val();
    var timeVal = $(".planner_time input").val();
    var datetime = dateVal + "T" + timeVal;
    
    $("#datetime").val(datetime);
    
    return true;
})