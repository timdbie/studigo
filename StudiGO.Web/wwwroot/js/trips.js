$(".planner").submit(function(event){
   event.preventDefault(); 
   
   var formData = $(this).serialize();
   getTrips(formData);
   
   window.location.href = window.location.origin + "#/?" + formData;
});

async function getTrips(formData) {
    const data = await $.ajax({
        url: `?handler=Trips&${formData}`,
        type: "GET",
    });
    console.log(data);
}