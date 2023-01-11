
function ActualizarEstudiantes() {


    var IdProducto = document.getElementById("txtIdProducto").value;
    var TipoProducto = document.getElementById("txtTipoProducto").value;
    var CodigoUnico = document.getElementById("txtCodigoUnico").value;
    var NombreProducto = document.getElementById("txtNombreProducto").value;
    var Activo = document.getElementById("txtActivo").value;
    var Cantidad = document.getElementById("txtCantidad").value;
    var Valor = document.getElementById("txtValor").value;

    var data = new Object();
    var data = {
        IdProducto,
        TipoProducto,
        CodigoUnico,
        NombreProducto,
        Activo,
        Cantidad,
        Valor
    }

    $.ajax({
        method: "PUT",
        url: "http://localhost:58683/Productos/Put",
        contentType: 'application/json',
        data: JSON.stringify(data), // access in body
    })
        .done(function (response) {
            console.log(response);
            if (response) {
                alert("Se guardaron los cambios");
                window.location = "http://localhost:58683/Productos/Inicio";
            } else {
                alert("Error al Modificar")
            }
        });
}








