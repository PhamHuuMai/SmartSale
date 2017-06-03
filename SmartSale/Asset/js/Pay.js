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

function pay() {
    http.open("get","/Cart/FormBill", true);
    http.onreadystatechange = function handle() {
        if (http.readyState == 4 && http.status == 200) {
            kq = http.responseText;
            document.getElementById('CusInfo').innerHTML= kq;
        }
    }

    http.send(null);
}