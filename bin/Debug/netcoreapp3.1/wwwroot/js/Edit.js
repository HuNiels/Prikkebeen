var range;

function addFormatting(command, args) {
    document.execCommand(command, false, args);
    $('#editField').focus();
}

function createLink() {
    let url = prompt('URL:', 'http://');
    addFormatting('createLink', url);
}

function openFileWindow(element) {
    if (getSelectedRange() != null) {
    $(element).trigger("click");
    } else {
    alert('Selecteer een positie om media in te plaatsen.');
    }
}

function saveSelection() {
    range = getSelectedRange()
}

function validateImage(extension) {
    switch (extension.toLowerCase()) {
        case 'jpg': break;
        case 'png': break;
        default:
            return 'Alleen jpg of png wordt geaccepteerd.';
    }
    return null;
}

function validateVideo(extension) {
    switch (extension.toLowerCase()) {
        case 'mp4': break;
        case 'webm': break;
        default:
            return 'Alleen mp4 of webm wordt geaccepteerd.';
    }
    return null;
}

function uploadFile(element, validator, type) {
    let files = element.files;
    let splitPath = $(element).val().split('.');
    let extension = splitPath[splitPath.length - 1];

    let error = validator(extension);
    if (error != null) {
        alert(error);
        $(element).val(''); // Clear file input
        return;
    }

    let formData = new FormData();
    formData.append("file", files[0]);
    $.ajax({
    url: '/File/Upload',
        method: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (result) {
            // Result should be the id of the inserted data
            if (result != 0) {
                insertMediaAtSelection(result, type);
                $(element).val('');
            }
        },
        error: function (result) {
    console.log("Ajax POST to /File/Upload failed: " + result);
        }
    });
}

function getSelectedRange() {
    let selection = window.getSelection();
    if (selection.anchorNode && selection.anchorNode.parentElement.closest("#editField") && selection.focusNode.parentElement.closest("#editField")) {
        return selection.getRangeAt(0);
    }
    return null;
}

function insertMediaAtSelection(id, type) {
    let range = getSelectedRange();
    if (range === null) {
        return;
    }

    range.deleteContents();    

    let node;
    switch (type) {
        case 'image':
            node = document.createElement("img");
            node.src = "/File/Get/" + id;
            node.className = 'img-fluid';
            break;
        case 'video':
            node = document.createElement("video");
            node.controls = true;
            node.src = "/File/Get/" + id;
            break;
    }

    range.insertNode(node);
}

function insertTagAtSelection(tag) {

    if (range === null) {
        return;
    }

    range.deleteContents();

    node = document.createElement("span");
    node.appendChild(document.createTextNode("@{"+ tag +"}"));
   
    range.insertNode(node);
    $('#editField').focus();
}

/**
 * It is necessary to put the content in a TextArea, because POST does not work correctly with the HTML in a Div.
 */
function prepareHtml() {
    $('#htmlField').html($('#editField').html());
}