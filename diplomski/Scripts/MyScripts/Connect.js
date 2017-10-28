function myFunction() {
    var dropdown = document.getElementById("Type");
    var value = dropdown.options[dropdown.selectedIndex].value;
    switch (value) {
        case "":
            var dropdownDesktop = document.getElementById("Desktop");
            var dropdownLaptop = document.getElementById("Laptop");
            var dropdownServer = document.getElementById("Server");
            var dropdownRouter = document.getElementById("Router");
            var dropdownSwitch = document.getElementById("Switch");
            dropdownDesktop.style.display = "none";
            dropdownLaptop.style.display = "none";
            dropdownServer.style.display = "none";
            dropdownRouter.style.display = "none";
            dropdownSwitch.style.display = "none";
            break;
        case "Desktop":
            var dropdownDesktop = document.getElementById("Desktop");
            var dropdownLaptop = document.getElementById("Laptop");
            var dropdownServer = document.getElementById("Server");
            var dropdownRouter = document.getElementById("Router");
            var dropdownSwitch = document.getElementById("Switch");
            dropdownDesktop.style.display = "block";
            dropdownLaptop.style.display = "none";
            dropdownServer.style.display = "none";
            dropdownRouter.style.display = "none";
            dropdownSwitch.style.display = "none";
            break;
        case "Laptop":
            var dropdownDesktop = document.getElementById("Desktop");
            var dropdownLaptop = document.getElementById("Laptop");
            var dropdownServer = document.getElementById("Server");
            var dropdownRouter = document.getElementById("Router");
            var dropdownSwitch = document.getElementById("Switch");
            dropdownDesktop.style.display = "none";
            dropdownLaptop.style.display = "block";
            dropdownServer.style.display = "none";
            dropdownRouter.style.display = "none";
            dropdownSwitch.style.display = "none";
            break;
        case "Server":
            var dropdownDesktop = document.getElementById("Desktop");
            var dropdownLaptop = document.getElementById("Laptop");
            var dropdownServer = document.getElementById("Server");
            var dropdownRouter = document.getElementById("Router");
            var dropdownSwitch = document.getElementById("Switch");
            dropdownDesktop.style.display = "none";
            dropdownLaptop.style.display = "none";
            dropdownServer.style.display = "block";
            dropdownRouter.style.display = "none";
            dropdownSwitch.style.display = "none";
            break;
        case "Router":
            var dropdownDesktop = document.getElementById("Desktop");
            var dropdownLaptop = document.getElementById("Laptop");
            var dropdownServer = document.getElementById("Server");
            var dropdownRouter = document.getElementById("Router");
            var dropdownSwitch = document.getElementById("Switch");
            dropdownDesktop.style.display = "none";
            dropdownLaptop.style.display = "none";
            dropdownServer.style.display = "none";
            dropdownRouter.style.display = "block";
            dropdownSwitch.style.display = "none";
            break;
        case "Switch":
            var dropdownDesktop = document.getElementById("Desktop");
            var dropdownLaptop = document.getElementById("Laptop");
            var dropdownServer = document.getElementById("Server");
            var dropdownRouter = document.getElementById("Router");
            var dropdownSwitch = document.getElementById("Switch");
            dropdownDesktop.style.display = "none";
            dropdownLaptop.style.display = "none";
            dropdownServer.style.display = "none";
            dropdownRouter.style.display = "none";
            dropdownSwitch.style.display = "block";
            break;
    }
    console.log("myFuncion"+value);
}

