$(document).ready(function () {
    $('#imagenUrl').on('input', function () {
        // Actualizar el atributo src de la imagen con la URL ingresada
        $('#imagenPreview').attr('src', $(this).val());
    });

    $('#editarPerfil').click(function () {
        // Habilitar la edición de los campos
        $('input[readonly]').prop('readonly', false);

        // Ocultar el botón "Editar" y mostrar los botones "Confirmar" y "Cancelar"
        $('#editarPerfil').hide();
        $('#footerButtons').show();
        $('#btnGuardar').show();
        $('[data-bs-dismiss="modal"]').show();
    });

    // Controlador de eventos para el botón "Cancelar"
    $('#btnCancelar').click(function () {
        // Deshabilitar la edición de los campos y volverlos de solo lectura
        $('input[readonly]').prop('readonly', true);

        // Mostrar el botón "Editar" y ocultar los botones "Confirmar" y "Cancelar"
        $('#editarPerfil').show();
        $('#footerButtons').hide();
        $('#btnGuardar').hide();
        $('[data-bs-dismiss="modal"]').hide();
    });
});

$('#btnGuardar').click(function () {
    // Captura los valores de los campos del formulario
    var nombre = $('#nombreAlumno').val();
    var apellido = $('#apellidoAlumno').val();
    var dni = $('#dniAlumno').val();
    var clave = $('#claveAlumno').val();
    var roleId = $('#roleIdAlumno').val();
    var imagenUrl = $('#imagenUrlAlumno').val();

    // Crea un objeto con los datos a enviar
    var data = {
        Nombre: nombre,
        Apellido: apellido,
        Dni: dni,
        Clave: clave,
        RoleId: roleId,
        ImagenUrl: imagenUrl
    };

    // Realiza una solicitud AJAX al controlador para guardar los datos
    $.ajax({
        type: 'POST',
        url: '/Perfil/GuardarAlumno', // Ruta de la acción del controlador
        data: data,
        success: function (response) {
            // Maneja la respuesta del servidor si es necesario
            console.log('Datos guardados correctamente');
            window.location.href = "/Perfil/Perfil";
        },
        error: function (xhr, status, error) {
            // Maneja los errores si es necesario
            console.error('Error al guardar los datos:', error);
        }
    });
});


