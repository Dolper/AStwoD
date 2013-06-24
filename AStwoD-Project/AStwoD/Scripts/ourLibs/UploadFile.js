function uploadFile() {
    var xhr = new XMLHttpRequest();
    var fd = new FormData();
    fd.append("filesUpload", document.getElementById('form').filesUpload.files);
    xhr.upload.addEventListener("progress", uploadProgress, false);
    xhr.addEventListener("load", uploadComplete, false);
    xhr.addEventListener("error", uploadFailed, false);
    xhr.addEventListener("abort", uploadCanceled, false);

    xhr.open("POST", "UploadImage");
    xhr.send(fd);
}

function fileSelected() {
    var file = document.getElementById('file').files[0];

    if (file) {
        var fileSize = 0;
        if (file.size > 1024 * 1024) {
            fileSize = (Math.round(file.size * 100 / (1024 * 1024)) / 100).toString() + ' Mb';
        } else {
            fileSize = (Math.round(file.size * 100 / 1024) / 100).toString() + ' Kb';
        }
        document.getElementById('fileName').innerHTML = 'Имя файла:' + file.name;
        document.getElementById('fileSize').innerHTML = 'Размер файла:' + fileSize;
        document.getElementById('fileType').innerHTML = 'Тип файла:' + file.type;

    }
}

/*Event Handlers*/
function uploadProgress(e) {
    if (e.lengthComputable) {
        var percentComplete = Math.round(e.loaded * 100 / e.total);
        document.getElementById('progressNumber').innerHTML = percentComplete.toString() + "%";
    } else {
        document.getElementById('progressNumber').innerHTML = 'не могу вычислить';
    }
}

function uploadComplete(e) {
    alert(e.target.responseText);
}

function uploadFailed() {
    alert('Сбой загрузки файлов');
}

function uploadCanceled() {
    alert('загрузка отменена');
}

