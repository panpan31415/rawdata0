var loginViewModel = (function () {
    var uid = ko.observable(0);
    var user_url = ko.observable();
    var loginStatus = ko.observable(false);
    var displaytext = ko.observable("Login");
    var bootbox_title = ko.observable("StackOverflow ");
    var login = function () {

        bootbox.prompt(bootbox_title(), function () {
            
            var result = $('#LoginInput').val();
            if (result === "undefined" || result === "") {
                $("#LoginBtn").removeClass("btn-default btn-success").addClass("btn-warning");
                bootbox.alert(" Please enter a valid userID!");
                displaytext("id not valid!")
            } else if (result === null) {                
                loginStatus(false);
                displaytext("Login");
                $("#LoginBtn").removeClass(" btn-warning btn-success").addClass("btn-default");
            }
            else {
                                
                UserModel.getById(result,
                    function (user) {                        
                        loginStatus(true);
                        displaytext("Hello " + user.Name)
                        uid(user.Id);
                        $("#LoginBtn").removeClass("btn-default btn-warning").addClass("btn-success");
                        UserViewModel.showSingleUserFull(user.Url);
                    }, function (xhr) {
                        loginStatus(false);
                        displaytext("id not found!");
                        $("#LoginBtn").removeClass("btn-default btn-success").addClass("btn-warning");
                        bootbox.alert(" check userID!");
                        uid(0);
                    });
            }
            var toggle = $("#navbar-toggle-button").attr("aria-expanded");
            if (toggle = (toggle === "true")) {
                $("#navbar-collapse").click(function () {
                    $("#navbar-toggle-button").trigger('click');
                });
            }
        });

    };
    return {
        login: login, displaytext: displaytext, loginStatus: loginStatus, uid: uid
    }

})();
//api/users/