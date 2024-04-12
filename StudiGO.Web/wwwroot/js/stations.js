function getStations(query) { 
    $.ajax({
        url: "?handler=Stations",
        type: "GET",
        data: { query : query },
        success: function(data) {
            console.log(data);
        }
    })
}

$("#button").on("click", function() {
    getStations($("#input").val());
})