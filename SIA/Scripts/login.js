$(document).ready(function () {

    $("#registrationForm").validate({
        rules: {
            username: {
                required: true
            },
            password: {
                required: true
            }
        },
        messages: {
            username: {
                required: "Username cannot be empty"
            },
            password: {
                required: "Password cannot be empty"
            }
        },
        submitHandler: function (form) {
            var url = $(form).attr("action");
            var data = $(form).serialize();
            $.ajax({
                url: url,
                type: "POST",
                data: data,
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                success: function (res) {
                    if (res =="True") {
                        swal("Nice!", "Information Added", "success");
                        window.location.href = "../DataTable/DataTables";
                    }
                    else {
                        swal("Error!", "Incorrect Username or Password", "Try Again");
                    }
                },
                error: function (res) {

                }
            });
        }
    });
});
