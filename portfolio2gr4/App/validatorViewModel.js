var validatorViewModel = (function () {
    
    var validate = function (target,event) {
        var userIDFormat = /^[0-9]*$/;
        var userinput = $("#LoginInput").val();
        if (userIDFormat.test(userinput) && userinput!=="") {
            $("#login-div").removeClass("has-error").addClass("has-success");
            $("#state-icon").removeClass("glyphicon-remove").addClass("glyphicon-ok");
        } else {
            $("#login-div").removeClass("has-success").addClass("has-error");
            $("#state-icon").removeClass("glyphicon-ok").addClass("glyphicon-remove");
        }
    };
    return { validate: validate };
})();

//login-div has-success  has-error
//LoginInput
//state-icon glyphicon-ok  glyphicon-remove