var submit = $('#submit');
var queryField = $('#queryField');
var resultsTable = $('#searchResults');
var resultsError = $('#noResults');

$(document).ready(function () {
    $(document).bind('keypress', function (event) {
        if (event.keyCode == 13) {
            submit.trigger('click');
        }
    })
    submit.click(sendQuery);
});

function sendQuery(event) {
    let query = queryField.val();

    // No need to send a query if the search field is empty
    if (query === '') {
        return;
    }

    let formData = new FormData();
    formData.append("query", query);

    $.ajax({
        url: '/User/ClientSearch',
        method: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (result) {
            showResults(result);
        },
        error: function (result) {
            console.log("Ajax POST to /User/ClientSearch failed: " + JSON.stringify(result));
        }
    });
};

function showResults(results) {
    deleteOldResults();
    if (results.length === 0) {
        resultsError.show();
    } else {
        resultsError.hide();
        for (let i = 0; i < results.length; i++) {
            showRow(results[i].id, results[i].fullName, results[i].email, results[i].phoneNumber);
        }
    }
}

function showRow(id, fullName, email, phoneNumber) {
    let row =
        '<tr style="cursor:pointer" onclick="showClientFile('+id+')" onMouseOver="showHover(this)" onMouseOut="showNormal(this)">' +
            '<td class="p-1 align-middle">' + fullName + '</td>' +
            '<td class="p-1 align-middle">' + email + '</td>' +
            '<td class="p-1 align-middle">' + phoneNumber + '</td>' +
        '</tr>';
    resultsTable.append(row);
}

function showHover(elem) {
    elem.bgColor = "#336699";
    $(elem).css('color', 'white');
}

function showNormal(elem) {
    elem.bgColor = "white";
    $(elem).css('color', 'black');
}

function showClientFile(id) {
    window.location = '/User/File/'+id;
}

function deleteOldResults() {
    resultsTable.empty();
};