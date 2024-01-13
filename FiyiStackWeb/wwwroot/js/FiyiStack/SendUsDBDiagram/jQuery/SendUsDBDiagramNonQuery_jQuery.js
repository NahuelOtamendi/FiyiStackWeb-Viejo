

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

//Last modification on: 23/07/2023 22:31:09

//Create a formdata object
var formData = new FormData();

//Used for Quill Editor
let fiyistacksendusdbdiagramdescriptiontoolbaroptions = [
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
let fiyistacksendusdbdiagramdescriptionquill = new Quill("#fiyistack-sendusdbdiagram-description-input", {
    modules: {
        toolbar: fiyistacksendusdbdiagramdescriptiontoolbaroptions
    },
    theme: "snow"
});


//Used for file input
let fiyistacksendusdbdiagramfileuploadedinput;
let fiyistacksendusdbdiagramfileuploadedboolfileadded;
$("#fiyistack-sendusdbdiagram-fileuploaded-input").on("change", function (e) {
    fiyistacksendusdbdiagramfileuploadedinput = $(this).get(0).files;
    fiyistacksendusdbdiagramfileuploadedboolfileadded = true;
    formData.append("fiyistack-sendusdbdiagram-fileuploaded-input", fiyistacksendusdbdiagramfileuploadedinput[0], fiyistacksendusdbdiagramfileuploadedinput[0].name);
});



//LOAD EVENT
$(document).ready(function () {
    fiyistacksendusdbdiagramdescriptionquill.root.innerHTML = $("#fiyistack-sendusdbdiagram-description-hidden-value").val();
    
    
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName("needs-validation");
    // Loop over them and prevent submission
    Array.prototype.filter.call(forms, function (form) {
        form.addEventListener("submit", function (event) {

            event.preventDefault();
            event.stopPropagation();

            if (form.checkValidity() === true) {
                
                //SendUsDBDiagramId
                formData.append("fiyistack-sendusdbdiagram-sendusdbdiagramid-input", 0);

                formData.append("fiyistack-sendusdbdiagram-title-input", $("#fiyistack-sendusdbdiagram-title-input").val());
                formData.append("fiyistack-sendusdbdiagram-description-input", fiyistacksendusdbdiagramdescriptionquill.root.innerHTML);
                if (!fiyistacksendusdbdiagramfileuploadedboolfileadded) {
                    formData.append("fiyistack-sendusdbdiagram-fileuploaded-input", $("#fiyistack-sendusdbdiagram-fileuploaded-readonly").val());
                }
                

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
                        window.location.replace("/Index");
                    }
                };
                //Open connection
                xmlHttpRequest.open("POST", "/api/FiyiStack/SendUsDBDiagram/1/InsertOrUpdateAsync", true);
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