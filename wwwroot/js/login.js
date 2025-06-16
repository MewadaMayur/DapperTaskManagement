

$(document).ready(function () {
    GetAllUsers();
});

function LoginUser() {

    if ($("#loginform").valid()) {
        $.ajax({
            type: "GET",
            url: "User/LoginUser",
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
                    sessionStorage.setItem("UserID", data.data.uid);
                    if (data.data.rolename == "Admin") {

                        window.location.href = "Admin/Index";
                    }
                    else {
                        window.location.href = "User/MyTask";
                    }
                }
                GetAllUsers();
            },
            error: function (xhr, status, error) {
                console.error("Error retrieving users:", error);
            }
        });
    }
    
       
    
}


