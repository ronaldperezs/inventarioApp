var ModuloEditarProveedor = function () {
    var url = window.location.href;
    var idProveedor = url.substring(url.lastIndexOf('/') + 1);

    var cargarFormulario = function(){
        $.get("http://localhost:57916/api/proveedor/"+idProveedor)
            .done(function(proveedor){
                $("#formeditar input[name=Id]").val(idProveedor);
                $("#formeditar input[name=Codigo]").val(proveedor.Codigo);
                $("#formeditar input[name=Nombre]").val(proveedor.Nombre);
                $("#formeditar input[name=Direccion]").val(proveedor.Direccion);
                $("#formeditar input[name=Telefono]").val(proveedor.Telefono);
            }).fail(function (error) {
                alert("Proveedor no encontrado")
                window.location.replace("/proveedores");
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
                url: "http://localhost:57916/api/proveedor",
                method: 'PUT',
                data: registro
                }).done(function () {
                    window.location.replace("/proveedores");
                }).fail(function (error) {
                    mostrarErrores(error);
                });
        });
    }

    cargarFormulario();
    onclickEditarForm();
}
new ModuloEditarProveedor();