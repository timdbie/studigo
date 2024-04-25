var searchTimer;

async function getStations(query) {
    const data = await $.ajax({
        url: "?handler=Stations",
        type: "GET",
        data: { query: query }
    });
    return data.payload;
}

async function getStationResults(input, element) {
    var results = element.children(".stations_results");
    results.empty();
    
    const stations = await getStations(input);
    stations.forEach((station) => {
        var stationDiv = `<div>
                                    <label>O</label>
                                    <span class="stations_name">${station.namen.lang}</span>
                                    <span>Treinstation</span>
                                 </div>`;
        results.append(stationDiv);
    });
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
