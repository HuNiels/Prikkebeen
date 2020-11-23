$(document).ready(function () {
    init();
});

var hour48Notice = 'Let op: u annuleert deze afspraak minder dan 48 uur van te voren, hiervoor wordt 50% van het consult in rekening gebracht.';
var oneHourNotice = 'Let op: u annuleert deze afspraak minder dan 1 uur voor de afspraak, wij moeten helaas het hele consult in rekening brengen.';
var AdminNotice = 'Let op: u annuleert deze afspraak nu zonder kosten voor uw client.';

function init() {
    var links = document.querySelectorAll('#cancelLink')
    links.forEach(function (link) {
        link.addEventListener('click', function (event) {
            sendRequest(event, link);
        })
    })
}

function sendRequest(event, elem) {
    let formData = new FormData();
    let id = $(elem).data('resid');
    formData.append("id", id);

    $.ajax({
        url: '/Reservation/CancelInfo',
        method: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (result) {
            handleResponse(event, result, id);
        },
        error: function (result) {
            console.log("Ajax POST to /Reservation/CancelInfo failed: " + JSON.stringify(result));
        }
    });
};

function handleResponse(event, data, id) {
    let cancel = popupWarning(data);
    if (cancel) {
        window.location = '/Reservation/CancelReservation/' + id;
    } else {
        event.preventDefault();
    }
}

function popupWarning(type) {
    let confirmed;
    switch (type) {
        // case 0 is cancellation in time, so no need for a pop-up
        case 1:
            confirmed = confirm(hour48Notice);
            break;
        case 2:
            confirmed = confirm(oneHourNotice);
            break;
        case 3:
            confirmed = confirm(AdminNotice);
        default:
            confirmed = true;
            break;
    }
    return confirmed;
}