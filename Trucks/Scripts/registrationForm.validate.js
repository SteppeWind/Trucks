$(function () {
    $.validator.setDefaults({
        highlight: function(element) {
            $(element).closest(".form-group").addClass("input-error");
        },
        unhighlight: function (element) {
            $(element).closest(".form-group").removeClass("input-error");
        }
    });

    $("form, #form").validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            name: {
                required: true
            },
            surname: {
                required: true
            }
        },
        messages: {
            email: {
                required: "Please enter an email address",
                email: "Please enter a <em>valid</em> email address"
            }
        }
    });
});