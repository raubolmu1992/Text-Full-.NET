


var editar = false;
window.onload = function () {
    var id = $.urlParam('id');
    console.log(id);
    if (id != null) {
        editar = true;
        $("#txtIdProducto").val(id);
        PintarProductos(id);
        //alert(id);
    }
};

$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    if (results == null) {
        return null;
    }
    return decodeURI(results[1]) || 0;
}

function IrFormularioInicio() {
    window.location = "Inicio.html";
}

function PintarProductos(IdProducto) {

    $.get("http://localhost:58683/api/Producto/" + IdProducto)
        .done(function (response) {
            console.log(response);
            $("#txtTipoProducto").val(response.TipoProducto),
                $("#txtCodigoUnico").val(response.CodigoUnico),
                $("#txtNombreProducto").val(response.NombreProducto),
                $("#txtActivo").val(response.Activo),
                $("#txtCantidad").val(response.Cantidad),
                $("#txtValor").val(response.Valor)
        });
}


function GuardarEstudiantes() {
    if (editar) {

        var data = {
            IdProducto: $("#txtIdProducto").val(),
            TipoProducto: $("#txtTipoProducto").val(),
            CodigoUnico: $("#txtCodigoUnico").val(),
            NombreProducto: $("#txtNombreProducto").val(),
            Activo: $("#txtActivo").val(),
            Cantidad: $("#txtCantidad").val(),
            Valor: $("#txtValor").val()
        }

        $.ajax({
            method: "PUT",
            url: "http://localhost:58683/Productos",
            contentType: 'application/json',
            data: JSON.stringify(data), // access in body
        })
            .done(function (response) {
                console.log(response);
                if (response) {
                    alert("Se guardaron los cambios");
                    window.location = "Inicio.html";
                } else {
                    alert("Error al Modificar")
                }
            });

    } else {

        var data = {
            TipoProducto: $("#txtTipoProducto").val(),
            CodigoUnico: $("#txtCodigoUnico").val(),
            NombreProducto: $("#txtNombreProducto").val(),
            Activo: $("#txtActivo").val(),
            Cantidad: $("#txtCantidad").val(),
            Valor: $("#txtValor").val()
        }

        $.post("http://localhost:58683/Productos/Post", data)
            .done(function (response) {
                console.log(response);
                if (response) {
                    alert("Producto Creado");
                    window.location = "http://localhost:58683/Productos/Inicio";
                } else {
                    alert("Error al crear");
                }
            });
    }



    function ActualizarEstudiantes() {
        //if (editar) {

        //    var data = {
        //        IdProducto: $("#txtIdProducto").val(),
        //        TipoProducto: $("#txtTipoProducto").val(),
        //        CodigoUnico: $("#txtCodigoUnico").val(),
        //        NombreProducto: $("#txtNombreProducto").val(),
        //        Activo: $("#txtActivo").val(),
        //        Cantidad: $("#txtCantidad").val(),
        //        Valor: $("#txtValor").val()
        //    }

        //    $.ajax({
        //        method: "PUT",
        //        url: "http://localhost:58683/Productos",
        //        contentType: 'application/json',
        //        data: JSON.stringify(data), // access in body
        //    })
        //        .done(function (response) {
        //            console.log(response);
        //            if (response) {
        //                alert("Se guardaron los cambios");
        //                window.location = "Inicio.html";
        //            } else {
        //                alert("Error al Modificar")
        //            }
        //        });

        //} else {

        var data = {
            TipoProducto: $("#txtTipoProducto").val(),
            CodigoUnico: $("#txtCodigoUnico").val(),
            NombreProducto: $("#txtNombreProducto").val(),
            Activo: $("#txtActivo").val(),
            Cantidad: $("#txtCantidad").val(),
            Valor: $("#txtValor").val()
        }

        $.post("http://localhost:58683/Productos/Post", data)
            .done(function (response) {
                console.log(response);
                if (response) {
                    alert("Producto Creado");
                    window.location = "http://localhost:58683/Productos/Inicio";
                } else {
                    alert("Error al crear");
                }
            });
        /*  }*/



    }

}

