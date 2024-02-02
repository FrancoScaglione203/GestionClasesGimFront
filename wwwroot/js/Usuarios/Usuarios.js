var token = getCookie("Token");

let table  = new DataTable('#usuarios', {
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