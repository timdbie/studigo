var searchTimer;

async function getStations(query) {
    return $.ajax({
        url: "/Stations",
        type: "GET",
        data: { query: query }
    });
}

async function getStationResults(input, element) {
    var results = element.children(".stations_results");
    
    const stations = await getStations(input);
    results.html(stations);
}

$(".stations_search input").on("input", function() {
    clearTimeout(searchTimer);

    var inputVal = $(this).val();
    var search = $(this).closest(".stations_search");
    
    searchTimer = setTimeout(async function() {
        if(inputVal !== "") {
            await getStationResults(inputVal, search);
        }
    }, 300);
}).on("focus", function() {
    var results = $(this).next(".stations_results");
    results.show();
}).on("blur", function() {
    var results = $(this).next(".stations_results");
    results.hide();
});

$(".stations_search").on("mousedown", ".stations_results div", function(event) {
    if(event.button === 0) {
        var input = $(this).closest(".stations_search").find("input");
        var result = $(this).children(".stations_name").text();
        
        input.val(result);
    } else {
        event.preventDefault();
    }
});
