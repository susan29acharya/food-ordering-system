<script src="~/lib/jquery/dist/jquery.min.js"></script>
function Signup() {

    var username = $("#username").val();
    var firstname = $("#firstname").val();
    var lastname = $("#lastname").val();
    var email = $("#email").val();
    var mobilenumber = $("#mobilenumber").val();
    var password = $("#password").val();

    if (username == '' || firstname == '' || lastname == '' || email == '' || mobilenumber == '' || password == '') {
        alert("All field are required !!");
        return;
    }


    $.ajax({
        url: '@Url.Action("User_Signup", "User_Setup")',
        type: 'POST',
        dataType: 'json',
        data: {
            UserName: username,
            FirstName: firstname,
            LastName: lastname,
            Email: email,
            MobileNo: mobilenumber,
            Pwd: password
        },
        success: function (response) {

            if (response.code == 1) {
                alert("alreadyyyyyyyyyyyyyyyyy");
                username = $("#username").val('');
                firstname = $("#firstname").val('');
                lastname = $("#lastname").val('');
                email = $("#email").val('');
                mobilenumber = $("#mobilenumber").val('');
                password = $("#password").val(''); 
                window.location.href = '@Url.Action("User_Signup", "User_Setup")';
            }
            else {
                alert(response.message);
                window.location.href = '@Url.Action("User_Login", "User_Setup")';
            }
        },
        error: function (xhr, status, error) {
            alert("error")
        }
    })

}