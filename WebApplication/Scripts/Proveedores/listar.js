$.get("http://localhost:57916/api/proveedor").done(function (data) {
    $('#proveedores').DataTable({
        data: data,
        columns: [
            { data: 'Codigo' },
            { data: 'Nombre' },
            { data: 'Direccion' },
            { data: 'Telefono' },
            {
                "render": function (data, type, row) {
                    return "<a href='/proveedores/editar/" + row.Id + "' class='btn btn-warning col-md-4 col-md-offset-1'>Editar</a>" +
                        "<a href='/proveedores/eliminar/" + row.Id + "' class='btn btn-danger col-md-4 col-md-offset-1'>Eliminar</a>";
                }
            }
        ]
    });
});