// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function setTime() {
    document.getElementById('currentTime').innerHTML = new Date().toDateString()
}


function userIntroJS() {


    //profile picture cropper start\
    function initiateCropper() {

        var picture = $('#dpUploadedImage');  // Must be already loaded or cached!
        picture.one('load', function () {
            picture.guillotine({ width: 400, height: 400 });
            picture.guillotine('fit');

            $('#rotate-left').click(function () {
                picture.guillotine('rotateLeft');
            });

            $('#rotate-right').click(function () {
                picture.guillotine('rotateLeft');
            });

            $('#zoom-in').click(function () {
                picture.guillotine('zoomIn');
            });

            $('#zoom-out').click(function () {
                picture.guillotine('zoomOut');
            });

            $('#fit').click(function () {
                picture.guillotine('fit');
            });
        });
    }

    initiateCropper();
    //profile picture cropper end

    //select an image and preview
    $('#dpFileSelector').change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#dpUploadedImage').attr('src', e.target.result);
                $('#dpUploadedImage').guillotine('remove');
                initiateCropper();
                document.getElementById("dpUploadStatus").innerHTML = "Drag Image To Set Position";
            }
            reader.readAsDataURL(this.files[0]);
            
        }
    });


}

