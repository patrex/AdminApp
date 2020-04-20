// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


const AddBtn = document.querySelector('#increment');
const IncBtn = document.querySelector('#add-btn');

AddBtn.addEventListener('click', () => {
    IncBtn.style.display = 'block';
}, false);