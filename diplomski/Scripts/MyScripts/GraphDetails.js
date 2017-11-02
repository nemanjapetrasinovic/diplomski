function routerDetails(name,serialnumber) {
    var nodeDepth = document.getElementById("NodeDepth");
    var nodeDetphValue = nodeDepth.value * 2;

    var http = new XMLHttpRequest();
    var url = "/Router/RouterConnections";
    var params = "name=" + name + "&SerialNumber=" + serialnumber +
        "&depth=" + nodeDetphValue;
    http.open("POST", url, true);

    //Send the proper header information along with the request
    http.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

    http.onreadystatechange = function () {//Call a function when the state changes.
        if (http.readyState == 4 && http.status == 200) {
            alert(http.responseText);
        }
    }
    http.send(params);
}

function rGraph(name, serialnumber) {

    var nodeDepth = document.getElementById("NodeDepth");
    var nodeDetphValue = nodeDepth.value * 2;

    $.ajax({
        url: '/Router/RouterConnections',
        data: { name: name, SerialNumber: serialnumber, depth: nodeDetphValue }
    }).done(function () {
        alert('Added');
    });
}