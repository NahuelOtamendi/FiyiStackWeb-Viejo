"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var $ = require("jquery");
var Rx = require("rxjs");
var ajax_1 = require("rxjs/ajax");
require("bootstrap-notify");
var RoleId = "0";
//LOAD EVENT
if ($("#title-page").html().includes("Permissions")) {
    //Activate when the button is pushed
    $(".role-a").on("click", function (e) {
        var _a, _b;
        RoleId = (_b = (_a = $(this).next().val()) === null || _a === void 0 ? void 0 : _a.toString()) !== null && _b !== void 0 ? _b : "";
        $("#checkboxes-permissions").html("");
        Rx.from(ajax_1.ajax.get("/api/CMSCore/RoleMenu/1/SelectAllByRoleIdToRoleMenuForChechboxes/" + RoleId)).subscribe({
            next: function (newrow) {
                newrow.response.forEach(function (item) {
                    $("#checkboxes-permissions").append("<div class=\"form-group mb-3\">\n    <label class=\"form-control-label d-inline d-sm-inline d-md-inline d-lg-none d-xl-none\">\n        <i class=\"fas fa-toggle-on\"></i> " + item.Text + "\n    </label>\n    <div class=\"input-group input-group-merge input-group-alternative\">\n        <div class=\"input-group-prepend d-none d-sm-none d-md-none d-lg-inline d-xl-inline\">\n            <span class=\"input-group-text\">\n                <strong>\n                    <i class=\"fas fa-toggle-on\"></i> " + item.Text + "\n                </strong>\n            </span>\n        </div>\n        <label class=\"custom-toggle ml-2 mt-2 mr-4\">\n            <input type=\"checkbox\" value=\"" + item.Value + "\" " + (item.Selected == true ? "checked" : "") + ">\n            <span class=\"custom-toggle-slider rounded-circle\" data-label-off=\"OFF\" data-label-on=\"ON\">\n            </span>\n        </label>\n    </div>\n</div>");
                });
            },
            complete: function () {
            },
            error: function (err) {
                console.log("Error:" + err);
            }
        });
    });
    $("#update-button").on("click", function (e) {
        var formData = new FormData();
        //RoleId value
        formData.append("RoleId", RoleId);
        //MenuId and Selected values
        $("input:checkbox").each(function () {
            var _a, _b, _c;
            formData.append("MenuId", (_b = (_a = $(this).val()) === null || _a === void 0 ? void 0 : _a.toString()) !== null && _b !== void 0 ? _b : "");
            formData.append("Selected", (_c = $(this).is(":checked")) === null || _c === void 0 ? void 0 : _c.toString());
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
//# sourceMappingURL=PagePermissions.js.map