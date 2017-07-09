WEB_ROOT_HOST = 'http://192.168.1.112:930/api';
function FileUpload() {
	var data = new FormData();
	var files = $("#fileInput").get(0).files;
	// Add the uploaded image content to the form data collection
	if (files.length > 0) {
		data.append("UploadedFile", files[0]);
	}
	// Make Ajax request with the contentType = false, and procesDate = false
	var ajaxRequest = $.ajax({
		type: "POST",
		url: WEB_ROOT_HOST + '/Upload/UploadPostCB/',
		contentType: false,
		processData: false,
		data: data,
		success: function (result) {
			if (result.success) {
				document.getElementById('filePath').value = result.data;
				document.getElementById('uploadFileName').value = result.data;
				alert('上传成功');
			} else {
				alert(result.message || '上传失败');
			}
		},
		error: function (data) {
			alert('上传发生异常 status' + data.status + " statusText: " + data.statusText + " responseText: " + data.responseText);
		}
	});
}



function FileUploadA() {
	var uploadForm = document.getElementById('uploadForm');
	var fileName = document.getElementById('fileInput').value;
	if (fileName.length > 1 && fileName) {
		var fileType = fileName.substring(fileName.lastIndexOf("."));

		//$('#uploadForm').attr('action', WEB_ROOT_HOST + '/Tool/UploadPost/');
		$('#uploadForm').attr('action', WEB_ROOT_HOST + '/Upload/UploadPostCB/');

		document.getElementById('uploadForm').submit();
		document.getElementById('btnUpload').disabled = 'disabled';
	} else {
		alert('请选择上传文件');
		return;
	}
}






function callbackUpload(_result) {
	console.log('----------------------------------------------begin..');
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
	console.log('----------------------------------------------end');
}


$(function () {
	$("#btnUpload").click(function () {
		FileUpload();
	})


	$('#btnOK').click(function () {
		parent.layer.close(parent.layer.getFrameIndex(window.name));
	});

})
