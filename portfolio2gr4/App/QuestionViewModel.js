var QuestionViewModel = (function () {// 
    /****List title of questions (questions_short)***/
    var questions_short = ko.observableArray();
    var loadQuestionTitles = function () {
        $.getJSON("/api/questions/", function (result) {
            if (result.length >= 1) {
                $.map(result, function (q) {
                    var UserName = ko.observable();
                    var UserUrl = ko.observable();
                    UserModel.getById(q.OwnerId, function (user) {
                        UserName(user.Name); UserUrl(user.Url);
                        questions_short.push({ Title: q.Title, Url: q.Url, CreationDate: q.CreationDate, UserName: UserName(), UserUrl: UserUrl() });
                        //$("[href$='" + q.Url + "']").click(showQuestion_full(q.Url));
                    });

                });
            }
        });
       
    };

    /***show a specific question (question_full)****/
    var question_full = ko.observable({});
    var showQuestion_full = function (url) {
        QuestionModel.getByUrl(url, function (q) {
            var UserName = ko.observable();
            var UserUrl = ko.observable();
            UserModel.getById(q.OwnerId, function (user) {
                UserName(user.Name); UserUrl(user.Url);
                question_full({ Title: q.Title, Url: q.Url, CreationDate: q.CreationDate, UserName: UserName(), UserUrl: UserUrl(), Score: q.Score, Body: q.Body });
                navigationViewModel.currentView("question_view");
            });
        });
    };
    return {
        loadQuestionTitles: loadQuestionTitles,
        questions_short: questions_short,
        question_full: question_full,
        showQuestion_full: showQuestion_full
    };
})();