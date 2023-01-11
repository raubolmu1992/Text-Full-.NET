
function mostrar() {
   
        function mostrar(num) {
        var id = $("#num").val();
        alert(id);

        $(".table tbody").html("");

        $.get("http://localhost:58683/Productos/Get/" + id)
        .done(function (response) {
            console.log(response);
        $.each(response, function (id, fila) {
            $("<tr>").append(
                $("<td>").text(fila.IdProducto),
                $("<td>").text(fila.TipoProducto),
                $("<td>").text(fila.CodigoUnico),
                $("<td>").text(fila.NombreProducto),
                $("<td>").text(fila.Activo),
                $("<td>").text(fila.Cantidad),
                $("<td>").text(fila.Valor),
                $("<td>").text(fila.Total),


                $("<td>").append(

                    $("<button>").data("id", fila.IdProducto).addClass("btn btn-success btn-sm mr-1 editar").text("Editar").attr({ "type": "button" }),
                    $("<button>").data("id", fila.IdProducto).addClass("btn btn-danger btn-sm eliminar").text("Eliminar").attr({ "type": "button" })
                ), $("</td>"), $("</tr>"),

            ).appendTo(".table");
                });
            });

    }



}








