

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * 
 * Coded by fiyistack.com
 * Copyright © 2023
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
*/

//Stack: 10

//Last modification on: 02/03/2023 8:51:23

//Create a formdata object
var formData = new FormData();

//Used for Quill Editor
let fiyistackexampletexteditortoolbaroptions = [
    ["bold", "italic", "underline", "strike"],        // toggled buttons
    ["link", "blockquote", "code-block"],

    [{ "header": 1 }, { "header": 2 }],               // custom button values
    [{ "list": "ordered" }, { "list": "bullet" }],
    [{ "script": "sub" }, { "script": "super" }],      // superscript/subscript
    [{ "indent": "-1" }, { "indent": "+1" }],          // outdent/indent
    [{ "direction": "rtl" }],                         // text direction
    ["image", "video"],
    ["clean"]                                         // remove formatting button
];
let fiyistackexampletexteditorquill = new Quill("#fiyistack-example-texteditor-input", {
    modules: {
        toolbar: fiyistackexampletexteditortoolbaroptions
    },
    theme: "snow"
});


//Used for file input
let fiyistackexamplefileuploadinput;
let fiyistackexamplefileuploadboolfileadded;
$("#fiyistack-example-fileupload-input").on("change", function (e) {
    fiyistackexamplefileuploadinput = $(this).get(0).files;
    fiyistackexamplefileuploadboolfileadded = true;
    formData.append("fiyistack-example-fileupload-input", fiyistackexamplefileuploadinput[0], fiyistackexamplefileuploadinput[0].name);
});



//LOAD EVENT
$(document).ready(function () {
    fiyistackexampletexteditorquill.root.innerHTML = $("#fiyistack-example-texteditor-hidden-value").val();
    
    
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName("needs-validation");
    // Loop over them and prevent submission
    Array.prototype.filter.call(forms, function (form) {
        form.addEventListener("submit", function (event) {

            event.preventDefault();
            event.stopPropagation();

            if (form.checkValidity() === true) {
                
                //ExampleId
                formData.append("fiyistack-example-exampleid-input", $("#fiyistack-example-exampleid-input").val());

                formData.append("fiyistack-example-boolean-input", $("#fiyistack-example-boolean-input").is(":checked"));
                formData.append("fiyistack-example-decimal-input", $("#fiyistack-example-decimal-input").val());
                formData.append("fiyistack-example-dropdown-input", $("#fiyistack-example-dropdown-input").val());
                formData.append("fiyistack-example-options-input", $(".fiyistack-example-options-a.active").next().val());
                formData.append("fiyistack-example-integer-input", $("#fiyistack-example-integer-input").val());
                formData.append("fiyistack-example-textbasic-input", $("#fiyistack-example-textbasic-input").val());
                formData.append("fiyistack-example-email-input", $("#fiyistack-example-email-input").val());
                if (!fiyistackexamplefileuploadboolfileadded) {
                    formData.append("fiyistack-example-fileupload-input", $("#fiyistack-example-fileupload-readonly").val());
                }
                formData.append("fiyistack-example-hexcolour-input", $("#fiyistack-example-hexcolour-input").val());
                formData.append("fiyistack-example-password-input", $("#fiyistack-example-password-input").val());
                formData.append("fiyistack-example-phonenumber-input", $("#fiyistack-example-phonenumber-input").val());
                formData.append("fiyistack-example-tag-input", $("#fiyistack-example-tag-input").val());
                formData.append("fiyistack-example-textarea-input", $("#fiyistack-example-textarea-input").val());
                formData.append("fiyistack-example-texteditor-input", fiyistackexampletexteditorquill.root.innerHTML);
                formData.append("fiyistack-example-url-input", $("#fiyistack-example-url-input").val());
                formData.append("fiyistack-example-time-input", $("#fiyistack-example-time-input").val());
                formData.append("fiyistack-example-datetime-input", $("#fiyistack-example-datetime-input").val());
                

                //Setup request
                var xmlHttpRequest = new XMLHttpRequest();
                //Set event listeners
                xmlHttpRequest.upload.addEventListener("loadstart", function (e) {
                    //SAVING
                    $.notify({ message: "Saving data. Please, wait" }, { type: "info", placement: { from: "bottom", align: "center" } });
                });
                xmlHttpRequest.onload = function () {
                    if (xmlHttpRequest.status >= 400) {
                        //ERROR
                        console.log(xmlHttpRequest);
                        $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while saving the data" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                    }
                    else {
                        //SUCCESS
                        window.location.replace("/FiyiStack/ExampleQueryPage");
                    }
                };
                //Open connection
                xmlHttpRequest.open("POST", "/api/FiyiStack/Example/1/InsertOrUpdateAsync", true);
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