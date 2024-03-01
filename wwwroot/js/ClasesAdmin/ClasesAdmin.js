var token = getCookie("Token");

$(document).ready(function () {

    // Llamar al endpoint para obtener la lista de clases
    $.ajax({
        type: "GET",
        url: 'https://localhost:7025/api/Clase/Clases',
        dataSrc: "",
        headers: { "Authorization": "Bearer " + token },
        success: function (response) {
            console.log(response);
            mostrarClases(response);


        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText); // Manejar errores de la solicitud AJAX aquí
        }
    }); 
});

function AgregarClase() {
    // Redirige a la ruta de la vista deseada
    window.location.href = '/ClasesAdmin/Partial/ClasesAddPartial.cshtml';
}


function mostrarClases(response) {
    // Limpiar cualquier contenido existente en el contenedor de clases
    $('#listaClases').empty();

    // Iterar sobre la lista de clases y crear elementos HTML para mostrarlas
    response.forEach(function (clase) {
        var fechaInscripcion = new Date(clase.fechaInscripcion);
        var cupos = clase.cupos.toString();
        var capacidadMax = clase.capacidadMax.toString();
        var id = clase.id.toString();
        var claseHtml = `<div class="card">
                            <div class="card-body">
                                <h5 class="card-title">${clase.nombre}</h5>
                                <p class="card-text">Fecha de inscripción: ${fechaInscripcion.toLocaleDateString()}</p>
                                <p class="card-text">Cupos disponibles: ${cupos}</p>
                                <p class="card-text">Capacidad máxima: ${capacidadMax}</p>
                                <p class="card-text">Id: ${id}</p>
                                <img src="${clase.imagenUrl}" alt="Imagen de la clase" class="img-fluid" style="width: 200px; height: auto;"/>
                                <button class="btn btn-primary btn-alumnos" data-clase-id="${clase.id}">Alumnos</button>
                            </div>
                        </div>`;
        $('#listaClases').append(claseHtml);
    });
    $('.btn-alumnos').click(function () {
        // Obtener el ID de la clase desde el atributo data-clase-id
        var claseId = $(this).data('clase-id');
        // Realizar alguna acción con el ID de la clase, por ejemplo, redirigir a la página de alumnos
        window.location.href = '/ClasesAdmin/alumnosClasePartial?claseId='+ claseId;
    });
}


