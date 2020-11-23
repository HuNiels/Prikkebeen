const timeslotRow = 'timeslotRow';

var prevDay = null;
var nextDay = null;
var timeslotData = null;
var selection = null;

var dateField = $('#dateField');
var timeslots = $('#timeslotTable');
var weekendError = $('#weekendError');
var yesterdayButton = $('#yesterdayButton');
var tomorrowButton = $('#tomorrowButton');

$(document).ready(function () {
    yesterdayButton.click(function () {
        dateField.val(prevDay);
        getSchedule();
    });
    tomorrowButton.click(function () {
        dateField.val(nextDay);
        getSchedule();
    });

    dateField.change(getSchedule);
    getSchedule();
});

function getSchedule() {
    let date = dateField.val();
    let formData = new FormData();
    formData.append("date", date);

    $.ajax({
        url: '/Reservation/AdminOverview',
        method: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (result) {
            prevDay = convertToDateFormat(new Date(result.previousDay));
            nextDay = convertToDateFormat(new Date(result.nextDay));
            updateTimeslots(result.timeslots);
        },
        error: function (result) {
            console.log("Ajax POST to /Reservation/AdminOverview failed: " + JSON.stringify(result));
        }
    });
};

function addDaysToDate(days) {
    let currentDate = new Date(dateField.val());
    currentDate.setDate(currentDate.getDate() + days);
    dateField.val(convertToDateFormat(currentDate));
}

function convertToDateFormat(date) {
    let temp = date;
    let day = new Intl.DateTimeFormat('en', { day: '2-digit' }).format(temp);
    let month = new Intl.DateTimeFormat('en', { month: '2-digit' }).format(temp);
    let year = new Intl.DateTimeFormat('en', { year: 'numeric' }).format(temp);
    return `${year}-${month}-${day}`;
}

function displayTime(time) {
    return `${time.hours.toString().padStart(2, '0')}:${time.minutes.toString().padStart(2, '0')}`;
};

function updateTimeslots(data) {
    selection = null;
    deleteTimeslots();
    if (data.length > 0) {
        timeslotData = data;
        showTimeslots(data);
        weekendError.hide();
    } else {
        timeslotData = null;
        weekendError.show();
    }
};

function showTimeslots(data) {
    for (let i = 0; i < data.length; i++) {
        showTimeslot(data[i].startTime, data[i].endTime, data[i].userId, data[i].userName, data[i].doubleSlot);
    }
};

function showTimeslot(start, end, userId, username, double) {
    let row =
        '<tr' + (userId != 0 ? (' onclick="showClientFile(' + userId + ')"') : '') + ' style="height:' + (double ? '6' : '3') + 'rem' + (userId != 0 ? ';cursor:pointer' : '') + '">' +
                '<td class="p-0 align-middle">' + displayTime(start) + ' - ' + displayTime(end) + '</td>' +
                '<td class="p-0 align-middle '+ (username === null ? '' : 'bg-success') +'">' + (username === null ? 'Vrij' : username) + '</td>' +
            '</tr>';
    timeslots.append(row);
};

function deleteTimeslots() {
    timeslots.empty();
};

function showClientFile(id) {
    window.location = '/User/File/' + id;
}