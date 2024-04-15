var searchTimer;

async function getStations(query) {
    try {
        const data = await $.ajax({
            url: "?handler=Stations",
            type: "GET",
            data: { query: query }
        });
        return data.payload;
    } catch (error) {
        throw new Error("Failed to fetch stations: " + error);
    }
}

async function getStationResults(input, element) {
    var results = element.children(".stations_results");
    results.empty();

    try {
        const stations = await getStations(input);
        stations.forEach((station) => {
            var stationDiv = $("<div>").text(station.namen.lang);
            results.append(stationDiv);
        });
    } catch (error) {
        console.error(error);
    }
}

$(".stations_search input").on("input", function() {
    clearTimeout(searchTimer);

    var inputVal = $(this).val();
    var search = $(this).closest(".stations_search");
    
    searchTimer = setTimeout(async function() {
        if(inputVal !== "") {
            await getStationResults(inputVal, search);
        }
    }, 500);
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

        input.val($(this).text());
    } else {
        event.preventDefault();
    }
});
