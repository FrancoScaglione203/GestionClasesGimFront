var token = getCookie("Token");

let table = new DataTable('#usuarios', {
    ajax: {
        url: `https://localhost:7025/api/Usuario/Usuarios`,
        dataSrc: "",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'nombre', title: 'Nombre' },
        { data: 'apellido', title: 'Apellido' },
        { data: 'dni', title: 'Dni' },
        { data: 'roleId', title: 'Role' },
        {
            data: function (data) {
                var botones =
                    `<td><a href='javascript:EditarUsuario(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarUsuario"></i></td>`+
                    `<td><a href='javascript:EliminarUsuario(${JSON.stringify(data)})'><i class="fa-solid fa-trash eliminarUsuario"></i></td>`
                return botones;
            }
        }
    ]
});

function AgregarUsuario() {
    $.ajax({
        type: "GET",
        url: "/Usuarios/UsuariosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal').modal('show');
        }

    });
}

function EditarUsuario(data) {
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddPartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal').modal('show');
        }
    });
    return true;
}


function EliminarUsuario(data) {
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosDeletePartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal').modal('show');
        }
    });
    return true;
}