var QuestionViewModel = (function () {// 
    /****List titles of questions (questions_short)***/
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
    var question_full = ko.observable();
    var showQuestion_full = function (url) {
        QuestionModel.getByUrl(url, function (q) {
            var UserName = ko.observable();
            var UserUrl = ko.observable();
            UserModel.getById(q.OwnerId, function (user) {
                UserName(user.Name); UserUrl(user.Url);
                question_full({ Title: q.Title, Url: q.Url, CreationDate: q.CreationDate, UserName: UserName(), UserUrl: UserUrl(), Score: q.Score, Body: q.Body });
                loadComments((q.Url).substring(url.lastIndexOf('/') + 1));// get id from url
                navigationViewModel.currentView("question_view");
            });
        });
    };
    /*****show comments for a specific question*****/
    var commentsOfQestion = ko.observableArray();
    var loadComments = function (questionId) {
        QuestionModel.getCommentsByQuestionID(questionId, function (result) {
            if (result.length > 0) {
                alert(result.length);
                $.map(result, function (c) {
                    var CommentOwnerName = ko.observable();
                    var CommentOwnerUrl = ko.observable();
                    UserModel.getById(c.UserId, function (user) {
                        CommentOwnerName(user.Name);
                        CommentOwnerUrl(user.Url);
                        commentsOfQestion.push({ CommentBody: c.text, CommentDate: c.creationDate, CommentOwnerName: CommentOwnerName(), CommentOwnerUrl: CommentOwnerUrl() });
                       
                    });

                });
            }
        });
    };
    return {
        loadQuestionTitles: loadQuestionTitles,
        questions_short: questions_short,
        question_full: question_full,
        showQuestion_full: showQuestion_full,
        commentsOfQestion: commentsOfQestion
    };
})();