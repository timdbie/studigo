async function fetchTrips(fromStation, toStation, dateTime) {
    const trips = await $.ajax({
        url: "?handler=Trips",
        type: "GET",
        data: { 
            fromStation: fromStation,
            toStation: toStation,
            dateTime: dateTime,
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
    var dateTime = params.get('dateTime');
    var context = params.get('context');
    
    if (fromStation && toStation && dateTime) {
        var trips = await fetchTrips(fromStation, toStation, dateTime)
        var tripsParam = params;
        
        if(context) {
            tripsParam.delete("context")
        }
        
        createTrips(trips, tripsParam);
    }
    
    if(context) {
        var tripDetails = await fetchTripDetails(context);
        createTripDetails(tripDetails);
    }
}

updateContent();

$(".planner").submit(async function(event){
    event.preventDefault();
    
    var formData = new FormData(this);
    
    var date =  formData.get("date");
    var time = formData.get("time");
    var dateTime = date + "T" + time;

    formData.delete("date");
    formData.delete("time");
    formData.set("dateTime", dateTime)
    
    var params = new URLSearchParams(formData).toString();
    window.history.pushState({}, '', '#/?' + params);
    
    updateContent();
});

$(window).on('hashchange', function(e){
    updateContent();
});

function createTrips(trips, tripsParam) {
    var tripResults = $(".trips_results");
    tripResults.empty();
    $.each(trips, function(index, trip) {
        tripResults.append(createTripResult(trip, tripsParam));
    });
}

function createTripResult(trip, tripsParam) {
    return `<a class="trips_result" href="#/?${tripsParam}&context=${trip.context}">
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