import * as $ from "jquery";
import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import 'bootstrap-notify';

let RoleId = "0";

//LOAD EVENT
if ($("#title-page").html().includes("Permissions")) {

    //Activate when the button is pushed
    $(".role-a").on("click", function (e) {

        RoleId = $(this).next().val()?.toString() ?? "";

        $("#checkboxes-permissions").html(``);


        Rx.from(ajax.get("/api/CMSCore/RoleMenu/1/SelectAllByRoleIdToRoleMenuForChechboxes/" + RoleId)).subscribe({
                next: newrow => {

                newrow.response.forEach(function (item) {

                    $("#checkboxes-permissions").append(`<div class="form-group mb-3">
    <label class="form-control-label d-inline d-sm-inline d-md-inline d-lg-none d-xl-none">
        <i class="fas fa-toggle-on"></i> ${item.Text}
    </label>
    <div class="input-group input-group-merge input-group-alternative">
        <div class="input-group-prepend d-none d-sm-none d-md-none d-lg-inline d-xl-inline">
            <span class="input-group-text">
                <strong>
                    <i class="fas fa-toggle-on"></i> ${item.Text}
                </strong>
            </span>
        </div>
        <label class="custom-toggle ml-2 mt-2 mr-4">
            <input type="checkbox" value="${item.Value}" ${(item.Selected == true ? "checked" : "")}>
            <span class="custom-toggle-slider rounded-circle" data-label-off="OFF" data-label-on="ON">
            </span>
        </label>
    </div>
</div>`);
                });

                    
                },
                complete: () => {
                },
                error: err => {
                    console.log("Error:" + err)
                }
            });
    });

    $("#update-button").on("click", function (e) {
        let formData = new FormData();

        //RoleId value
        formData.append("RoleId", RoleId);

        //MenuId and Selected values
        $("input:checkbox").each(function () {
            formData.append("MenuId", $(this).val()?.toString() ?? "");
            formData.append("Selected", $(this).is(":checked")?.toString())
        });

        //Setup request
        var xmlHttpRequest = new XMLHttpRequest();
        //Set event listeners
        xmlHttpRequest.upload.addEventListener("loadstart", function (e) {
            // @ts-ignore
            $.notify({ message: "Sending data. Please, wait" }, { type: "info", placement: { from: "bottom", align: "center" } });
        });
        xmlHttpRequest.onload = function () {
            console.log(xmlHttpRequest);
            if (xmlHttpRequest.status >= 400) {
                //ERROR
                // @ts-ignore
                $.notify({ message: "There was an error while sending the data" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                console.log(xmlHttpRequest);
            }
            else {
                //SUCCESS
                // @ts-ignore
                $.notify({ message: "Data sent successfully" }, { type: "success", placement: { from: "bottom", align: "center" } });
            }
        };
        //Open connection
        xmlHttpRequest.open("POST", "/api/CMSCore/RoleMenu/1/InsertPermissions/", true);
        //Send request
        xmlHttpRequest.send(formData);
    });
}

