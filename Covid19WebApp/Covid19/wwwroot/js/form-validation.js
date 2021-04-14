$(function () {
    $("form[name='CreateACity']").validate({
        success: "valid",
        onkeyup: true,
        focusInvalid: true,
        errorClass: "error",
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },

        // Validation rules

        rules: {
            cityName: {
                required: true,
                minlength: 5
            },
            population: {
                required: true,
                number: true,
                digits: true
            }
        },

        // Validation error messages

        messages: {
            cityName: {
                required: "Please enter a city!",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            population: {
                required: "Please enter the population of the city!",
                number: "Please enter numbers only!",
                digits: "Only digits are allowed in this field!",
            }

        },

        submitHandler: function (form) {
            form.submit();
        },

    });



    $("form[name='CreateAHospital']").validate({
        success: "valid",
        onkeyup: true,
        focusInvalid: true,
        errorClass: "error",
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },

        // Validation rules

        rules: {
            hospitalName: {
                required: true,
                minlength: 4
            },
            maxCapacity: {
                required: true,
                number: true,
                digits: true,
            },
            currentCapacity: {
                required: true,
                number: true,
                digits: true
            },
        },

        // Validation error messages

        messages: {
            hospitalName: {
                required: "Please enter a hospital!",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            maxCapacity: {
                required: "Please enter the max capacity of the hospital!",
                number: "Please enter numbers only!",
                digits: "Only digits are allowed in this field!",
            },
            currentCapacity: {
                required: "Please enter the current capacity of the hospital!",
                number: "Please enter numbers only!",
                digits: "Only digits are allowed in this field!",
            }
        },

        submitHandler: function (form) {
            form.submit();
        },

    });



    $("form[name='CreateAPatient']").validate({
        success: "valid",
        onkeyup: true,
        focusInvalid: true,
        errorClass: "error",
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },

        // Validation rules

        rules: {
            patientName: {
                required: true,
                minlength: 3
            }
        },

        // Validation error messages

        messages: {
            patientName: {
                required: "Please enter patient name!",
                minlength: jQuery.validator.format("At least {0} characters required!")
            }
        },

        submitHandler: function (form) {
            form.submit();
        },

    });



});