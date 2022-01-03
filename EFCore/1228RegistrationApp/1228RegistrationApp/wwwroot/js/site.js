// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Demo using plain javascript
var button = document.getElementsByClassName('Inactive');
var clickBtn = document.getElementsByClassName('click')[0];

// Disable the button on initial page load
button.disabled = true;
for (var i = 0; i < button.length; i++) {
    button[i].disabled = true;
}
//add event listener
clickBtn.addEventListener('click', function (event) {
    for (var i = 0; i < button.length; i++) {
        button[i].disabled = !button[i].disabled;
    }
});

//button.addEventListener('click', function (event) {
//    alert('Enabled!');
//});