$.get("http://localhost:57916/api/producto").done(function (data) {
    $('#productos').DataTable({
        data: data,
        columns: [
            { data: 'Codigo' },
            { data: 'Nombre' },
            { data: 'Descripcion' },
            { data: 'PrecioVenta' },
            { data: 'StockMinimo' },
            { data: 'StockMaximo' },
            {
                "render": function (data, type, row) {
                    return "<a href='/productos/editar/" + row.Id + "' class='btn btn-warning col-md-4 col-md-offset-1'>Editar</a>" +
                        "<a href='/productos/eliminar/" + row.Id + "' class='btn btn-danger col-md-4 col-md-offset-1'>Eliminar</a>";
                }
            }
        ]
    });
});