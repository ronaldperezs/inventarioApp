var ModuloListarRemisionesEntrada = function () {
    var renderEstadoRemision = function (IdEstado) {
        switch (IdEstado) {
            case 1:
                return "<span class='label label-primary'>Registrada</span>"
            case 2:
                return "<span class='label label-success'>Confirmada</span>"
            default:
                return "<span class='label label-danger'>Anulada</span>"
        }
    }
    var listarRemisionesEntrada = function () {
        $.get("http://localhost:57916/api/remisionentrada").done(function (data) {
            $('#remisionesEntrada').DataTable({
                data: data,
                columns: [
                    { data: 'Codigo' },
                    { data: 'FechaDocumento' },
                    { data: 'Proveedor' },
                    { data: 'Almacen' },
                    {
                        "render": function (data, type, row) {
                            return renderEstadoRemision(row.IdEstado);
                        }
                    },
                    {
                        "render": function (data, type, row) {
                            return "<a href='/remisionentrada/editar/" + row.Id + "' class='btn btn-warning col-md-4 col-md-offset-1'>Editar</a>" +
                                "<a href='/remisionentrada/eliminar/" + row.Id + "' class='btn btn-danger col-md-4 col-md-offset-1'>Eliminar</a>";
                        }
                    }
                ]
            });
        });
    }
    listarRemisionesEntrada();
}
new ModuloListarRemisionesEntrada();