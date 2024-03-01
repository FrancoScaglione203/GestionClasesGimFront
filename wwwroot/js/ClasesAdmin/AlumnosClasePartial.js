
$(document).ready(function () {
    var idClase = $("#idClase").val();
    var token = $("#Token").val();
    // Llamar al endpoint para obtener la lista de clases
    $.ajax({
        type: "GET",
        url: 'https://localhost:7025/api/Alumno/AlumnosxClase?idClase=' + idClase,
        dataSrc: "",
        headers: { "Authorization": "Bearer " + token },
        success: function (response) {
            console.log(response);
            mostrarAlumnos(response);

        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText); // Manejar errores de la solicitud AJAX aquí
        }
    });
});

// Función para mostrar la lista de alumnos en la vista
function mostrarAlumnos(alumnos) {
    // Limpiar cualquier contenido existente en el contenedor de la lista de alumnos
    $('#listaAlumnos').empty();

    // Iterar sobre la lista de alumnos y agregar cada uno al contenedor
    alumnos.forEach(function (alumno) {
        var alumnoHtml = `<div class="alumno">
                                  <p>${alumno.nombre}</p>
                                  <p>${alumno.apellido}</p>
                                  <!-- Agregar más información del alumno según sea necesario -->
                              </div>`;
        $('#listaAlumnos').append(alumnoHtml);
    });
}
