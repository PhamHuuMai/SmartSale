function createObj() {
    td = navigator.appName;
    if (td == "Microsoft Internet Explorer") {
        obj = new ActiveXObject("Microsoft.XMLHTTP");
    } else {
        obj = new XMLHttpRequest();
    }
    return obj;
}
var http = createObj();
function getdatabyget(destElement, url) {
   // document.getElementById(destElement).innerHTML = '<img src="../Asset/img/Boobs-Loading.gif" />';
    http.open("get", url, true);
    http.onreadystatechange = function handle() {
        if (http.readyState == 4 && http.status == 200) {
            kq = http.responseText;
            document.getElementById(destElement).innerHTML = kq;
        }
    }
     
    http.send(null);
    i = '';
}
function cancelForm() {
    document.getElementById('forms').innerHTML = '';
    i = '';
}