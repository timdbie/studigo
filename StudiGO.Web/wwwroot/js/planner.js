var fromStationSession = sessionStorage.getItem("fromStation");
var toStationSession = sessionStorage.getItem("toStation");

$("#fromStation").val(fromStationSession);
$("#toStation").val(toStationSession);

$(".planner").submit(function(event) {
    fromStationSession = $("#fromStation").val();
    toStationSession = $("#toStation").val();
    
    sessionStorage.setItem("fromStation", fromStationSession)
    sessionStorage.setItem("toStation", toStationSession)
    
    return true;
})

$(".planner_switch").on("click", function() {
    var fromStation = $("#fromStation");
    var toStation = $("#toStation");

    var [fromValue, toValue] = [fromStation.val(), toStation.val()];
    fromStation.val(toValue);
    toStation.val(fromValue);
})