function myFunction1() {
    var dropdown = document.getElementById("Type1");
    var value = dropdown.options[dropdown.selectedIndex].value;
    switch (value) {
        case "":
            var dropdownDesktop = document.getElementById("Desktop1");
            var dropdownLaptop = document.getElementById("Laptop1");
            var dropdownServer = document.getElementById("Server1");
            var dropdownRouter = document.getElementById("Router1");
            var dropdownSwitch = document.getElementById("Switch1");
            dropdownDesktop.style.display = "none";
            dropdownLaptop.style.display = "none";
            dropdownServer.style.display = "none";
            dropdownRouter.style.display = "none";
            dropdownSwitch.style.display = "none";
            break;
        case "Desktop":
            var dropdownDesktop = document.getElementById("Desktop1");
            var dropdownLaptop = document.getElementById("Laptop1");
            var dropdownServer = document.getElementById("Server1");
            var dropdownRouter = document.getElementById("Router1");
            var dropdownSwitch = document.getElementById("Switch1");
            dropdownDesktop.style.display = "block";
            dropdownLaptop.style.display = "none";
            dropdownServer.style.display = "none";
            dropdownRouter.style.display = "none";
            dropdownSwitch.style.display = "none";
            break;
        case "Laptop":
            var dropdownDesktop = document.getElementById("Desktop1");
            var dropdownLaptop = document.getElementById("Laptop1");
            var dropdownServer = document.getElementById("Server1");
            var dropdownRouter = document.getElementById("Router1");
            var dropdownSwitch = document.getElementById("Switch1");
            dropdownDesktop.style.display = "none";
            dropdownLaptop.style.display = "block";
            dropdownServer.style.display = "none";
            dropdownRouter.style.display = "none";
            dropdownSwitch.style.display = "none";
            break;
        case "Server":
            var dropdownDesktop = document.getElementById("Desktop1");
            var dropdownLaptop = document.getElementById("Laptop1");
            var dropdownServer = document.getElementById("Server1");
            var dropdownRouter = document.getElementById("Router1");
            var dropdownSwitch = document.getElementById("Switch1");
            dropdownDesktop.style.display = "none";
            dropdownLaptop.style.display = "none";
            dropdownServer.style.display = "block";
            dropdownRouter.style.display = "none";
            dropdownSwitch.style.display = "none";
            break;
        case "Router":
            var dropdownDesktop = document.getElementById("Desktop1");
            var dropdownLaptop = document.getElementById("Laptop1");
            var dropdownServer = document.getElementById("Server1");
            var dropdownRouter = document.getElementById("Router1");
            var dropdownSwitch = document.getElementById("Switch1");
            dropdownDesktop.style.display = "none";
            dropdownLaptop.style.display = "none";
            dropdownServer.style.display = "none";
            dropdownRouter.style.display = "block";
            dropdownSwitch.style.display = "none";
            break;
        case "Switch":
            var dropdownDesktop = document.getElementById("Desktop1");
            var dropdownLaptop = document.getElementById("Laptop1");
            var dropdownServer = document.getElementById("Server1");
            var dropdownRouter = document.getElementById("Router1");
            var dropdownSwitch = document.getElementById("Switch1");
            dropdownDesktop.style.display = "none";
            dropdownLaptop.style.display = "none";
            dropdownServer.style.display = "none";
            dropdownRouter.style.display = "none";
            dropdownSwitch.style.display = "block";
            break;
    }
    console.log("myFuncion1" + value);
}

function connectionSelect() {
    var connectionDropdown = document.getElementById("ConnectionType");
    var value = connectionDropdown.options[connectionDropdown.selectedIndex].value;

    switch (value) {

        case "":
            var dropdownCableType = document.getElementById("CableType");
            dropdownCableType.style.display = "none";

            var dropdownCableType = document.getElementById("LanCategory");
            var editorLanManufacturer = document.getElementById("LanManufacturer");
            dropdownCableType.style.display = "none";
            editorLanManufacturer.style.display = "none";

            var editorOpticManufacturer = document.getElementById("OpticManufacturer");
            var editorOpticMaterial = document.getElementById("OpticMaterial");
            var opticMode = document.getElementById("OpticMode");
            editorOpticManufacturer.style.display = "none";
            editorOpticMaterial.style.display = "none";
            opticMode.style.display = "none";
            break;

        case "Cable":
            var dropdownCableType = document.getElementById("CableType");
            dropdownCableType.style.display = "block";
            break;

        case "WiFi":
            var dropdownCableType = document.getElementById("CableType");
            dropdownCableType.style.display = "none";

            var dropdownCableType = document.getElementById("LanCategory");
            var editorLanManufacturer = document.getElementById("LanManufacturer");
            dropdownCableType.style.display = "none";
            editorLanManufacturer.style.display = "none";

            var editorOpticManufacturer = document.getElementById("OpticManufacturer");
            var editorOpticMaterial = document.getElementById("OpticMaterial");
            var opticMode = document.getElementById("OpticMode");
            editorOpticManufacturer.style.display = "none";
            editorOpticMaterial.style.display = "none";
            opticMode.style.display = "none";
            break;
    }
}

function showCableProperties() {
    var lanCategoryDropdown = document.getElementById("CableType");
    value = lanCategoryDropdown.options[lanCategoryDropdown.selectedIndex].value;

    switch (value) {
        case "":
            var dropdownCableType = document.getElementById("LanCategory");
            var editorLanManufacturer = document.getElementById("LanManufacturer");
            dropdownCableType.style.display = "none";
            editorLanManufacturer.style.display = "none";

            var editorOpticManufacturer = document.getElementById("OpticManufacturer");
            var editorOpticMaterial = document.getElementById("OpticMaterial");
            var opticMode = document.getElementById("OpticMode");
            editorOpticManufacturer.style.display = "none";
            editorOpticMaterial.style.display = "none";
            opticMode.style.display = "none";
            break;
        case "Lan":
            var dropdownCableType = document.getElementById("LanCategory");
            var editorLanManufacturer = document.getElementById("LanManufacturer");
            dropdownCableType.style.display = "block";
            editorLanManufacturer.style.display = "block";

            var editorOpticManufacturer = document.getElementById("OpticManufacturer");
            var editorOpticMaterial = document.getElementById("OpticMaterial");
            var opticMode = document.getElementById("OpticMode");
            editorOpticManufacturer.style.display = "none";
            editorOpticMaterial.style.display = "none";
            opticMode.style.display = "none";
            break;
        case "Optic":
            var dropdownCableType = document.getElementById("LanCategory");
            var editorLanManufacturer = document.getElementById("LanManufacturer");
            dropdownCableType.style.display = "none";
            editorLanManufacturer.style.display = "none";

            var editorOpticManufacturer = document.getElementById("OpticManufacturer");
            var editorOpticMaterial = document.getElementById("OpticMaterial");
            var opticMode = document.getElementById("OpticMode");
            editorOpticManufacturer.style.display = "block";
            editorOpticMaterial.style.display = "block";
            opticMode.style.display = "block";
            break;
    }
}

