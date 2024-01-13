$(document).ready(function () {
});

$("#loginbutton").on("click", function (e) {

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName("needs-validation");
    // Loop over them and prevent submission
    Array.prototype.filter.call(forms, function (form) {
        form.addEventListener("submit", function (event) {
            event.preventDefault();
            event.stopPropagation();

            if (form.checkValidity() === true) {
                //Create a formdata object
                var formData = new FormData();

                formData.append("fantasynameoremail", $("#fantasynameoremail").val());
                formData.append("password", $("#password").val());

                //Setup request
                var xmlHttpRequest = new XMLHttpRequest();
                //Set event listeners
                xmlHttpRequest.onload = function () {
                    if (xmlHttpRequest.status >= 400) {
                        //ERROR
                        console.log(xmlHttpRequest);
                        $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to login" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                    }
                    else {
                        if (xmlHttpRequest.response == "User not found") {
                            $.notify({ icon: "fas fa-exclamation-triangle", message: "User not found" }, { type: "warning", placement: { from: "bottom", align: "center" } });
                        }
                        else {
                            window.location.href = xmlHttpRequest.response;
                        }
                    }
                };
                //Open connection
                xmlHttpRequest.open("POST", "/api/CMSCore/User/1/Login", false);
                //Send request
                xmlHttpRequest.send(formData);
            }
            else {
                $.notify({ message: "Please, complete all fields." }, { type: "warning", placement: { from: "bottom", align: "center" } });
            }
        }, false);
    });
});