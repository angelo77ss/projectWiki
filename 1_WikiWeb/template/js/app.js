function ValidateLogin() {
    //    var userName = $("input[id$='txtUserName']");
    //    var password = $("input[id$='txtPassword']");
    //    if (userName.val() != "" && password.val() != "") {
    //        return true;
    //    } else {
    //        if (userName.val() == "") {
    //            userName.parent().addClass("has-error");
    //        } else {
    //            userName.parent().removeClass("has-error");
    //        }
    //        if (password.val() == "") {
    //            password.parent().addClass("has-error");
    //        } else {
    //            password.parent().removeClass("has-error");
    //        }
    //        $("div[id$='loginResult']").html("<div class='callout callout-danger'><h4>Error</h4><p>Datos requeridos</p></div>");
    //        return false;
    //    }
    return false;
}
//############################################ON-CLIENT VALIDATIONS###########################################################
var htmlMsg = "<span class='label label-danger' id='#messageId'>#messageText</span>";
var messageText = "";
function ValidateForm(formId) {
    var result = true;
    try {
        $("#" + formId).find(':input').each(function () {
            //Obtenemos el elemento input
            var inputElement = this;

            //Id que tendra el bloque del error
            var messageId = inputElement.id + 'errMsg';
            //Borramos los mensajes que puedan existir de un intento de submit anterior.
            $("#" + messageId).remove();

            //Validamos el campo, almenos que sea uno relacionado a un boton.
            var isValid = false;
            if (inputElement.type == "button" || inputElement.type == "submit" || inputElement.type == "reset") {
                isValid = true;
            } else {
                isValid = ValidateInputType(inputElement);
            }

            if (!isValid) {
                result = false;
                //Construimos el mensaje
                var localHtmlMsg = htmlMsg.replace('#messageId', messageId);
                localHtmlMsg = localHtmlMsg.replace('#messageText', messageText);
                //Segun el tipo de elemento varia el lugar en el que agregamos el html
                if (inputElement.type == "checkbox") {
                    $("#" + elemento.id).parent().parent().after(localHtmlMsg);
                } else if (inputElement.type == "radio") {
                    $("#" + inputElement.id).parent().parent().parent().after(localHtmlMsg);
                } else {
                    $("#" + inputElement.id).after(localHtmlMsg);
                }
            }
        }
        );
    } catch (ex) {
        result = false;
        alert(ex);
    }
    return result;
}

function ValidateInputType(inputElement) {
    var result = true;
    var isRequired = false;
    var dataType = '';

    var dataElement = $('#' + inputElement.id);

    //Verificamos si el campo esta marcado como requerido
    if (dataElement.data('required')) {
        isRequired = dataElement.data('required');
    }

    //Obtenemos el tipo de entrada
    if (dataElement.data('type')) {
        dataType = dataElement.data('type');
    }
    if (isRequired) {
        //Controla imputs de tipo select (Combo)
        if (inputElement.type == "select-one") {
            if (inputElement.value == 'none') {
                messageText = 'Es necesario que selecciones una opción.';
                result = false;
            }
        }
        //Controla imputs de tipo file y otros
        else if (inputElement.value == null || inputElement.value == undefined || inputElement.value == '') {
            if (inputElement.type == "file") {
                messageText = 'Es necesario que selecciones un archivo.';
            } else {
                messageText = 'Es necesario que ingreses un valor.';
            }
            result = false;
        }
    }
    if (result) {
        //        switch (dataType) {
        //            case 'number':
        //                result = validateNumber(elemento);
        //                break;
        //            case 'decimal':
        //                result = validateDecimal(elemento);
        //                break;
        //            case 'mail':
        //                result = validarMail(elemento);
        //                break;
        //            case 'url':
        //                result = validateUrl(elemento);
        //                break;
        //            case 'alfanumeric':
        //                result = validateAlfanumeric(elemento);
        //                break;
        //            case 'letters':
        //                result = validateLetters(elemento);
        //                break;
        //            case 'date':
        //                result = validateDate(elemento);
        //                break;
        //            case 'equals':
        //                result = validateEquals(elemento);
        //                break;
        //            default:
        //                result = true;
        //                break;
        //        }
    }
    return result;
}