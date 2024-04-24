async function fetchTrips(fromStation, toStation, dateTime) {
    const trips = await $.ajax({
        url: "?handler=Trips",
        type: "GET",
        data: { 
            fromStation: fromStation,
            toStation: toStation,
            dateTime: dateTime
        }
    });
    console.log(trips);
    return trips;
}

async function updateContent() {
    var hashParams = window.location.hash.substring(2);
    var params = new URLSearchParams(hashParams);
    
    var fromStation = params.get('fromStation');
    var toStation = params.get('toStation');
    var dateTime = params.get('dateTime');
    var context = params.get('context');
    
    var fromStationInput = $('input[name="fromStation"]').val();
    var toStationInput = $('input[name="toStation"]').val();
    var dateInput = $('input[name="date"]').val();
    var timeInput = $('input[name="time"]').val();
    
    if (fromStationInput !== "" && toStationInput !== "" && dateInput !== "" && timeInput !== "") {
        var dateTimeInput = dateInput + "T" + timeInput;
        
        if (fromStationInput !== fromStation ||
            toStationInput !== toStation ||
            dateTimeInput !== dateTime) {
            
            var trips = await fetchTrips(fromStationInput, toStationInput, dateTimeInput)
            var tripContext = trips[0].context;
            createTrips(trips);

            var updatedUrlParams = 'fromStation=' + fromStationInput + '&toStation=' + toStationInput + '&dateTime=' + dateTimeInput + '&context=' + tripContext;
            window.history.pushState({}, '', '#/?' + updatedUrlParams);
        }
    }

    if(context) {
        const tripDetails = await $.ajax({
            url: "?handler=TripDetails",
            type: "GET",
            data: { context: context }
        })
        createTripDetails(tripDetails);
        console.log(tripDetails);
    }

}

updateContent();

$(".planner").submit(async function(event){
    event.preventDefault();
    updateContent();
});

$(window).on('popstate', function(e){
    updateContent();
});

function createTrips(trips) {
    var tripResults = $(".trips_results");
    tripResults.empty();
    $.each(trips, function(index, trip) {
        tripResults.append(createTripResult(trip));
    });
}

function createTripResult(trip) {
    return `<a class="trips_result">
                <div class="trips_row">
                    <div class="trips_times">
                        <span class="trips_timespan">${trip.plannedDepartureTime}</span>
                        <span>></span>
                        <span class="trips_timespan">${trip.plannedArrivalTime}</span>
                    </div>
                    <div class="trip_info">
                        <span>${trip.plannedDuration}</span>
                        <span>${trip.transfers}</span>
                    </div>
                </div>
            </a>`
}