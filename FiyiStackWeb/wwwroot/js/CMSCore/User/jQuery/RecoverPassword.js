$(document).ready(function () {

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName("needs-validation");
    // Loop over them and prevent submission
    Array.prototype.filter.call(forms, function (form) {
        form.addEventListener("submit", function (event) {

            event.preventDefault();
            event.stopPropagation();

            //Create a formdata object
            var formData = new FormData();

            if (form.checkValidity() === true) {
                if ($("#email").val() == "") {
                    $.notify({ message: "Please, complete email field." }, { type: "info", placement: { from: "bottom", align: "center" } });
                    return;
                }

                formData.append("email", $("#email").val());

                //Setup request
                var xmlHttpRequest = new XMLHttpRequest();
                //Set event listeners
                xmlHttpRequest.upload.addEventListener("loadstart", function (e) {
                    $.notify({ message: "Sending recovery email..." }, { type: "info", placement: { from: "bottom", align: "center" } });
                });
                xmlHttpRequest.onload = function () {
                    if (xmlHttpRequest.status >= 400) {
                        //ERROR
                        console.log(xmlHttpRequest);
                        $.notify({ message: "There was an error while trying to sending recovery email" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                    }
                    else {
                        if (xmlHttpRequest.response == "Recovery email sent") {
                            //SUCCESS
                            $.notify({ message: "Recovery email sent. Please, check your inbox to recover the password" }, { type: "success", placement: { from: "bottom", align: "center" } });
                        }
                        else {
                            //WARNING
                            $.notify({ message: "The email doesn't exist" }, { type: "warning", placement: { from: "bottom", align: "center" } });
                        }
                    }
                };
                //Open connection
                xmlHttpRequest.open("POST", "/api/CMSCore/User/1/RecoverPassword", false);
                //Send request
                xmlHttpRequest.send(formData);
            }
            else {
                $.notify({ message: "Please, complete email field." }, { type: "warning", placement: { from: "bottom", align: "center" } });
            }


            form.classList.add("was-validated");
        }, false);
    });
});