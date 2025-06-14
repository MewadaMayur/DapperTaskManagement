var taskModel;

$(function () {
    taskModel = new bootstrap.Modal(document.getElementById('taskModel'))
    GetAllTasks();
    GetAllUsers();
});

function AddTask() {
    $("#taskid").val(0);
    $("#title").val("");
    $("#description").val("");
    $("#status").val("");
    $("#assignid").val(0);
    
    taskModel.show();
}

function GetAllTasks() {
    $.ajax({
        type: "GET",
        url: "/getalltasks",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (!data.flag) {

                return;
            }
            else {
                debugger
                var Tasks = data.data;
                $('#TaskTable').empty();
                $.each(data.data, function (index, Tasks) {
                    $('#TaskTable').append('<tr><td>' + Tasks.title + '</td><td>' + Tasks.uname + '</td><td>' + Tasks.status +
                        '</td><td><a class="btn btn-warning" onclick="EditTask(' + Tasks.taskid + ')">Edit</a><a class="mx-2 btn btn-danger" onclick="DeleteTask(' + Tasks.taskid + ')">Delete</a></td></tr>');
                });
            }
        },
        error: function (xhr, status, error) {
            console.error("Error retrieving Tasks:", error);
        }
    });

}

function EditTask(id) {

    $.ajax({
        type: "GET",
        url: "/edittask",
        data: { uid: id },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (!data.flag) {
                alert(data.message);
            }
            else {

                $("#taskid").val(data.data.taskid);
                $("#title").val(data.data.title);
                $("#description").val(data.data.description);
                $("#status").val(data.data.status);
                $("#assignid").val(data.data.assignedid);
                taskModel.show();
            }
        },
        error: function (xhr, status, error) {
            console.error("Error retrieving Tasks:", error);
        }
    });

}

function SaveTask() {
    if ($("#taskid").val() > 0) {
        UpdateTask();
    }
    else {
        InsertTask();
    }
}

function UpdateTask() {
    var Task = {
        taskid: $("#taskid").val(),
        title: $("#title").val(),
        description: $("#description").val(),
        status: $("#status").val(),
        assignedid: parseInt($("#assignid").val()),
    };
    $.ajax({
        type: "POST",
        url: "/updatetask",
        data: JSON.stringify(Task),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.flag) {
                alert(data.message);
                CloseModal();
                GetAllTasks();
            } else {
                alert(data.message);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error saving Task:", error);
            alert("An error occurred while saving the Task.");
        }
    });
}

function InsertTask() {
    var Task = {
        taskid: $("#taskid").val(),
        title: $("#title").val(),
        description: $("#description").val(),
        status: $("#status").val(),
        assignedid: parseInt($("#assignid").val()),
    };

    $.ajax({
        type: "POST",
        url: "/inserttask",
        data: JSON.stringify(Task),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            debugger
            if (data.flag) {
                alert(data.message);
                CloseModal();
                GetAllTasks();
            } else {
                alert(data.message);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error adding Task:", error);
            alert("An error occurred while adding the Task.");
        }
    });
}

function DeleteTask(id) {

    if (confirm("Are you sure want to delete this record?") == true) {
        $.ajax({
            type: "GET",
            url: "/deletetask",
            data: { taskid: id },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert(data.message);
                GetAllTasks();
            },
            error: function (xhr, status, error) {
                console.error("Error retrieving Tasks:", error);
            }
        });
    }
}

function CloseModal() {
    taskModel.hide();
}

function GetAllUsers() {
    $.ajax({
        type: "GET",
        url: "/user/getalluser",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (!data.flag) {

                return;
            }
            else {
                debugger
                var users = data.data;
                $('#assignid').empty();
                $("#assignid").append($("<option     />").val(0).text("--Select Assign To--")).select;
                $.each(data.data, function (index, users) {
                    $("#assignid").append($("<option     />").val(users.uid).text(users.uname));
                });
            }
        },
        error: function (xhr, status, error) {
            console.error("Error retrieving users:", error);
        }
    });

}