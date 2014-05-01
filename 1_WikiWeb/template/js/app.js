function ValidateLogin() {
    var userName = $("input[id$='txtUserName']");
    var password = $("input[id$='txtPassword']");
    if (userName.val() != "" && password.val() != "") {
        return true;
    } else {
        if (userName.val() == "") {
            userName.parent().addClass("has-error");
        } else {
            userName.parent().removeClass("has-error");
        }
        if (password.val() == "") {
            password.parent().addClass("has-error");
        } else {
            password.parent().removeClass("has-error");
        }
        $("div[id$='loginResult']").html("<div class='callout callout-danger'><h4>Error</h4><p>Datos requeridos</p></div>");
        return false;
    }
}