// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function setTime() {
    document.getElementById('currentTime').innerHTML = new Date().toDateString()
}

function callJcrop() {

    var picture = $('#thepicture');  // Must be already loaded or cached!
    picture.guillotine({ width: 600, height: 600 });
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
}

