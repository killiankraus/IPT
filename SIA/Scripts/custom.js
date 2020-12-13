function numberCheck(input) {

    var regex = /[^0-9]/gi;
    input.value = input.value.replace(regex, "");

}

$(document).ready(function () {

    $(document).ajaxStart(function () {
        $("#ajaxLoader").show();
    }).ajaxStop(function () {
        $("#ajaxLoader").hide();
    });

    $("#registrationForm").validate({
        rules: {
            FirstName: {
                required: true,
                minlength: 2
            },
            LastName: {
                required: true,
                minlength: 2
            },
            Birthdate: {
                required: true
            },
            Contact: {
                required: true,
                digits: true,
                minlength: 10
            },
            EmailAddress: {
                required: true,
                email: true,
                minlength: 10
            },
            AddressLines: {
                required: true,
                minlength: 2
            },
            Username: {
                required: true,
                minlength: 8,
                remote: "../Home/checkUserName"
            },
            Password: {
                required: true,
                minlength: 8,
                passwordRegex: true
            },
            ConfirmPassword: {
                required: true,
                minlength: 8,
                equalTo: "#Password"
            }
        },
        messages: {
            FirstName: {
                required: "Please provide your First Name",
                minlength: "Name is too Short"
            },
            LastName: {
                required: "Please provide your Last Name",
                minlength: "LastName is too Short"
            },
            Contact: {
                required: "Please provide your Cellphone Number",
                digits: "Please provide numbers only!",
                minlength: "Contact Number is too Short"
            },
            Birthdate: {
                required: true,
                required: "PLease Enter your Date of Birth"
            },
            EmailAddress: {
                required: "Please provide your Email Address",
                email: "Please provide a valid Email Address",
                minlength: "Make sure to have a good Email"
            },
            AddressLines: {
                required: "Please provide your Home Address",
                minlength: "Address is too Short"
            },
            Username: {
                required: "Please provide your UserName",
                minlength: "Username is too Short",
                remote: "Username is already taken"
            },
            Password: {
                required: "Please provide password",
                minlength: "Password must be minimum of 8 digits!",
                passwordRegex: "Password must include uppercase, number and special character"
            },
            ConfirmPassword: {
                required: "Please Confirm password",
                minlength: "Password must be minimum of 8 digits!",
                equalTo: "cofirmed password is not equal to your password"
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
                    if (res.success) {
                        swal("Nice!", "Information Added", "success");
                        window.location.href = "../Account/Login";
                    }
                    else {
                        swal("Error!", "Username or Password is Incorrect", "error");
                    }
                },
                error: function (res) {

                }
            });

        }
    });
    

    jQuery.validator.addMethod("passwordRegex", function (value, element) {
        var regex = new RegExp("^((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*]))");
        var key = value;

        if (!regex.test(key)) {
            return false;
        }
        return true;
    });


});
