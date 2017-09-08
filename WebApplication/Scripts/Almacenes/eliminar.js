var ModuloEliminarAlmacen = function () {
    var url = window.location.href;
    var idAlmacen = url.substring(url.lastIndexOf('/') + 1);

    var cargarFormulario = function () {
        $.get("http://localhost:57916/api/almacen/" + idAlmacen)
            .done(function (almacen) {
                $("#nombreAlmacen").html(almacen.Nombre);
            }).fail(function (error) {
                alert("Almacen no encontrado")
                window.location.replace("/almacen");
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
                url: "http://localhost:57916/api/almacen/" + idAlmacen,
                method: 'DELETE'
            }).done(function () {
                window.location.replace("/almacen");
            }).fail(function (error) {
                mostrarErrores(error);
            });
        });
    }

    cargarFormulario();
    onclickEliminarForm();
}
new ModuloEliminarAlmacen();