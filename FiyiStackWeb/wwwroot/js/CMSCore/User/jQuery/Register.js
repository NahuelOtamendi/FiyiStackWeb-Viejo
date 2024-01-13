//Create a formdata object
var formData = new FormData();

//LOAD EVENT
$(document).ready(function () {
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName("needs-validation");
    // Loop over them and prevent submission
    Array.prototype.filter.call(forms, function (form) {
        form.addEventListener("submit", function (event) {

            event.preventDefault();
            event.stopPropagation();

            if (form.checkValidity() === true) {
                if ($("#fantasy-name").val() == "" || $("#email").val() == "" || $("#password").val() == "" || $("#confirm-password").val() == "" || $("#captcha-text").val() == "") {
                    //Complete all fields
                    $.notify({ message: "Please, complete all fields." }, { type: "info", placement: { from: "bottom", align: "center" } });
                    return;
                }

                if ($("#password").val().length < 6 || $("#confirm-password").val().length < 6) {
                    //Minimum required for password = 6 characters
                    $.notify({ message: "Minimum required for password are 6 characters" }, { type: "info", placement: { from: "bottom", align: "center" } });
                    return;
                }

                if ($("#password").val() != $("#confirm-password").val()) {
                    //New password and confirm password must be equal
                    $.notify({ message: "New password and Confirm password must be equal" }, { type: "info", placement: { from: "bottom", align: "center" } });
                    return;
                }

                //Get Google ReCaptcha token
                grecaptcha.ready(function () {
                    grecaptcha.execute('6LdNEI8jAAAAAMgLFOALMJb1FLcpc1DvLMyrwpM4', { action: 'signup' }).then(function (token) {

                        formData.append("fantasy-name", $("#fantasy-name").val());
                        formData.append("email", $("#email").val());
                        formData.append("password", $("#password").val());
                        formData.append("google-recaptcha", token);

                        //Setup request
                        var xmlHttpRequest = new XMLHttpRequest();
                        //Set event listeners
                        xmlHttpRequest.upload.addEventListener("loadstart", function (e) {
                            //Registering. Please, wait...
                            $.notify({ message: "Registering. Please, wait..." }, { type: "info", placement: { from: "bottom", align: "center" } });
                        });
                        xmlHttpRequest.onload = function () {
                            if (xmlHttpRequest.status >= 400) {
                                //ERROR
                                console.log(xmlHttpRequest);
                                $.notify({ message: "There was an error while trying to register" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                            }
                            else {
                                if (xmlHttpRequest.response == "Successfully registered user") {
                                    //SUCCESS
                                    $.notify({ message: "Check your mailbox, I have sent an email to finish the registration" }, { type: "success", placement: { from: "bottom", align: "center" } });
                                }
                                else if (xmlHttpRequest.response == "The email is already registered") {
                                    $.notify({ message: "The email is already registered" }, { type: "warning", placement: { from: "bottom", align: "center" } });
                                }
                                else if (xmlHttpRequest.response == "The captcha is invalid") {
                                    $.notify({ message: "The captcha is invalid" }, { type: "warning", placement: { from: "bottom", align: "center" } });
                                }
                                else {
                                    //ERROR
                                    console.log(xmlHttpRequest);
                                    $.notify({ message: "The registration was wrong, try again" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                                }

                            }
                        };
                        //Open connection
                        xmlHttpRequest.open("POST", "/api/CMSCore/User/1/Register", false);
                        //Send request
                        xmlHttpRequest.send(formData);

                    });
                });
            }
            else {
                $.notify({ message: "Please, complete all fields." }, { type: "warning", placement: { from: "bottom", align: "center" } });
            }


            form.classList.add("was-validated");
        }, false);
    });
});