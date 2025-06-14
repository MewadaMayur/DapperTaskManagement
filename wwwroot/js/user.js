
$(function () {
    GetAllMyTasks();

});


function GetAllMyTasks() {
    var uid = sessionStorage.getItem("UserID");
    $.ajax({
        type: "GET",
        url: "/user/getallmytasks",
        data: { id: uid },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (!data.flag) {

                return;
            }
            else {
                
                var Tasks = data.data;
                $('#TaskTable').empty();
                $.each(data.data, function (index, Tasks) {
                    $('#TaskTable').append(
                        '<tr><td>' + Tasks.title + '</td><td>' + Tasks.description + '</td><td>' +
                        '<select id="status_'+index+'" name="status" class="form-select" onchange="updatestatus(' + Tasks.taskid + ', \'' + index + '\')">' +
                        '<option value="" ' + (Tasks.status === "" ? 'selected' : '') + '>--Select--</option>' +
                        '<option value="Pending" ' + (Tasks.status === "Pending" ? 'selected' : '') + '>Pending</option>' +
                        '<option value="Work In Progress" ' + (Tasks.status === "Work In Progress" ? 'selected' : '') + '>Work In Progress</option>' +
                        '<option value="Completed" ' + (Tasks.status === "Completed" ? 'selected' : '') + '>Completed</option>' +
                        '</select>' +
                        '</td></tr>'
                    );



                });
            }
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });



}

function updatestatus(tid, index) {
    

    if (confirm("Are you sure?") == true) {
        $.ajax({
            type: "GET",
            url: "/user/updatetaskstatus",
            data: { id: tid, status: $("#status_" + index).val() },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert(data.message);
                GetAllMyTasks();
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });

    }
    else { GetAllMyTasks(); }
    

}