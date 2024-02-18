var token = getCookie("Token");

let table = new DataTable('#alumnos', {
    ajax: {
        url: `https://localhost:7025/api/Alumno/Alumnos`,
        dataSrc: "",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'nombre', title: 'Nombre' },
        { data: 'apellido', title: 'Apellido' },
        { data: 'dni', title: 'Dni' },
        {
            data: 'fechaInscripcion',
            title: 'Fecha Inscripcion',
            render: function (data) {
                // Formatear la fecha en el formato deseado (año/mes/día)
                var fecha = new Date(data);
                return fecha.toLocaleDateString('es-ES'); // Cambia 'es-ES' por el código de tu idioma si es necesario
            }
        },
        {
            data: function (data) {
                var botones =
                    `<td><a href='javascript:EditarAlumno(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarAlumno"></i></td>` +
                    `<td><a href='javascript:EliminarAlumno(${JSON.stringify(data)})'><i class="fa-solid fa-trash eliminarAlumno"></i></td>`
                return botones;
            }
        }
    ]
});

function AgregarAlumno() {
    $.ajax({
        type: "GET",
        url: "/Alumnos/AlumnosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#alumnosAddPartial').html(resultado);
            $('#alumnoModal').modal('show');
        }

    });
}

function EditarAlumno(data) {
    $.ajax({
        type: "POST",
        url: "/Alumnos/AlumnosAddPartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#alumnosAddPartial').html(resultado);
            $('#alumnoModal').modal('show');
        }
    });
    return true;
}


function EliminarAlumno(data) {
    $.ajax({
        type: "POST",
        url: "/Alumnos/AlumnosDeletePartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#alumnosAddPartial').html(resultado);
            $('#alumnoModal').modal('show');
        }
    });
    return true;
}