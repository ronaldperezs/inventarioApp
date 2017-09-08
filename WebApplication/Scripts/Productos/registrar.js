var ModuloRegistrarProducto = function () {

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
    onclickRegistrarForm();
}
new ModuloRegistrarProducto();