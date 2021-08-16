$(document).ready(function () {
    InitEvent();
    BindTable();
});

function InitEvent() {
    $(".btAdd, .btSave").on("click", function () {
        let data = {
            Serial: $("#rqSerial").val(),
            Number: $("#rqNumber").val(),
            Name: $("#rqName").val(),
            Birthday: $("#rqBirthday").val(),
            Email: $("#rqEmail").val(),
        };
        $.post("../Home/StudentModify", data, function (data) {
            if (data.code === "S") {
                ClearText();
                BindTable();
                alert(data.message);
            }
            else {
                alert(data.message);
            }
        });
    });
}

function BindTable() {
    $.get("../Home/StudentTable", function (data) {
        $("#Partialable").html(data);
        $(".btEdit").on("click", async function () {
            await ClearText();
            let data = JSON.parse($(this).attr("data-json"));
            $("#rqSerial").val(data.Serial);
            $("#rqNumber").val(data.Number);
            $("#rqName").val(data.Name);
            $("#rqBirthday").val(data.Birthday);
            $("#rqEmail").val(data.Email);
            $(".btAdd").addClass("d-none");
            $(".btSave").removeClass("d-none");
        });
        $(".btDelete").on("click", function () {
            if (confirm("確定刪除?")) {
                let data = { serial: $(this).attr("data-id") };
                $.post("../Home/StudentDelete", data, function (data) {
                    if (data.code === "S") {
                        BindTable();
                        alert(data.message);
                    }
                    else {
                        alert(data.message);
                    }
                });
            }
        });
    });
}

function ClearText() {
    $("input").val("");
    $(".btSave").addClass("d-none");
    $(".btAdd").removeClass("d-none");
}