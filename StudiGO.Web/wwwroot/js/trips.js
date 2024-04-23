$(".trips_result").click(function(trip) {
    $.each(trip.Legs, function(index, leg) {
        if (leg.TransferMessages != null) {
            tripLegs.append(createTransfer(leg.TransferMessages[0].Message));
        }
        tripLegs.append(createLeg(leg));
    });
});

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
        notesElement += `<span>${note[0].Value}</span>`;
    });
    
    return notesElement;
}

function createLeg(leg) {
    return `<div class="trips_leg">
                <div class="trips_times">
                    <span>${formatTime(leg.Origin.PlannedDateTime)}</span>
                    <span>${formatTime(leg.Destination.PlannedDateTime)}</span>
                </div>
                <div class="trips_graphic">
                    <div class="trips_pin"></div>
                    <div class="trips_line"></div>
                    <div class="trips_pin"></div>
                </div>
                <div class="trips_info">
                    <div class="trips_station">
                        <span>${leg.Origin.Name}</span>
                        <span class="trips_track">Spoor ${leg.Origin.PlannedTrack}</span>
                    </div>
                    <div class="trips_notes">
                        ${createNotes(leg.Product.Notes)}
                    </div>
                    <div class="trips_station">
                        <span>${leg.Destination.Name}</span>
                        <span class="trips_track">Spoor ${leg.Destination.PlannedTrack}</span>
                    </div>
                </div>
            </div>`
}