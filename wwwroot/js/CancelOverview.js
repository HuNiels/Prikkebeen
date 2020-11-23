
var submitButton = $('#button');
var checks

$(document).ready(function () {
    submitButton.click(CancelTasks);
});

function CancelTasks(event) {
    var send = new Array();
    checks = $("[id^=check]");
    let length = checks.length;
    for (let i = 0; i < length; i++) {

        if (checks[i].checked) {
            send.push($(checks[i]).val());
        }
    }

    if (send.length != 0) $("#cancellationIds").val(send);
    else event.preventDefault();
}