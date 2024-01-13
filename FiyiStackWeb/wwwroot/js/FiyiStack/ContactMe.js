$(document).ready(function () {

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

                formData.append("name", $("#name").val());
                formData.append("surname", $("#surname").val());
                formData.append("email", $("#email").val());
                formData.append("textarea-message", $("#textarea-message").val());

                $("#message").show();

                //Setup request
                var xmlHttpRequest = new XMLHttpRequest();
                //Set event listeners
                xmlHttpRequest.upload.addEventListener("loadstart", function (e) {
                    $.notify({ message: "Sending email. Please, wait..." }, { type: "info", placement: { from: "bottom", align: "center" } });
                });
                xmlHttpRequest.onload = function () {
                    console.log(xmlHttpRequest);
                    if (xmlHttpRequest.status >= 400) {
                        //ERROR
                        $.notify({ message: "There was an error while trying to send message. Try again." }, { type: "danger", placement: { from: "bottom", align: "center" } });
                        console.log(xmlHttpRequest);
                    }
                    else {
                        if (xmlHttpRequest.response == "Message sent successfully") {
                            //SUCCESS
                            $.notify({ message: "Message sent successfully" }, { type: "success", placement: { from: "bottom", align: "center" } });
                            $("#name").val("");
                            $("#surname").val("");
                            $("#email").val("");
                            $("#textarea-message").val("");
                        }
                        else {
                            //ERROR
                            $.notify({ message: "The message could not be sent. Try again." }, { type: "danger", placement: { from: "bottom", align: "center" } });
                            console.log(xmlHttpRequest);
                        }
                    }
                };
                //Open connection
                xmlHttpRequest.open("POST", "/api/FiyiStack/1/ContactMe", true);
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