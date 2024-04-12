function getStations(query, element) { 
    $.ajax({
        url: "?handler=Stations",
        type: "GET",
        data: { query : query },
        success: function(data) {
            var results = element.children(".stations-search_results");
            results.empty();
            
            data.payload.forEach((station) => {
                console.log(station.namen.middel);
                var stationDiv = $("<div>").text(station.namen.lang);
                
                results.append(stationDiv);
            })
        }
    })
}

$(".stations-search button").on("click", function() {
    var search = $(this).closest(".stations-search");
    var input = search.children("input").val();
    
    getStations(input, search);
})