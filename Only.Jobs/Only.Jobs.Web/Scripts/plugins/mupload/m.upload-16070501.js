WEB_ROOT_HOST = 'http://adxs.civaonline.cn'
//$('#uploadForm').attr('action', WEB_ROOT_HOST + '/Tool/UploadPost/');





function FileUpload() {
    var uploadForm = document.getElementById('uploadForm');
    var fileName = document.getElementById('fileInput').value;
    if (fileName.length > 1 && fileName) {
        var fileType = fileName.substring(fileName.lastIndexOf("."));

        var postUrl = WEB_ROOT_HOST + '/Tool/UploadPost/';



        $('#uploadForm').attr('action', WEB_ROOT_HOST + '/Tool/UploadPost/');
        document.getElementById('uploadForm').submit();
        document.getElementById('btnUpload').disabled = 'disabled';
    } else {
        alert('请选择上传文件');
        return;
    }
}

function callbackUpload(_result) {
    $('#btnUpload').removeAttr("disabled");
    var result = eval("(" + _result + ")");
    if (result) {
        if (result.success) {
            document.getElementById('filePath').value = result.data;
            document.getElementById('uploadFileName').value = result.data;
            alert('上传成功');
        } else {
            alert(result.message || '上传失败');
        }
    }
}


$(function () {
    $("#btnUpload").click(function () {
        FileUpload();
    })


    $('#btnOK').click(function () {
        parent.layer.close(parent.layer.getFrameIndex(window.name));
    });

})

