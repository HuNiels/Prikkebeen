const timeslotRow = 'timeslotRow';

var prevDay = null;
var nextDay = null;
var timeslotData = null;
var selection = null;

var submitButton = $('#submitButton');
var dateField = $('#dateField');
var timeslots = $('#timeslotTable');
var weekendError = $('#weekendError');
var selectionError = $('#selectionError');
var hasReservationError = $('#hasReservationError');
var prepareDate = $('#prepareDate');
var prepareId = $('#prepareId');
var yesterdayButton = $('#yesterdayButton');
var tomorrowButton = $('#tomorrowButton');
var userId = $('#prepareUserId');
var blockedMessage = $('#blockedMessage');

$(document).ready(function () {
    submitButton.click(validateSelection);
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

function selectRow(elem) {
    selection = parseInt($(elem).attr('id').replace(timeslotRow, ''));
    $('.bg-info').removeClass('bg-info');
    $(elem).find('#tdAvailable').addClass('bg-info');
};

function validateSelection(event) {
    if (selection === null) {
        selectionError.show();
        event.preventDefault();
    } else {
        selectionError.hide();
        prepareSubmit();
    }
};

function prepareSubmit() {
    prepareDate.val(dateField.val());
    prepareId.val(timeslotData[selection].id);
};

function getSchedule() {
    let date = dateField.val();
    let formData = new FormData();
    formData.append("date", date);

    // This script is used for both Schedule and AdminSchedule. AdminSchedule has a hidden field called userId.
    if (userId.length) {
        formData.append("userId", userId.val());
    }

    $.ajax({
        url: '/Reservation/Schedule',
        method: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (result) {
            prevDay = convertToDateFormat(new Date(result.previousDay));
            nextDay = convertToDateFormat(new Date(result.nextDay));
            updateTimeslots(result.timeslots);
            updateBlockedMessage(result.customerMessage);
        },
        error: function (result) {
            console.log("Ajax POST to /Reservation/Schedule failed: " + JSON.stringify(result));
        }
    });
};

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
        hasReservationError.show();
        submitButton.show();
    } else {
        timeslotData = null;
        weekendError.show();
        hasReservationError.hide();
        submitButton.hide();
    }
};

function updateBlockedMessage(data) {
    
    if (data != null) {
        blockedMessage.show();           
        blockedMessage.text(data);
    }
    else
    {
        blockedMessage.hide();
    }
}

function showTimeslots(data) {
    for (let i = 0; i < data.length; i++) {
        showTimeslot(i, data[i].startTime, data[i].endTime, data[i].available, data[i].currentUser);
    }
};

function showTimeslot(id, start, end, available, currentUser) {
    let row =
        '<tr style="cursor:pointer"' + (available === true ? ' id="' + timeslotRow + id + '" onclick="selectRow(this)"' : '') + '>' +
        '<td class="p-2">' + displayTime(start) + ' - ' + displayTime(end) + '</td>' +
        (currentUser ? '<td class="p-2 bg-success">Uw reservering</td>' : (available === true ? '<td class="p-2" id="tdAvailable">Beschikbaar</td>' : '<td class="p-2 bg-secondary">Onbeschikbaar</td>')) +
        '</tr>';
    timeslots.append(row);
};

function deleteTimeslots() {
    timeslots.empty();
};