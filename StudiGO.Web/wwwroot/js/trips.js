$(window).on('hashchange', async function(e){
    e.preventDefault();
    var url = window.location.href;
    var params = new URLSearchParams(url.split('?')[1]);
    var context = params.get("context");
    console.log(context);
    
    if (context) {
        try {
            const data = await $.ajax({
                url: "?handler=TripDetails",
                type: "GET",
                data: { context: context }
            });
            createTripDetails($(".trip_legs"));
        } catch (error) {
            throw new Error("Failed to fetch stations: " + error);
        }
        
    }
})

function createTripDetails(tripLegs) {
    tripLegs.empty();
    $.each(trip.legs, function(index, leg) {
        if (leg.transferMessages != null) {
            tripLegs.append(createTransfer(leg.transferMessages[0]));
        }
        tripLegs.append(createLeg(leg));
    });
}

function createTransfer(message) {
    return `<div class="trips_transfer">
                <div class="trips_transfer_icon"></div>
                <div class="trips_transfer_graphic">
                    <div></div>
                </div>
                <div class="trips_transfer_info">
                    <div>${message}</div>
                </div>
            </div>`
}

function createNotes(notes) {
    let notesElement = "";
    $.each(notes, function(index, note) {
        notesElement += `<span>${note}</span>`;
    });
    
    return notesElement;
}

function createLeg(leg) {
    return `<div class="trips_leg">
                <div class="trips_times">
                    <span>${leg.origin.time}</span>
                    <span>${leg.destination.time}</span>
                </div>
                <div class="trips_graphic">
                    <div class="trips_pin"></div>
                    <div class="trips_line"></div>
                    <div class="trips_pin"></div>
                </div>
                <div class="trips_info">
                    <div class="trips_station">
                        <span>${leg.origin.name}</span>
                        <span class="trips_track">Spoor ${leg.origin.track}</span>
                    </div>
                    <div class="trips_notes">
                        ${createNotes(leg.notes)}
                    </div>
                    <div class="trips_station">
                        <span>${leg.destination.name}</span>
                        <span class="trips_track">Spoor ${leg.destination.track}</span>
                    </div>
                </div>
            </div>`
}