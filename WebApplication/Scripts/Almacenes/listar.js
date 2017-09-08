$.get("http://localhost:57916/api/almacen").done(function (data) {
    $('#almacenes').DataTable({
        data: data,
        columns: [
            { data: 'Codigo' },
            { data: 'Nombre' },
            {
                "render": function (data, type, row) {
                    return "<a href='/almacen/editar/" + row.Id + "' class='btn btn-warning col-md-4 col-md-offset-1'>Editar</a>" +
                        "<a href='/almacen/eliminar/" + row.Id + "' class='btn btn-danger col-md-4 col-md-offset-1'>Eliminar</a>";
                }
            }
        ]
    });
});