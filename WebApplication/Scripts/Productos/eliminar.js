var ModuloEliminarProducto = function () {
    var url = window.location.href;
    var idProducto = url.substring(url.lastIndexOf('/') + 1);

    var cargarFormulario = function () {
        $.get("http://localhost:57916/api/producto/" + idProducto)
            .done(function (producto) {
                $("#nombreProducto").html(producto.Nombre);
            }).fail(function (error) {
                alert("Producto no encontrado")
                window.location.replace("/productos");
            });
    }

    var mostrarErrores = function (error) {
        $("#errors").html(error);
        $("#errors").show();
    }

    var onclickEliminarForm = function () {
        $("#formeliminar").submit(function (event) {
            event.preventDefault();
            $.ajax({
                url: "http://localhost:57916/api/producto/" + idProducto,
                method: 'DELETE'
            }).done(function () {
                window.location.replace("/productos");
            }).fail(function (error) {
                mostrarErrores(error);
            });
        });
    }

    cargarFormulario();
    onclickEliminarForm();
}
new ModuloEliminarProducto();