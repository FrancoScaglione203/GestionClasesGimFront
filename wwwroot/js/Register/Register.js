$(document).ready(function () {
    // Escuchar cambios en el campo de entrada de la URL de la imagen
    $('#imagenUrlInput').on('input', function () {
        // Actualizar el atributo src de la imagen con la URL ingresada
        $('#imagenPreview').attr('src', $(this).val());
    });
});

document.getElementById("btnCancelar").addEventListener("click", function () {
    // Redirige al usuario a la acción "Login" del controlador "Login"
    window.location.href = "/Login/Login";
});