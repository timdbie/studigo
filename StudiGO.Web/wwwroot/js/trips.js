$('.trips_result').click(function() {
    console.log($(this).data("trip"));
    var trip = $(this).data('trip');
    var tripLegs = $(".trips_legs");
    tripLegs.empty();
    
    $.each(trip.Legs, function(index, leg) {
        if (leg.TransferMessages != null) {
            tripLegs.append(createTransferMessage(leg.TransferMessages[0].Message));
        }
        tripLegs.append(createLegDetails(leg));
    });
});

function createTransferMessage(message) {
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

function createLegDetails(leg) {
    return `<div class="trips_leg">
                <div class="trips_times">
                    <span>${leg.Origin.PlannedDateTime}</span>
                    <span>${leg.Destination.PlannedDateTime}</span>
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
                        @foreach (var note in leg.Product.Notes)
                        {
                            <span>@note[0].Value</span>
                        }
                    </div>
                    <div class="trips_station">
                        <span>${leg.Destination.Name}</span>
                        <span class="trips_track">Spoor ${leg.Destination.PlannedTrack}</span>
                    </div>
                </div>
            </div>`
}