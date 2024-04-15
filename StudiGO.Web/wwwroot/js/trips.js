async function getTrips(formData) {
    try {
        const response = await $.ajax({
            url: "?handler=Trips",
            type: "GET",
            data: formData
        });
        console.log(response);
    } catch (error) {
        console.error("Failed to fetch trips:", error);
    }
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