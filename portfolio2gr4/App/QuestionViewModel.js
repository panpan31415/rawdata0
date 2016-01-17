var QuestionViewModel = (function () {
    var self = this;
    /****List titles of questions (questions_short)***/
    var questions_short = ko.observableArray();
    var loadQuestionTitles = function () {
        if (questions_short().length > 0) {
            questions_short.removeAll();
            $("#questions_short").empty();
            $("#questions_short").append(QuestionModel.question_short_template);
        }

        QuestionModel.getQuestions_short(function (result, status, xhr) {
            if (result.length >= 1) {
                $.map(result, function (q) {
                    var UserName = ko.observable();
                    var UserUrl = ko.observable();
                    UserModel.getById(q.OwnerId, function (user) {
                        UserName(user.Name); UserUrl(user.Url);
                        questions_short.push({ Title: q.Title, Url: q.Url, CreationDate: q.CreationDate, UserName: UserName(), UserUrl: UserUrl() });
                    });
                });
            }
            PaginationViewModel.initialize(xhr, loadQuestionTitles);
            navigationViewModel.currentView("questions" + "_view");
        });
    };
    /***show search result ****/
    var search_questions = function (searchText) {
        if (questions_short().length > 0) {
            questions_short.removeAll();
            $("#questions_short").empty();
            $("#questions_short").append(QuestionModel.question_short_template);
        }
        QuestionModel.search_questions(searchText, function (result, status, xhr) {
            if (result.length >= 1) {
                $.map(result, function (q) {
                    var UserName = ko.observable();
                    var UserUrl = ko.observable();
                    UserModel.getById(q.OwnerId, function (user) {
                        UserName(user.Name); UserUrl(user.Url);
                        questions_short.push({ Title: q.Title, Url: q.Url, CreationDate: q.CreationDate, UserName: UserName(), UserUrl: UserUrl() });
                    });
                });
            }
            PaginationViewModel.initialize(xhr, loadQuestionTitles);
            navigationViewModel.currentView("questions" + "_view");
        });

    }
    /***show a specific question (question_full)****/
    var question_full = ko.observable();
    var showQuestion_full = function (url) {
        QuestionModel.getByUrl(url, function (q) {
            var UserName = ko.observable();
            var UserUrl = ko.observable();
            UserModel.getById(q.OwnerId, function (user) {
                UserName(user.Name); UserUrl(user.Url);
                question_full({Id:q.Id, Title: q.Title, Url: q.Url, CreationDate: q.CreationDate, UserName: UserName(), UserUrl: UserUrl(), Score: q.Score, Body: q.Body, answerCount: q.answerCount });
                loadCommentsForQuestion(q.Id);
                loadAnswers(q.Id);
                navigationViewModel.currentView("question_view");
            });
        });
    };
    /*****show comments for a specific question*****/
    var commentsOfQestion = ko.observableArray();
    var loadCommentsForQuestion = function (questionId) {
        if (commentsOfQestion().length > 0) {
            commentsOfQestion.removeAll();
        }
        QuestionModel.getCommentsByQuestionID(questionId, function (comments) {
            if (comments.length > 0) {
                $.map(comments, function (c) {
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
    /******show answers for a specific question******/
    var answersOfQestion = ko.observableArray();
    var loadAnswers = function (questionId) {
        if (answersOfQestion().length > 0) {
            answersOfQestion.removeAll();
        }
        AnswerModel.getAnswersByQuestionId(questionId, function (answers) {
            if (answers.length > 0) {
                $.map(answers, function (answer) {
                    var answerOwnerName = ko.observable();
                    var answerOwnerUrl = ko.observable();
                    UserModel.getById(answer.OwnerId, function (user) {
                        answerOwnerName(user.Name);
                        answerOwnerUrl(user.Url);
                        answersOfQestion.push({ AnswerBody: answer.Body, AnswertDate: answer.CreationDate, AnswerScore: answer.Score, AnswerOwner: answerOwnerName(), AnswerOwnerUrl: answerOwnerUrl() });
                    });
                    loadCommentsForAnswer(answer.Id);
                });
            }
        });
    };
    /******show comments for a specific answer ******/
    var commentsOfAnswer = ko.observableArray();
    var loadCommentsForAnswer = function (AnswerID) {
        if (commentsOfAnswer().length > 0) {
            commentsOfAnswer.removeAll();
        }
        AnswerModel.getCommentsByAnswerId(AnswerID, function (comments) {
            if (comments.length > 0) {
                $.map(comments, function (c) {
                    var CommentOwnerName = ko.observable();
                    var CommentOwnerUrl = ko.observable();
                    UserModel.getById(c.UserId, function (user) {
                        CommentOwnerName(user.Name);
                        CommentOwnerUrl(user.Url);
                        commentsOfAnswer.push({ CommentBody: c.text, CommentDate: c.creationDate, CommentOwnerName: CommentOwnerName(), CommentOwnerUrl: CommentOwnerUrl() });
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
        commentsOfQestion: commentsOfQestion,
        answersOfQestion: answersOfQestion,
        commentsOfAnswer: commentsOfAnswer,
        showSingleUserShort: UserViewModel.showSingleUserShort,
        search_questions: search_questions
    };
})();