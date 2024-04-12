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

async function getResults(input, element) {
    var results = element.children(".stations-search_results");
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

$(".stations-search input").on("input", function() {
    clearTimeout(searchTimer);

    var input = $(this).val();
    var search = $(this).closest(".stations-search");
    
    searchTimer = setTimeout(async function() {
        if(input !== "") {
            await getResults(input, search);
        }
    }, 500);
}).on("blur", function() {
    var results = $(this).next(".stations-search_results");
    
    results.empty();
});

