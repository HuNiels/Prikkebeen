var firstNameError = '';
var lastNameError = '';
var addressError = '';
var postalCodeError = '';
var cityError = '';
var telephoneNumberError = '';
var emailError = '';
var passwordError = '';

var countryMapping = {
    Nederland: "+31",
    België: "+32",
    Duitsland: "+49"
};

var firstNameField = $('#firstName');
var lastNameField = $('#lastName');
var addressField = $('#address');
var houseNumberField = $('#houseNumber');
var postalCodeField = $('#postalCode');
var cityField = $('#city');
var countryField = $('#country');
var telephonePrefixField = $('#telephoneNumberPrefix');
var telephoneNumberMainField = $('#telephoneNumberMain');
var telephoneNumberField = $('#telephoneNumber');
var emailField = $('#email');
var password1Field = $('#password1');
var password2Field = $('#password2');

var firstNameErrorSpan = $('#firstNameError');
var lastNameErrorSpan = $('#lastNameError');
var addressErrorSpan = $('#addressError');
var postalCodeErrorSpan = $('#postalCodeError');
var cityErrorSpan = $('#cityError');
var telephoneNumberErrorSpan = $('#telephoneNumberError');
var emailErrorSpan = $('#emailError');
var passwordErrorSpan = $('#passwordError');

var emailFormat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
var firstNameFormat = /^[\u00C0-\u017Fa-zA-Z'-]+$/;
var lastNameFormat = /^[\u00C0-\u017Fa-zA-Z'-]+( [\u00C0-\u017Fa-zA-Z'-]+)*$/;
var passwordFormat = /^(?=.{1,64}$)[A-Za-z0-9@#$%!&*]*[A-Za-z]+[A-Za-z0-9@#$%!&*]*$/;
var addressFormat = /^[A-Za-z0-9]+( [A-Za-z0-9]+)*$/;
var houseNumberFormat = /^[0-9]+[A-Za-z]*$/;
var postalCodeFormat = /^[A-Za-z0-9]+$/;
var cityFormat = /^[A-Za-z'-]+( [A-Za-z'-]+)*$/;
var telephoneNumberFormat = /^[0-9]+([- ][0-9]+)*$/;

$(document).ready(function () {
    $('#submit').click(function (event) {
        validateRegistration(event);
        prepareSubmit();
    });
    countryField.change(changeTelephonePrefix);
});

function validateRegistration(event) {
    validateFirstName();
    validateLastName();
    validateHouseNumber();
    validateAddress();
    validatePostalCode();
    validateCity();
    validateTelephoneNumber();
    validateEmail();
    validatePassword();

    showErrorField(firstNameError, firstNameErrorSpan);
    showErrorField(lastNameError, lastNameErrorSpan);
    showErrorField(addressError, addressErrorSpan);
    showErrorField(postalCodeError, postalCodeErrorSpan);
    showErrorField(cityError, cityErrorSpan);
    showErrorField(telephoneNumberError, telephoneNumberErrorSpan);
    showErrorField(emailError, emailErrorSpan);
    showErrorField(passwordError, passwordErrorSpan);

    if (firstNameError != '' || lastNameError != '' || addressError != '' || postalCodeError != '' ||
        cityError != ''|| telephoneNumberError != '' || emailError != '' || passwordError != '') {
        event.preventDefault();
    }
};

function validateFirstName() {
    let firstNameFieldVal = firstNameField.val();
    if (firstNameFieldVal === "") {
        firstNameError = 'Voornaam is vereist';
    } else if (!firstNameFormat.test(firstNameFieldVal)) {
        firstNameError = 'Voornaam mag alleen letters bevatten';
    } else {
        firstNameError = '';
    }
}

function validateLastName() {
    let lastNameFieldVal = lastNameField.val();
    if (lastNameFieldVal === "") {
        lastNameError = 'Achternaam is vereist';
    } else if (!lastNameFormat.test(lastNameFieldVal)) {
        lastNameError = 'Achternaam is incorrect geformatteerd';
    } else {
        lastNameError = '';
    }
}

function validateAddress() {
    let addressFieldVal = addressField.val();
    if (addressFieldVal === "") {
        addressError = 'Adres is vereist';
    } else if (!addressFormat.test(addressFieldVal)) {
        addressError = 'Adres is incorrect geformatteerd';
    } // No else in order to get house number error to overwrite it
};

function validateHouseNumber() {
    let houseNumberFieldVal = houseNumberField.val();
    if (houseNumberFieldVal === "") {
        addressError = 'Huisnummer is vereist';
    } else if (!houseNumberFormat.test(houseNumberFieldVal)) {
        addressError = 'Huisnummer is incorrect geformatteerd';
    } else {
        addressError = '';
    }
};

function validatePostalCode() {
    let postalCodeFieldVal = postalCodeField.val();
    if (postalCodeFieldVal === "") {
        postalCodeError = 'Postcode is vereist';
    } else if (!postalCodeFormat.test(postalCodeFieldVal)) {
        postalCodeError = 'Postcode is incorrect geformatteerd';
    } else {
        postalCodeError = '';
    }
};

function validateCity() {
    let cityFieldVal = cityField.val();
    if (cityFieldVal === "") {
        cityError = 'Woonplaats is vereist';
    } else if (!cityFormat.test(cityFieldVal)) {
        cityError = 'Woonplaats is incorrect geformatteerd';
    } else {
        cityError = '';
    }
};

function validateTelephoneNumber() {
    let telephoneNumberFieldVal = telephoneNumberMainField.val();
    if (telephoneNumberFieldVal === "") {
        telephoneNumberError = 'Telefoonnummer is vereist';
    } else if (!telephoneNumberFormat.test(telephoneNumberFieldVal)) {
        telephoneNumberError = 'Telefoonnummer is incorrect geformatteerd';
    } else {
        telephoneNumberError = '';
    }
};

function validateEmail() {
    let emailFieldVal = emailField.val();
    if (emailFieldVal === "") {
        emailError = "Emailadres is vereist";
    } else if (!emailFormat.test(emailFieldVal)) {
        emailError = 'Emailadres is niet geldig';
    } else {
        emailError = '';
    }
}

function validatePassword() {
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
}

function showErrorField(error, elem) {
    if (error === '') {
        elem.hide();
    } else {
        elem.text(error);
        elem.show();
    }
};

function changeTelephonePrefix() {
    let prefix = countryMapping[countryField.val()];
    telephonePrefixField.val(prefix);
}

function prepareSubmit() {
    let tel = telephonePrefixField.val() + '-' + telephoneNumberMainField.val();
    telephoneNumberField.val(tel);
}