$(function () {   // ESTA FUNCION SE EJECUTA APENAS SE INICIA EL SITIO
    var tokenValue = $("#token").data("token");
    if (tokenValue != "") {
        setCookie("Token", tokenValue);
    }
})

