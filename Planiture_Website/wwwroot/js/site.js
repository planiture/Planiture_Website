// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//KINGZWILL ADDED THE FOLLOWING
window.addEventListener("scroll", function () {
    var header = document.querySelector("header");
    header.classList.toggle("sticky", window.scrollY > 0);
})


//The following is for uploading files
Array.prototype.forEach.call(document.querySelectorAll('.upload-btn'), function (button) {
    const hiddenInput = button.parentElement.querySelector('.file-input');
    const label = button.parentElement.querySelector('.upload-label');
    const defaultLabelText = 'No file(s) selected';

    //Sets default text for label
    label.textContent = defaultLabelText;
    label.title = defaultLabelText;

    //this triggers the file selecting browser function
    button.addEventListener('click', function () {
        hiddenInput.click();
    });

    hiddenInput.addEventListener('change', function () {

        const filenameList = Array.prototype.map.call(hiddenInput.files, function (file) {
            return file.name;
        });

        label.textContent = filenameList.join(', ') || defaultLabelText;
        label.title = label.textContent;
    });
})

//displays a form on screen when the deposit form button is clicked

var modalBtns = document.querySelectorAll(".modal-open");

modalBtns.forEach(function (btn) {
    btn.onclick = function () {
        var modal = btn.getAttribute("data-modal");

        document.getElementById(modal).style.display = "flex";
    }
});


//close the form after it has been opened

var closeBtns = document.querySelectorAll('.modal-close');

closeBtns.forEach(function (btn) {
    btn.onclick = function () {
        var modal = btn.closest(".modal").style.display = "none";
    }
});

//display and hide INFORMATION CENTER answers

var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        this.classList.toggle("active");

        var panel = this.nextElementSibling;

        if (panel.style.maxHeight) {
            panel.style.maxHeight = null;
        } else {
            panel.style.maxHeight = panel.scrollHeight
                + "px";
        }
    });
}