var ModuloRegistrarRemisionEntrada = function () {
    var tablaDetalle;

    var cargarProveedores = function () {
        $.get("http://localhost:57916/api/proveedor").done(function (proveedores) {
            $.each(proveedores,function(index,proveedor){
                $("#formregistrar select[name=Proveedor]").append("<option value='" + proveedor.Id + "'>" + proveedor.Nombre+ "</option>");
            });
        }).fail(function (error) {
            alert(error);
        });
    }

    var cargarAlmacenes = function () {
        $.get("http://localhost:57916/api/almacen").done(function (almacenes) {
            $.each(almacenes, function (index, almacen) {
                $("#formregistrar select[name=Almacen]").append("<option value='" + almacen.Id + "'>" + almacen.Nombre + "</option>");
            });
        }).fail(function (error) {
            alert(error);
        });
    }

    var buscarProductos = function () {
        $("#busquedaProducto").on("keyup", function (e) {
            var valor = $(this).val();
            if (!valor) {
                $("#productosEncontrados").find("li").empty();
            } else {
                $.get("http://localhost:57916/api/producto", { busqueda: valor }).done(function (productos) {
                    $("#productosEncontrados").find("li").empty();
                    $.each(productos, function (index, producto) {
                        $("#productosEncontrados").html("<li class='itemBusquedaProducto'><a>(" + producto.Codigo + ") " + producto.Nombre + "</a></li>");
                    });
                });
            }
        })
    }

    var inicializarTablaDetalle = function () {
        tablaDetalle = $('#detalleRemisionEntrada').DataTable({
            data: [],
            columns: [
                { data: 'Producto' },
                {
                    "render": function (data, type, row) {
                        return "<input name='RemisionEntradaDetalle.IdProducto' type='hidden' value='" + row.IdProducto + "/>" +
                            "<input name='RemisionEntradaDetalle.Cantidad' type='number' value='" + row.Cantidad + "/>";
                    }
                },
                {
                    "render": function (data, type, row) {
                        return "<a class='btn btn-primary'>+</a>" + "<a class='btn btn-primary'>-</a>" + "<a class='btn btn-danger'>X</a>";
                    }
                }
            ]
        });
    }

    var mostrarErrores = function (error) {
        $("#errors").html(error);
        $("#errors").show();
    }

    var onclickRegistrarForm = function () {
        $("#formregistrar").submit(function (event) {
            event.preventDefault();
            var registro = $("#formregistrar").serialize();
            $.post("http://localhost:57916/api/producto", registro)
                .done(function () {
                    window.location.replace("/productos");
                }).fail(function (error) {
                    mostrarErrores(error);
                });
        });
    }

    cargarProveedores();
    cargarAlmacenes();
    buscarProductos();
    inicializarTablaDetalle();
    onclickRegistrarForm();
}
new ModuloRegistrarRemisionEntrada();