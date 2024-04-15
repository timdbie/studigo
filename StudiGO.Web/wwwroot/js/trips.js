async function getTrips(formData) {
    try {
        const data = await $.ajax({
            url: "?handler=Trips",
            type: "GET",
            data: formData
        });
        console.log(data.trips);
        getTripResults(data.trips);
    } catch (error) {
        console.error("Failed to fetch trips:", error);
    }
}

async function getTripResults(trips) {
    trips.forEach((trip) => {
        var tripResult = $("<div>").text(trip.legs[0].origin.plannedDateTime);
        $(".trips_results").append(tripResult);
    });
}

$(".planner").submit(async function(event) {
    event.preventDefault();

    var from = $(".planner_search input[name='from']").val();
    var to = $(".planner_search input[name='to']").val();

    var date = $(".planner_date input").val();
    var time = $(".planner_time input").val();
    var datetime = date + "T" + time;

    var formData = {
        fromStation: from,
        toStation: to,
        datetime: datetime
    }

    await getTrips(formData);

    return false;
});