function makeConnection() {
    var nodeType = document.getElementById("Type");
    var nodeTypeValue = nodeType.options[nodeType.selectedIndex].value;

    var firstNode;
    var firstNodeType;
    var secondNode;
    var secondNodeType;

    switch (nodeTypeValue) {
        case "Desktop":
            firstNode = document.getElementById("Desktop").options[document.getElementById("Desktop").selectedIndex].value;
            firstNodeType = "Desktop";
            console.log("First node " + firstNode);
            break;
        case "Laptop":
            firstNode = document.getElementById("Laptop").options[document.getElementById("Laptop").selectedIndex].value;
            firstNodeType = "Laptop";
            console.log("First node " + firstNode);
            break;
        case "Server":
            firstNode = document.getElementById("Server").options[document.getElementById("Server").selectedIndex].value;
            firstNodeType = "Server";
            console.log("First node " + firstNode);
            break;
        case "Router":
            firstNode = document.getElementById("Router").options[document.getElementById("Router").selectedIndex].value;
            firstNodeType = "Router";
            console.log("First node " + firstNode);
            break;
        case "Switch":
            firstNode = document.getElementById("Switch").options[document.getElementById("Switch").selectedIndex].value;
            firstNodeType = "Switch";
            console.log("First node " + firstNode);
            break;
    }

    var nodeType1 = document.getElementById("Type1");
    var nodeTypeValue1 = nodeType1.options[nodeType1.selectedIndex].value;

    switch (nodeTypeValue1) {
        case "Desktop":
            secondNode = document.getElementById("Desktop1").options[document.getElementById("Desktop1").selectedIndex].value;
            secondNodeType = "Desktop";
            console.log("Second node " + secondNode);
            break;
        case "Laptop":
            secondNode = document.getElementById("Laptop1").options[document.getElementById("Laptop1").selectedIndex].value;
            secondNodeType = "Laptop";
            console.log("Second node " + secondNode);
            break;
        case "Server":
            secondNode = document.getElementById("Server1").options[document.getElementById("Server1").selectedIndex].value;
            secondNodeType = "Server";
            console.log("Second node " + secondNode);
            break;
        case "Router":
            secondNode = document.getElementById("Router1").options[document.getElementById("Router1").selectedIndex].value;
            secondNodeType = "Router";
            console.log("Second node " + secondNode);
            break;
        case "Switch":
            secondNode = document.getElementById("Switch1").options[document.getElementById("Switch1").selectedIndex].value;
            secondNodeType = "Switch";
            console.log("Second node " + secondNode);
            break;
    }

    var connectionType = document.getElementById("ConnectionType");
    var connectionTypeValue = connectionType.options[connectionType.selectedIndex].value;
    var lanCategoryValue;
    var lanManufacturerValue;
    var OpticManufacturer;
    var OpticMaterial;
    var OpticMode;

    switch (connectionTypeValue) {
        case "Cable":
            var CableType = document.getElementById("CableType");
            var CableTypeValue = CableType.options[CableType.selectedIndex].value;

            switch (CableTypeValue) {
                case "Lan":
                    lanCategoryValue = document.getElementById("LanCategory").options[document.getElementById("LanCategory").selectedIndex].value;
                    lanManufacturerValue = document.getElementById("LanManufacturer").value;
                    break;

                case "Optic":
                    OpticManufacturer = document.getElementById("OpticManufacturer").value;
                    OpticMaterial = document.getElementById("OpticMaterial").value;
                    OpticMode = document.getElementById("OpticMode").options[document.getElementById("OpticMode").selectedIndex].value;
                    break;
            }
            break;
    }

    var http = new XMLHttpRequest();
    var url = "/Connect/CreateConnection";
    var params = "firstNodeType=" + firstNodeType + "&firstNode=" + firstNode +
        "&secondNodeType=" + secondNodeType + "&secondNode=" + secondNode+
        "&connectionTypeValue=" + connectionTypeValue + "&lanCategoryValue=" + lanCategoryValue +
        "&lanManufacturerValue=" + lanManufacturerValue + "&OpticManufacturer=" + OpticManufacturer+
        "&OpticMaterial=" + OpticMaterial + "&OpticMode=" + OpticMode + "&CableTypeValue=" + CableTypeValue;
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