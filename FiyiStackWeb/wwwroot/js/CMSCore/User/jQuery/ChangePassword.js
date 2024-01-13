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
                if ($("#actual-password").val() == "" || $("#new-password").val() == "" || $("#confirm-password").val() == "") {
                    $.notify({ message: "Please, complete all fields." }, { type: "warning", placement: { from: "bottom", align: "center" } });
                    return;
                }

                if ($("#new-password").val() != $("#confirm-password").val()) {
                    $.notify({ message: "New password and confirm password must be equal" }, { type: "warning", placement: { from: "bottom", align: "center" } });
                    return;
                }

                if ($("#new-password").val().length < 6 || $("#confirm-password").val().length < 6) {
                    $.notify({ message: "New password and Confirme password must be at least 6 characters long" }, { type: "warning", placement: { from: "bottom", align: "center" } });
                    return;
                }

                formData.append("actual-password", $("#actual-password").val());
                formData.append("new-password", $("#new-password").val());

                //Setup request
                var xmlHttpRequest = new XMLHttpRequest();
                //Set event listeners
                xmlHttpRequest.upload.addEventListener("loadstart", function (e) {
                    $.notify({ message: "Changing password..." }, { type: "info", placement: { from: "bottom", align: "center" } });
                });
                xmlHttpRequest.onload = function () {
                    if (xmlHttpRequest.status >= 400) {
                        //ERROR
                        $.notify({ message: "There was an error while trying to change password" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                        console.log(xmlHttpRequest);
                    }
                    else {
                        if (xmlHttpRequest.response == "Password changed") {
                            //SUCCESS
                            $.notify({ message: "Password changed" }, { type: "success", placement: { from: "bottom", align: "center" } });
                        }
                        else {
                            //ERROR
                            $.notify({ message: "The actual password is wrong" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                        }

                    }
                };
                //Open connection
                xmlHttpRequest.open("POST", "/api/CMSCore/User/1/ChangePassword", false);
                //Send request
                xmlHttpRequest.send(formData);
            }
            else {
                $.notify({ message: "Please, complete all fields." }, { type: "warning", placement: { from: "bottom", align: "center" } });
            }


            form.classList.add("was-validated");
        }, false);
    });
});