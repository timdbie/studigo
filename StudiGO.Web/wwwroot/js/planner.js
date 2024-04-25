var now = new Date();
var localDate = formatDate(now);
var localTime = formatTime(now);

var fromStationSession = sessionStorage.getItem("fromStation");
var toStationSession = sessionStorage.getItem("toStation");

$('.planner_date input').val(localDate);
$('.planner_time input').val(localTime);

$("#fromStation").val(fromStationSession);
$("#toStation").val(toStationSession);

$(".planner").submit(async function(event) {
    event.preventDefault();
    
    var formData = new FormData(this);
    
    var fromStation = formData.get("fromStation");
    var toStation = formData.get("toStation");
    var date =  formData.get("date");
    var time = formData.get("time");
    var dateTime = date + "T" + time;

    formData.delete("date");
    formData.delete("time");
    formData.set("dateTime", dateTime);

    sessionStorage.setItem("fromStation", fromStation);
    sessionStorage.setItem("toStation", toStation);

    var params = new URLSearchParams(formData).toString();
    window.history.pushState({}, '', '#/?' + params);

    updateContent();
})

$(".planner_switch").on("click", function() {
    var fromStation = $("#fromStation");
    var toStation = $("#toStation");

    var [fromValue, toValue] = [fromStation.val(), toStation.val()];
    fromStation.val(toValue);
    toStation.val(fromValue);
})