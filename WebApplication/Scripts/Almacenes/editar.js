var ModuloEditarAlmacen = function () {
    var url = window.location.href;
    var idAlmacen = url.substring(url.lastIndexOf('/') + 1);

    var cargarFormulario = function(){
        $.get("http://localhost:57916/api/almacen/" + idAlmacen)
            .done(function (almacen) {
                $("#formeditar input[name=Id]").val(idAlmacen);
                $("#formeditar input[name=Codigo]").val(almacen.Codigo);
                $("#formeditar input[name=Nombre]").val(almacen.Nombre);
            }).fail(function (error) {
                alert("Almacen no encontrado")
                window.location.replace("/almacen");
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
                url: "http://localhost:57916/api/almacen",
                method: 'PUT',
                data: registro
                }).done(function () {
                    window.location.replace("/almacen");
                }).fail(function (error) {
                    mostrarErrores(error);
                });
        });
    }

    cargarFormulario();
    onclickEditarForm();
}
new ModuloEditarAlmacen();