// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(window).on('beforeunload', function () {
    $('#page-loader').fadeIn(200);
});

$(document).ready(function () {
// Esconder el loader con un retraso para que se aprecie la animación
setTimeout(function() {
    $('#page-loader').fadeOut(500);
}, 400); // 400ms de espera extra

    // Mostrar loader en form submit (si el form es válido)
    $('form').on('submit', function () {
        if (!$(this).valid || $(this).valid()) {
            $('#page-loader').fadeIn(200);
        }
    });

    // Mostrar loader cuando damos click a enlaces que navegan
    $('a').on('click', function (e) {
        var href = $(this).attr('href');
        var target = $(this).attr('target');
        
        // Excluimos links que sean anclas (#), invocaciones js, o pestañas nuevas
        if (href && href.indexOf('#') !== 0 && href.indexOf('javascript') !== 0 && target !== '_blank' && !$(this).hasClass('no-loader')) {
            $('#page-loader').fadeIn(200);
        }
    });
});

window.onpageshow = function (event) {
    if (event.persisted) {
        setTimeout(function() {
            $('#page-loader').fadeOut(10s00);
        }, 400);
    }
};
