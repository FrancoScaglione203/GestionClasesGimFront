var token = getCookie("Token");

$(document).ready(function () {
    
    var dniAlumno = $("#dniSession").val();

    // Llamar al endpoint para obtener la lista de clases
    $.ajax({
        type: "GET",
        url: 'https://localhost:7025/api/Clase/ClasesxAlumno?dniAlumno=' + dniAlumno,
        dataSrc: "",
        headers: { "Authorization": "Bearer " + token },
        success: function (response) {
            console.log(response);
            mostrarClases(response);


            obtenerClasesRestantes();
          
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText); // Manejar errores de la solicitud AJAX aquí
        }
    });
});

function obtenerClasesRestantes() {
    var dniAlumno = $("#dniSession").val();

    // Llamar al endpoint para obtener la lista de clases restantes
    $.ajax({
        type: "GET",
        url: 'https://localhost:7025/api/Clase/ClasesRestantesxAlumno?dniAlumno=' + dniAlumno,
        headers: { "Authorization": "Bearer " + token },
        success: function (response) {
            console.log(response);
            mostrarClasesRestantes(response);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText); // Manejar errores de la solicitud AJAX aquí
        }
    });
}

function mostrarClases(response) {
    var dniAlumno = $("#dniSession").val();
    // Limpiar cualquier contenido existente en el contenedor de clases
    $('#listaClases').empty();

    // Iterar sobre la lista de clases y crear elementos HTML para mostrarlas
    response.forEach(function (clase) {
        var fechaInscripcion = new Date(clase.fechaInscripcion);
        var cupos = clase.cupos.toString();
        var capacidadMax = clase.capacidadMax.toString();
        var claseHtml = `<div class="card">
                            <div class="card-body">
                                <h5 class="card-title">${clase.nombre}</h5>
                                <p class="card-text">Fecha de inscripción: ${fechaInscripcion.toLocaleDateString()}</p>
                                <p class="card-text">Inscriptos: ${cupos}</p>
                                <p class="card-text">Capacidad máxima: ${capacidadMax}</p>
                                <img src="${clase.imagenUrl}" alt="Imagen de la clase" class="img-fluid" style="width: 200px; height: auto;"/>
                                <button class="btn btn-primary btn-solicitarC" data-clase-id="${clase.id}" data-dni-alumno="${dniAlumno}">Solicitar cancelacion</button>
                            </div>
                        </div>`;
        $('#listaClases').append(claseHtml);
    });
    $('.btn-solicitarC').click(function () {
        var claseId = $(this).data('clase-id');
        var dniAlumno = $(this).data('dni-alumno');
        solicitarCancelacion(claseId, dniAlumno);
    });

}

function mostrarClasesRestantes(response) {
    // Limpiar cualquier contenido existente en el contenedor de clases restantes
    var dniAlumno = $("#dniSession").val();
    $('#listaClasesDisponibles').empty();

    // Iterar sobre la lista de clases y crear elementos HTML para mostrarlas
    response.forEach(function (clase) {
        var fechaInscripcion = new Date(clase.fechaInscripcion);
        var cupos = clase.cupos.toString();
        var capacidadMax = clase.capacidadMax.toString();
        var claseHtml = `<div class="card">
                            <div class="card-body">
                                <h5 class="card-title">${clase.nombre}</h5>
                                <p class="card-text">Fecha de inscripción: ${fechaInscripcion.toLocaleDateString()}</p>
                                <p class="card-text">Inscriptos: ${cupos}</p>
                                <p class="card-text">Capacidad máxima: ${capacidadMax}</p>
                                <img src="${clase.imagenUrl}" alt="Imagen de la clase" class="img-fluid" style="width: 200px; height: auto;"/>
                                <button class="btn btn-primary btn-solicitar" data-clase-id="${clase.id}" data-dni-alumno="${dniAlumno}">Solicitar inscripcion</button>
                            </div>
                        </div>`;
        $('#listaClasesDisponibles').append(claseHtml);
    });
    $('.btn-solicitar').click(function () {
        var claseId = $(this).data('clase-id');
        var dniAlumno = $(this).data('dni-alumno');
        solicitarInscripcion(claseId, dniAlumno);
    });
}


function solicitarInscripcion(claseId, dniAlumno) {
    var token = getCookie('Token');


    $.ajax({
        type: 'PUT',
        url: '/Clases/Inscripcion',
        data: {
            idClase: claseId,
            dniAlumno: dniAlumno
        },
        headers: { 'Authorization': 'Bearer ' + token },
        success: function (response) {
            console.log('Inscripción exitosa');
            // Puedes realizar alguna acción adicional después de la inscripción, como actualizar la interfaz de usuario
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText); // Manejar errores de la solicitud AJAX aquí
        }
    });
}

function solicitarCancelacion(claseId, dniAlumno) {
    var token = getCookie('Token');


    $.ajax({
        type: 'PUT',
        url: '/Clases/Cancelacion',
        data: {
            idClase: claseId,
            dniAlumno: dniAlumno
        },
        headers: { 'Authorization': 'Bearer ' + token },
        success: function (response) {
            console.log('cancelacion exitosa');
            // Puedes realizar alguna acción adicional después de la inscripción, como actualizar la interfaz de usuario
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText); // Manejar errores de la solicitud AJAX aquí
        }
    });
}