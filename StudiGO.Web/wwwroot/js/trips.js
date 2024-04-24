$(".planner").submit(function(event){
   event.preventDefault(); 
   
   var formData = $(this).serialize();
   getTrips(formData);
});

async function getTrips(formData) {
    const trips = await $.ajax({
        url: `?handler=Trips&${formData}`,
        type: "GET",
    });
    console.log(trips);
    
    var context = trips[1].context;
    var tripDetails = await getTripDetails(context);
    
    window.location.href = window.location.origin + "#/?" + formData + "&context=" + context
}

async function getTripDetails(context) {
    const tripDetails = await $.ajax({
        url: `?handler=TripDetails`,
        type: "GET",
        data: { context: context }
    })
    console.log(tripDetails)
    return tripDetails;
}

$(window).on('hashchange', function(e){
    
});