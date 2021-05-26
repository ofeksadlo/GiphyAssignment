function isNormalInteger(str) {
    var n = Math.floor(Number(str));
    return n !== Infinity && String(n) === str && n >= 0;
}
var flag = true;
$(document).ready(function () {
    $("#getButton").click(function () {
        if (isNormalInteger($('#limitTextBox').val()) == false) {
            event.preventDefault();
            if (flag) {
                $("#limitLabel").append("</br><span class='alert-danger'>הזן מספר חיובי עד 500</span>");
            }
            flag = false;
        }
    });
});