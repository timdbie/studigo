$(".trips_result").click(function(event) {
    event.preventDefault();
    var tripLegs = $(".trips_legs")
    var url = $(this).attr('href');
    
    
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'json',
        success: function(trip){
            tripLegs.empty();
            $.each(trip.legs, function(index, leg) {
                if (leg.transferMessages != null) {
                    tripLegs.append(createTransfer(leg.transferMessages[0]));
                }
                tripLegs.append(createLeg(leg));
            });
        },
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