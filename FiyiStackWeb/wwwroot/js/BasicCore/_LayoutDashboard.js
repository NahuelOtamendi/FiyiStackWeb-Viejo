//Create a formdata object
var formData = new FormData();

$("#logout-button").on("click", function (e) {
    //Setup request
    var xmlHttpRequest = new XMLHttpRequest();
    //Set event listeners
    xmlHttpRequest.onload = function () {
        if (xmlHttpRequest.status >= 400) {
            console.log("Error:" + xmlHttpRequest.response);
        }
        else {
            window.location.href = xmlHttpRequest.response;
        }
    };
    //Open connection
    xmlHttpRequest.open("POST", "/api/CMSCore/User/1/Logout", false);
    //Send request
    xmlHttpRequest.send(formData);
});