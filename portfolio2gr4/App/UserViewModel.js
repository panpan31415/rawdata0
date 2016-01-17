var UserViewModel = (function () {
    /****show users information short version****/
    var users_short = ko.observableArray();
    var loadUserShort = function () {
        if (users_short().length > 0) {
            users_short.removeAll();
            $("#users_short").empty();
            $("#users_short").append(UserModel.user_short_template);
        }
        UserModel.getUsers_short(function (result, status, xhr) {
            if (result.length >= 1) {
                $.map(result, function (u) {
                    users_short.push({ Name: u.Name, Age: u.Age, Url: u.Url, Reputation: u.Reputation, DownVotes: u.DownVotes, UpVotes: u.UpVotes, Location: u.Location, CreationDate: u.CreationDate });
                });
            }
            PaginationViewModel.initialize(xhr, loadUserShort);
            navigationViewModel.currentView("users" + "_view");
        });
    };
    var user_popover = ko.observable();
    var showSingleUserShort = function (Url) {
        UserModel.getByUrl
            (Url,
             function (user) {
                 user_popover(user);
                 bootbox.dialog({
                     title: user_popover().Name,
                     message: $("#popup_userinfo").html()
                 }); user_popover_Age
                 $("#user_popover_Age").html(user_popover().Age);
                 $("#user_popover_CreationDate").html(user_popover().CreationDate);
                 $("#user_popover_Reputation").html(user_popover().Reputation);
                 $("#user_popover_Location").html(user_popover().Location);
                 $("#user_popover_UpVotes").html(user_popover().UpVotes);
                 $("#user_popover_DownVotes").html(user_popover().DownVotes);
             },
    null);
    };

    var SingleUserFull = ko.observableArray();
    var SingleUserFull_Annotations = ko.observableArray();
    var SingleUserFull_Histories = ko.observableArray();
    var showSingleUserFull = function (url) {

        if (SingleUserFull.length > 0) {
            SingleUserFull.removeAll();
            SingleUserFull_Annotations.removeAll();
            SingleUserFull_Histories.removeAll();
            $("#user_view").empty();
            $("#user_view").append(UserModel.userFull_template);
        }

        UserModel.getByUrl(url, function (u) {

            SingleUserFull({
                Name: u.Name,
                Age: u.Age,
                Url: u.Url,
                Reputation: u.Reputation,
                DownVotes: u.DownVotes,
                UpVotes: u.UpVotes,
                Location: u.Location,
                CreationDate: u.CreationDate
            });
            UserModel.getAnnotations(u.Id, function (Annotations) {
                if (Annotations.length > 0) {
                    $.map(Annotations, function (Annotation) {
                        var Annotation_Post_Title = "";
                        QuestionModel.getById(Annotation.PostId, function (question) {
                            Annotation_Post_Title = question.Title;
                        })
                        SingleUserFull_Annotations.push({
                            Text: Annotation.Body,
                            Date: Annotation.Date,
                            Title: Annotation_Post_Title
                        });
                    });
                }
            }, null);
            UserModel.getHistories(u.Id, function (histories) {
                if (histories.length > 0) {
                    $.map(histories, function (history) {
                        SingleUserFull_Histories.push({
                            HistoryBody: history.Body,
                            HistoryDate: history.Date
                        });
                    });
                }

            }, null);
        }, null);
        navigationViewModel.currentView("user_view");
    };
    var addAnnotation = function (QuestionID) {
        if (loginViewModel.loginStatus()) {
            UserModel.addAnnotation(loginViewModel.uid, QuestionID, function () { bootbox.alert("Annotation Added Successfully !", null); });
        } else {
            bootbox.alert("Please Login to add annotation !", null);
        }

    }
    return {
        users_short: users_short,
        loadUserShort: loadUserShort,
        showSingleUserShort: showSingleUserShort,
        user_popover: user_popover,
        showSingleUserFull: showSingleUserFull,
        SingleUserFull: SingleUserFull,
        SingleUserFull_Annotations: SingleUserFull_Annotations,
        SingleUserFull_Histories: SingleUserFull_Histories,
        addAnnotation: addAnnotation
    };


})();






