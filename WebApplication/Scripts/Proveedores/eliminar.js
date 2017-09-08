var ModuloEliminarProveedor = function () {
    var url = window.location.href;
    var idProveedor = url.substring(url.lastIndexOf('/') + 1);

    var cargarFormulario = function () {
        $.get("http://localhost:57916/api/proveedor/" + idProveedor)
            .done(function (proveedor) {
                $("#nombreProveedor").html(proveedor.Nombre);
            }).fail(function (error) {
                alert("Proveedor no encontrado")
                window.location.replace("/proveedores");
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
                url: "http://localhost:57916/api/proveedor/" + idProveedor,
                method: 'DELETE'
            }).done(function () {
                window.location.replace("/proveedores");
            }).fail(function (error) {
                mostrarErrores(error);
            });
        });
    }

    cargarFormulario();
    onclickEliminarForm();
}
new ModuloEliminarProveedor();