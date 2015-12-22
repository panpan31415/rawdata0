var loginViewModel = (function () {
    var uid = ko.observable();
    var user_url = ko.observable();
    var loginStatus = false;
    var displaytext = ko.observable("Login");
    var bootbox_title = ko.observable("StackOverflow ");
    var getUserName = function (id) {
        $.getJSON("/api/users/" + id,null)
  .done(function (json) {
      displaytext("Hello " + json.Name);
      user_url(json.Url);
      uid(id);
      loginStatus = true;
  })
  .fail(function (jqxhr, textStatus, error) {
      var err = textStatus + ", " + error;
      bootbox.alert("Login Failed, Try again ! "+err, function () {
          //nothing todo 
      });
  });
        //$.getJSON("/api/users/" + id, function (json) {
        //    success = true;
        //    // ... do what you need to do here
        //});
        //setTimeout(function () {
        //    if (!success) {
        //        // Handle error accordingly
        //        bootbox.alert("Connot connect to Server", function () {
        //            loginStatus = false;//nothing todo
        //        });
        //    }
        //}, 5000);
        //if (success) {
        //    $.getJSON("/api/users/" + id, function (result) {
        //        displaytext("Hello " + result.Name);
        //        user_url(result.Url);
        //        uid(id);
        //        loginStatus = true;
        //    });
        //} else {
        //    bootbox.alert("Login Failed, Try again !", function () {
        //        //nothing todo 
        //    });
        //}
    };
    var setLoginInfo = function () {
        if (!loginStatus) {
            displaytext("Login");
            bootbox.prompt(bootbox_title(), function (result) {
                if (result === null) {
                } else {
                    var userinput = $("#LoginInput").val();
                    getUserName(userinput);
                    loginStatus = true;

                }
            });
        } else {
            displaytext("Log out!");
            loginStatus = false;
        }

    };




    return {
        displaytext: displaytext,
        setLoginInfo: setLoginInfo
    };

})();
//api/users/