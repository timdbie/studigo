function formatTime(datetime) {
    var date = new Date(datetime);
    var hours = date.getHours();
    var minutes = date.getMinutes();

    return `${hours}:${minutes.toString().padStart(2, '0')}`;
}

function formatDate(datetime) {
    var date = new Date(datetime);
    var year = date.getFullYear();
    var month = (date.getMonth() + 1).toString().padStart(2, '0');
    var day = date.getDate().toString().padStart(2, '0');

    return `${year}-${month}-${day}`;
}
