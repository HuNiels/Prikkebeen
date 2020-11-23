$(document).ready(function () {
    $('#submit').click(validateDescription);
});

var descError = '';

var descField = $('#description');

var descErrorSpan = $('#descriptionError');


function validateDescription(event) {
    let descFieldVal = descField.val();
    if (descFieldVal === "") {
        descError = "Beschrijving is vereist";
    } else {
        descError = '';
    }

    showErrorField(descError, descErrorSpan);

    if (descError != '') {
        event.preventDefault();
    }
};

function showErrorField(error, elem) {
    if (error === '') {
        elem.hide();
    } else {
        elem.text(error);
        elem.show();
    }
}
