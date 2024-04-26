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
                        <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
                            <path fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5" d="M4 12h2.5M20 12l-6-6m6 6l-6 6m6-6H9.5" />
                        </svg>
                        <span class="trips_timespan">${trip.plannedArrivalTime}</span>
                    </div>
                    <div class="trips_info">
                        <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
                            <path fill="currentColor" fill-rule="evenodd" d="M12 2.75a9.25 9.25 0 1 0 0 18.5a9.25 9.25 0 0 0 0-18.5M1.25 12C1.25 6.063 6.063 1.25 12 1.25S22.75 6.063 22.75 12S17.937 22.75 12 22.75S1.25 17.937 1.25 12M12 7.25a.75.75 0 0 1 .75.75v3.69l2.28 2.28a.75.75 0 1 1-1.06 1.06l-2.5-2.5a.75.75 0 0 1-.22-.53V8a.75.75 0 0 1 .75-.75" clip-rule="evenodd" />
                        </svg>
                        <span>${trip.plannedDuration}</span>
                        <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
                            <path fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2 12h2m16-5h2M4 12a2 2 0 1 0 4 0a2 2 0 1 0-4 0m12-5a2 2 0 1 0 4 0a2 2 0 1 0-4 0m4 10h2m-6 0a2 2 0 1 0 4 0a2 2 0 1 0-4 0m-8.5-6.5L16 7" />
                        </svg>
                        <span>${trip.transfers}</span>
                    </div>
                </div>
                <div class="trips_row">
                    <div class="trips_transport">
                        <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
                            <path fill="currentColor" fill-rule="evenodd" d="M11.944 1.25h.112c.662 0 1.274 0 1.84.007a.757.757 0 0 1 .23.003c.907.016 1.69.053 2.363.143c1.172.158 2.121.49 2.87 1.238c.748.749 1.08 1.698 1.238 2.87c.153 1.14.153 2.595.153 4.433v3.022a.768.768 0 0 1-.001.072c-.004 1.384-.027 2.523-.152 3.451c-.158 1.172-.49 2.121-1.238 2.87c-.406.405-.87.688-1.397.888l.709 1.418a.75.75 0 1 1-1.342.67l-.867-1.735c-1.135.15-2.582.15-4.406.15h-.112c-1.824 0-3.27 0-4.406-.15l-.867 1.735a.75.75 0 1 1-1.342-.67l.709-1.418a3.868 3.868 0 0 1-1.397-.888c-.748-.749-1.08-1.698-1.238-2.87c-.125-.928-.148-2.067-.152-3.45a.759.759 0 0 1 0-.073l-.001-.91V9.944c0-1.838 0-3.294.153-4.433c.158-1.172.49-2.121 1.238-2.87c.749-.748 1.698-1.08 2.87-1.238c.673-.09 1.456-.127 2.363-.143a.755.755 0 0 1 .23-.003c.566-.007 1.178-.007 1.84-.007m-2.68 1.526c-.593.02-1.104.053-1.553.114c-1.006.135-1.586.389-2.01.812c-.422.423-.676 1.003-.811 2.009c-.138 1.028-.14 2.382-.14 4.289v2.25h14.5V10c0-1.907-.002-3.261-.14-4.29c-.135-1.005-.389-1.585-.812-2.008c-.423-.423-1.003-.677-2.009-.812c-.449-.06-.96-.095-1.553-.114a2.75 2.75 0 0 1-5.472 0m3.96-.024a1.25 1.25 0 0 1-2.449 0a266.424 266.424 0 0 1 2.45 0m6.02 10.998H4.756c.01 1.034.042 1.858.134 2.54c.135 1.005.389 1.585.812 2.008c.423.423 1.003.677 2.009.812c1.028.138 2.382.14 4.289.14c1.907 0 3.262-.002 4.29-.14c1.005-.135 1.585-.389 2.008-.812c.423-.423.677-1.003.812-2.009c.092-.68.123-1.505.134-2.539M6.25 16a.75.75 0 0 1 .75-.75h1.5a.75.75 0 0 1 0 1.5H7a.75.75 0 0 1-.75-.75m8.5 0a.75.75 0 0 1 .75-.75H17a.75.75 0 0 1 0 1.5h-1.5a.75.75 0 0 1-.75-.75" clip-rule="evenodd" />
                        </svg>
                        Trein
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
                <div class="trips_transfer_icon">
                    <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
                        <path fill="currentColor" fill-rule="evenodd" d="M12.5 2.75a1.75 1.75 0 1 0 0 3.5a1.75 1.75 0 0 0 0-3.5M9.25 4.5a3.25 3.25 0 1 1 6.5 0a3.25 3.25 0 0 1-6.5 0m1.68 4.767c.199-.01.392-.017.57-.017c.554 0 1.154.062 1.694.14c1.521.218 2.673 1.34 3.134 2.722a.67.67 0 0 0 .746.449l1.803-.3a.75.75 0 1 1 .246 1.479l-1.803.3a2.17 2.17 0 0 1-2.415-1.454c-.307-.922-1.043-1.585-1.924-1.712a13.64 13.64 0 0 0-.805-.093l-.271 2.711c-.084.84-.094 1.062-.037 1.26c.056.198.182.38.697 1.049l4.43 5.74a.75.75 0 1 1-1.188.917l-4.43-5.74l-.07-.093c-.411-.53-.736-.951-.882-1.46c-.145-.51-.092-1.038-.025-1.706l.012-.116l.254-2.54c-1.673.273-2.916 1.846-2.916 3.697a.75.75 0 0 1-1.5 0c0-2.64 1.914-5.083 4.68-5.233m-.783 7.498a.75.75 0 0 1 .588.882a7.749 7.749 0 0 1-2.757 4.531l-.51.408a.75.75 0 0 1-.936-1.172l.509-.407a6.25 6.25 0 0 0 2.224-3.654a.75.75 0 0 1 .882-.588" clip-rule="evenodd" />
                    </svg>
                </div>
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
                    <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
                        <path fill="currentColor" fill-rule="evenodd" d="M11.944 1.25h.112c.662 0 1.274 0 1.84.007a.757.757 0 0 1 .23.003c.907.016 1.69.053 2.363.143c1.172.158 2.121.49 2.87 1.238c.748.749 1.08 1.698 1.238 2.87c.153 1.14.153 2.595.153 4.433v3.022a.768.768 0 0 1-.001.072c-.004 1.384-.027 2.523-.152 3.451c-.158 1.172-.49 2.121-1.238 2.87c-.406.405-.87.688-1.397.888l.709 1.418a.75.75 0 1 1-1.342.67l-.867-1.735c-1.135.15-2.582.15-4.406.15h-.112c-1.824 0-3.27 0-4.406-.15l-.867 1.735a.75.75 0 1 1-1.342-.67l.709-1.418a3.868 3.868 0 0 1-1.397-.888c-.748-.749-1.08-1.698-1.238-2.87c-.125-.928-.148-2.067-.152-3.45a.759.759 0 0 1 0-.073l-.001-.91V9.944c0-1.838 0-3.294.153-4.433c.158-1.172.49-2.121 1.238-2.87c.749-.748 1.698-1.08 2.87-1.238c.673-.09 1.456-.127 2.363-.143a.755.755 0 0 1 .23-.003c.566-.007 1.178-.007 1.84-.007m-2.68 1.526c-.593.02-1.104.053-1.553.114c-1.006.135-1.586.389-2.01.812c-.422.423-.676 1.003-.811 2.009c-.138 1.028-.14 2.382-.14 4.289v2.25h14.5V10c0-1.907-.002-3.261-.14-4.29c-.135-1.005-.389-1.585-.812-2.008c-.423-.423-1.003-.677-2.009-.812c-.449-.06-.96-.095-1.553-.114a2.75 2.75 0 0 1-5.472 0m3.96-.024a1.25 1.25 0 0 1-2.449 0a266.424 266.424 0 0 1 2.45 0m6.02 10.998H4.756c.01 1.034.042 1.858.134 2.54c.135 1.005.389 1.585.812 2.008c.423.423 1.003.677 2.009.812c1.028.138 2.382.14 4.289.14c1.907 0 3.262-.002 4.29-.14c1.005-.135 1.585-.389 2.008-.812c.423-.423.677-1.003.812-2.009c.092-.68.123-1.505.134-2.539M6.25 16a.75.75 0 0 1 .75-.75h1.5a.75.75 0 0 1 0 1.5H7a.75.75 0 0 1-.75-.75m8.5 0a.75.75 0 0 1 .75-.75H17a.75.75 0 0 1 0 1.5h-1.5a.75.75 0 0 1-.75-.75" clip-rule="evenodd" />
                    </svg>
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