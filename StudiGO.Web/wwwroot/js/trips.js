var storedParams = storedParams || {};

async function updateContent() {
    var hashParams = window.location.hash.substring(2);
    var params = new URLSearchParams(hashParams);

    var fromStation = params.get('fromStation');
    var toStation = params.get('toStation');
    var dateTime = params.get('dateTime');
    var context = params.get('context');
    
    var tripParamsChanged = fromStation !== storedParams.fromStation || toStation !== storedParams.toStation || dateTime !== storedParams.dateTime;
    var contextParamsChanged = context !== storedParams.context;

    storedParams = {
        fromStation : fromStation,
        toStation : toStation,
        dateTime : dateTime,
        context : context,
    }

    if (fromStation && toStation && dateTime) {
        if (tripParamsChanged) {
            var trips = await fetchTrips(fromStation, toStation, dateTime)
        }
        if (context) {
            if (contextParamsChanged) {
                $(".trips_result").removeClass("trip_result-selected");
                $(".trips_result[href='#/" + hashParams + "']").addClass("trip_result-selected");
                
                var tripDetails = await fetchTripDetails(context);
            }
        } else {
            $(".trips_legs").empty();
        }
        
        if(trips) {
            $(".trips_results").html(trips);
            $(".trips_result[href='#/" + hashParams + "']").addClass("trip_result-selected");
        }
        if(tripDetails) {
            $(".trips_legs").html(tripDetails);
        }
    }
}

async function fetchTrips(fromStation, toStation, dateTime) {
    return $.ajax({
        url: "?handler=Trips",
        type: "GET",
        data: {
            fromStation: fromStation,
            toStation: toStation,
            dateTime: dateTime,
        }
    });
}

async function fetchTripDetails(context) {
    return $.ajax({
        url: "?handler=TripDetails",
        type: "GET",
        data: { context: context }
    })
}

updateContent();

$(window).on('hashchange', function(e){
    updateContent();
});
