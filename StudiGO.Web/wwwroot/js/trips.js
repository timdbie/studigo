var prevFromStation, prevToStation, prevDateTime, prevContext;

async function updateContent() {
    var hashParams = window.location.hash.substring(2);
    var params = new URLSearchParams(hashParams);

    var fromStation = params.get('fromStation');
    var toStation = params.get('toStation');
    var dateTime = params.get('dateTime');
    var context = params.get('context');

    var tripsParamsChanged = fromStation !== prevFromStation || toStation !== prevToStation || dateTime !== prevDateTime;
    var contextParamsChanged = context !== prevContext;

    prevFromStation = fromStation;
    prevToStation = toStation;
    prevDateTime = dateTime;
    prevContext = context;

    if (fromStation && toStation && dateTime) {
        if (tripsParamsChanged) {
            var trips = await fetchTrips(fromStation, toStation, dateTime)
            var tripsParam = params;

            if (context) {
                tripsParam.delete("context")
            }
            
            createTrips(trips, tripsParam);
        }
    }

    if (context) {
        if (contextParamsChanged) {
            var tripDetails = await fetchTripDetails(context);
            createTripDetails(tripDetails);
        }
    }
}

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

updateContent();

$(window).on('hashchange', function(e){
    updateContent();
});
