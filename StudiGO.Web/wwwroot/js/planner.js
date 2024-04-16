var fromStation = sessionStorage.getItem("fromStation");
var toStation = sessionStorage.getItem("toStation");

$("#fromStation").val(fromStation);
$("#toStation").val(toStation);

$(".planner").submit(function(event) {
    console.log("test");
    fromStation = $("#fromStation").val();
    toStation = $("#toStation").val();
    
    sessionStorage.setItem("fromStation", fromStation)
    sessionStorage.setItem("toStation", toStation)
    
    return true;
})