$(document).ready(function () {
    $('#submit').click(validatePasswords);
});

var oldPasswordError = '';
var passwordError = '';

var oldPasswordField = $('#oldPassword');
var password1Field = $('#password1');
var password2Field = $('#password2');

var oldPasswordErrorSpan = $('#oldPasswordError');
var passwordErrorSpan = $('#passwordError');

var passwordFormat = /^(?=.{1,64}$)[A-Za-z0-9@#$%!&*]*[A-Za-z]+[A-Za-z0-9@#$%!&*]*$/;

function validatePasswords(event) {
    let oldPasswordFieldVal = oldPasswordField.val();
    if (oldPasswordFieldVal === "") {
        oldPasswordError = 'Wachtwoord is vereist';
    } else {
        oldPasswordError = '';
    }

    let password1FieldVal = password1Field.val();
    if (password1FieldVal === "") {
        passwordError = 'Wachtwoord is vereist';
    } else if (!passwordFormat.test(password1FieldVal)) {
        passwordError = 'Wachtwoord voldoet niet aan de eisen';
    } else if (password1FieldVal != password2Field.val()) {
        passwordError = 'Wachtwoorden zijn niet gelijk';
    } else {
        passwordError = '';
    }

    showErrorField(oldPasswordError, oldPasswordErrorSpan);
    showErrorField(passwordError, passwordErrorSpan);

    if (oldPasswordError != '' || passwordError != '') {
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
};