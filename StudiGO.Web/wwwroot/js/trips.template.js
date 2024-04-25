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

function createTripDetails(trip) {
    var tripLegs = $(".trips_legs");
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