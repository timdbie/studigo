function formatTime(datetime) {
    var date = new Date(datetime);
    var hours = date.getHours();
    var minutes = date.getMinutes();

    return hours + ":" + minutes;
}
