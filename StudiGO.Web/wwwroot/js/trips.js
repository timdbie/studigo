async function fetchTrips(fromStation, toStation, date, time) {
    const trips = await $.ajax({
        url: "?handler=Trips",
        type: "GET",
        data: { 
            fromStation: fromStation,
            toStation: toStation,
            dateTime: date + "T" + time,
        }
    });
    console.log(trips);
    return trips;
}

async function fetchTripDetails(context) {
    const tripDetails = await $.ajax({
        url: "?handler=TripDetails",
        type: "GET",
        data: { context: context }
    })
    console.log(tripDetails);
    return tripDetails;
}

async function updateContent() {
    var hashParams = window.location.hash.substring(2);
    var params = new URLSearchParams(hashParams);
    
    var fromStation = params.get('fromStation');
    var toStation = params.get('toStation');
    var date = params.get('date');
    var time = params.get('time');
    var context = params.get('context');
    
    if (fromStation && toStation && date && time) {
        var trips = await fetchTrips(fromStation, toStation, date, time)
        createTrips(trips);
    }
    
    if(context) {
        var tripDetails = await fetchTripDetails(context);
        createTripDetails(tripDetails);
    }
}

updateContent();

$(".planner").submit(async function(event){
    event.preventDefault();
    
    var params = $(this).serialize();
    window.history.pushState({}, '', '#/?' + params);
    
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
    return `<a class="trips_result" href="#/?&context=${trip.context}">
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