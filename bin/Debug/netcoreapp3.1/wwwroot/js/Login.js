$(document).ready(function () {
    $('#submit').click(validateLogin);
});

var emailError = '';
var passwordError = '';

var emailField = $('#email');
var passwordField = $('#password');

var emailErrorSpan = $('#emailError');
var passwordErrorSpan = $('#passwordError');

var emailFormat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

function validateLogin(event) {
    let emailFieldVal = emailField.val();
    if (emailFieldVal === "") {
        emailError = "Emailadres is vereist";
    } else if (!emailFormat.test(emailFieldVal)) {
        emailError = 'Emailadres is niet geldig';
    } else {
        emailError = '';
    }

    if (passwordField.val() === "") {
        passwordError = 'Wachtwoord is vereist';
    } else {
        passwordError = '';
    }

    showErrorField(emailError, emailErrorSpan);
    showErrorField(passwordError, passwordErrorSpan);

    if (emailError != '' || passwordError != '') {
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