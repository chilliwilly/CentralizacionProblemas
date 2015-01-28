function validaInputAcc(acc) {
    var valida;
    $.ajax({
        type: "POST",
        url: "/asmx_files/problema_llenado_cbo.asmx/validaAccion",
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "nomacc": acc }),
        success: function (data, status) {
            if (data.d) {
                valida = true;
            }
            else {
                valida = false;
            }
        },
        error: function (data) {
            alert("Error al Consultar Validacion Accion");
        }
    });
    return valida;
}

function guardarAccion(acc) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/problema_llenado_cbo.asmx/setAccion",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "nombreacc": acc }),
        success: function (data, status) {
            alert("Guardado");
        },
        error: function (data) {
            alert("Error al Guardar");
        }
    });
}

function borrarAccion(acc) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/problema_llenado_cbo.asmx/delAccion",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "nom": acc }),
        success: function (data, status) {
            $("<div id='dialog-msg-del' title='Mensaje Accion'><p>La accion ha sido borrada</p></div>").dialog({
                modal: true,
                "OK": function () {
                    $(this).dialog('close');
                }
            });
        },
        error: function (data) {
            alert("Error al enviar datos");
        }
    });
}

function actualizarAccion(oldacc, acc) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/problema_llenado_cbo.asmx/updAccion",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "nomv": oldacc, "nom": acc }),
        success: function (data, status) {
            $("<div id='dialog-msg-upd' title='Mensaje Accion'><p>La accion ha sido Actualizada</p></div>").dialog({
                modal: true,
                "Cerrar": function () {
                    $(this).dialog('close');
                }
            });
        },
        error: function (data) {
            alert("Error al enviar datos");
        }
    });
}