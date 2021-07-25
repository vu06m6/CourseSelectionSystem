$(document).ready(function () {
    InitEvent();
    BindTable();
});

function InitEvent() {
    $(".btAdd, .btSave").on("click", function () {
        var checked = [];
        $(".cbCourse:checked").each(function () {
            checked.push($(this).val());
        });

        let data = {
            StudentNumber: $("#rqStudent").val(),
            CheckedCourse: checked
        };
        $.post("../Home/SelectionModify", data, function (data) {
            if (data.code === "S") {
                $("#rqStudent").val();
                $(".cbCourse").prop("checked", false);
                $(".btSave").addClass("d-none");
                $(".btAdd").removeClass("d-none");
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
    $.get("../Home/SelectionTable", function (data) {
        $("#Partialable").html(data);
        $(".btEdit").on("click", function () {
            let data = JSON.parse($(this).attr("data-json"));
            $("#rqStudent").val(data.StudentNumber);
            $.each(data.CheckedCourse, function (idx, val) {
                $(".cbCourse[value='" + val + "']").prop("checked", true);
            });
            $(".btAdd").addClass("d-none");
            $(".btSave").removeClass("d-none");
        });
        $(".btDelete").on("click", function () {
            if (confirm("確定刪除?")) {
                $.post("../Home/SelectionDelete?studentnumber=" + $(this).attr("data-id"), function (data) {
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