var Upload = function (file) {
    this.file = file;
};

Upload.prototype.getType = function () {
    return this.file.type;
};
Upload.prototype.getSize = function () {
    return this.file.size;
};
Upload.prototype.getName = function () {
    return this.file.name;
};
Upload.prototype.doUpload = function () {
    var that = this;
    var formData = new FormData();
    var att = $("#fileupload").attr('up-type');
    var img = $("#fileupload").attr('ip-h');
    //alert(img);

    $("#progress-wrp").show();

    // add assoc key values, this will be posts values
    formData.append("file", this.file, this.getName());
    formData.append("upload_file", true);

    $.ajax({
        type: "POST",
        url: "/Upload?f=" + att,
        xhr: function () {
            var myXhr = $.ajaxSettings.xhr();
            if (myXhr.upload) {
                myXhr.upload.addEventListener('progress', that.progressHandling, false);
            }
            return myXhr;
        },
        success: function (data) {
            $("#progress-wrp").hide();
            $("#" + img).val(data);
            $("#preview-" + img).attr("src", data);
        },
        error: function (error) {
            $("#progress-wrp").hide();
            alert("upload lỗi !");
            // handle error
        },
        async: true,
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        timeout: 60000
    });
};

Upload.prototype.progressHandling = function (event) {
    var percent = 0;
    var position = event.loaded || event.position;
    var total = event.total;
    var progress_bar_id = "#progress-wrp";
    if (event.lengthComputable) {
        percent = Math.ceil(position / total * 100);
    }
    $(progress_bar_id + " .progress-bar").css("width", +percent + "%");
    $(progress_bar_id + " .status").text(percent + "%");
};
$(function () {
    $("#fileupload").on("change", function (e) {
        //alert(this.value);
        var file = $(this)[0].files[0];
        var upload = new Upload(file);
        upload.doUpload();
    });
});
