var ModuloEditarProducto = function () {
    var url = window.location.href;
    var idProducto = url.substring(url.lastIndexOf('/') + 1);

    var cargarFormulario = function(){
        $.get("http://localhost:57916/api/producto/" + idProducto)
            .done(function (producto) {
                $("#formeditar input[name=Id]").val(idProducto);
                $("#formeditar input[name=Codigo]").val(producto.Codigo);
                $("#formeditar input[name=Nombre]").val(producto.Nombre);
                $("#formeditar input[name=PrecioVenta]").val(producto.PrecioVenta);
                $("#formeditar input[name=Descripcion]").val(producto.Descripcion);
                $("#formeditar input[name=StockMinimo]").val(producto.StockMinimo);
                $("#formeditar input[name=StockMaximo]").val(producto.StockMaximo);
            }).fail(function (error) {
                alert("Producto no encontrado")
                window.location.replace("/productos");
            });
    }

    var mostrarErrores = function (error) {
        $("#errors").html(error);
        $("#errors").show();
    }

    var onclickEditarForm = function () {
        $("#formeditar").submit(function (event) {
            event.preventDefault();
            var registro = $("#formeditar").serialize();
            $.ajax({
                url: "http://localhost:57916/api/producto",
                method: 'PUT',
                data: registro
                }).done(function () {
                    window.location.replace("/productos");
                }).fail(function (error) {
                    mostrarErrores(error);
                });
        });
    }

    cargarFormulario();
    onclickEditarForm();
}
new ModuloEditarProducto();