var myModal = new bootstrap.Modal(document.getElementById('userModel'))

$(document).ready(function () {
    
    GetAllUsers();
});

function AddUser() {
    $("#uid").val(0);
    $("#uname").val("");
    $("#email").val("");
    $("#password").val("");
    $("#roleid").val(0);
    $("#roleid").prop("disabled", false);
    myModal.show();
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
                $('#userTable').empty();
                $.each(data.data, function (index, users) {
                    $('#userTable').append('<tr><td>' + users.uname + '</td><td>' + users.email + '</td><td>' + users.rolename +
                        '</td><td><a class="btn btn-warning" onclick="EditUser(' + users.uid + ')">Edit</a><a class="mx-2 btn btn-danger" onclick="DeleteUser(' + users.uid + ')">Delete</a></td></tr>');
                });
            }
        },
        error: function (xhr, status, error) {
            console.error("Error retrieving users:", error);
        }
    });

}

function EditUser(id) {

    $.ajax({
        type: "GET",
        url: "/user/edituser",
        data: { uid: id },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (!data.flag) {
                alert(data.message);
            }
            else {

                $("#uid").val(data.data.uid);
                $("#uname").val(data.data.uname);
                $("#email").val(data.data.email);
                $("#password").val(data.data.pass);
                $("#roleid").val(data.data.roleid);
                myModal.show();
                /*$("#role").prop("disabled", false);*/

            }
        },
        error: function (xhr, status, error) {
            console.error("Error retrieving users:", error);
        }
    });

}

function SaveUser() {
    if ($("#uid").val() > 0) {
        UpdateUser();
    }
    else {
        InsertUser();
    }
}

function UpdateUser() {
    var user = {
        uid: $("#uid").val(),
        uname: $("#uname").val(),
        email: $("#email").val(),
        pass: $("#password").val(),
        roleid: $("#roleid").val()
    };
    $.ajax({
        type: "POST",
        url: "/user/updateuser",
        data: JSON.stringify(user),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.flag) {
                alert(data.message);
                CloseModal();
                GetAllUsers();
            } else {
                alert(data.message);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error saving user:", error);
            alert("An error occurred while saving the user.");
        }
    });
}

function InsertUser() {
    var user = {
        uid: $("#uid").val(),
        uname: $("#uname").val(),
        email: $("#email").val(),
        pass: $("#password").val(),
        roleid: $("#roleid").val()
    };

    $.ajax({
        type: "POST",
        url: "user/insertuser",
        data: JSON.stringify(user),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            debugger
            if (data.flag) {
                alert(data.message);
                CloseModal();
                GetAllUsers();
            } else {
                alert("Error adding user: " + data.message);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error adding user:", error);
            alert("An error occurred while adding the user.");
        }
    });
}

function DeleteUser(id) {

    if (confirm("Are you sure want to delete this record?") == true) {
        $.ajax({
            type: "GET",
            url: "user/deleteuser",
            data: { uid: id },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert(data.message);
                GetAllUsers();
            },
            error: function (xhr, status, error) {
                console.error("Error retrieving users:", error);
            }
        });
    } 
}

function LoginUser() {

    
        $.ajax({
            type: "GET",
            url: "user/loginuser",
            data: { email: $("#email").val(), password: $("#password").val() },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                debugger
                if (!data.flag) {
                    
                    alert(data.message);
                    return;
                }
                else {
                    
                    alert(data.message);
                    
                    if (data.data.rolename == "Admin") {
                        sessionStorage.setItem("UserID", data.data.uid);
                        window.location.href = "Index";
                    }
                    else {
                        window.location.href = "MyTask";
                    }
                }
                GetAllUsers();
            },
            error: function (xhr, status, error) {
                console.error("Error retrieving users:", error);
            }
        });
    
}

function CloseModal() {
    myModal.hide();
}
