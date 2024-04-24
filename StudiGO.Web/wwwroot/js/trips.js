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
    return trips[0].context;
}

async function updateContent() {
    var hashParams = window.location.hash.substring(2);
    var params = new URLSearchParams(hashParams);
    
    var fromStation = params.get('fromStation');
    var toStation = params.get('toStation');
    var dateTime = params.get('dateTime');
    var context = params.get('context');
    
    if(context) {
        const tripDetails = await $.ajax({
            url: "?handler=TripDetails",
            type: "GET",
            data: { context: context }
        })
        createTripDetails(tripDetails);
        console.log(tripDetails);
    }
    
    var fromStationInput = $('input[name="fromStation"]').val();
    var toStationInput = $('input[name="toStation"]').val();
    var dateInput = $('input[name="date"]').val();
    var timeInput = $('input[name="time"]').val();
    
    if (fromStationInput !== "" && toStationInput !== "" && dateInput !== "" && timeInput !== "") {
        var dateTimeInput = dateInput + "T" + timeInput;
        
        if (fromStationInput !== fromStation ||
            toStationInput !== toStation ||
            dateTimeInput !== dateTime) {
            
            fetchTrips(fromStationInput, toStationInput, dateTimeInput).then(function (tripContext) {
                if (tripContext) {
                    var updatedUrlParams = 'fromStation=' + fromStationInput + '&toStation=' + toStationInput + '&dateTime=' + dateTimeInput + '&context=' + tripContext;
                    window.history.pushState({}, '', '#/?' + updatedUrlParams);
                }
            });
        }
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