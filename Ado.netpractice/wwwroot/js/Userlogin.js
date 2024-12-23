
function Login() {
    debugger;
    var username = $("#username").val();
    var password = $("#password").val();
    if (username == '' || password == '') {
        alert("Enter username and password")
    }
    else {
        $.ajax({
            url: '@Url.Action("User_Login", "User_Setup")',
            type: 'POST',
            dataType: 'json',
            data: {
                UserName: username,
                Pwd: password
            },
            success: function (response) {
                if (response.code == 1) {
                    window.location.href = '@Url.Action("Index", "Product")';
                }
                else if (response.code == 2) {
                    alert(response.message);
                    window.location.href = '@Url.Action("User_Login", "User_Setup")';
                }
                else {
                    alert(response.message);
                }
            },
            error: function (xhr, status, errror) {
                alert("errorrrrrrrr")
            }
        })
    }
}
