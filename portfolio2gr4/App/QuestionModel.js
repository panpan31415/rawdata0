var QuestionModel = (function () {
    var getById = function (questionID, callback) {
        $.getJSON("/api/questions/" + questionID, function (result) {
            callback(result);
        });
    };
    var getByUrl = function (Url, callback) {
        $.getJSON(Url, function (result) {
            callback(result);
        });
    };
    var getCommentsByQuestionID = function (questionID, callback) {
        $.getJSON("/api/question/comments/" + questionID, function (result) {
            callback(result);
        });
    };
    var getQuestions_short = function (callback) {
        $.ajax({
            url: "/api/questions/",
            type: 'GET',
            dataType: 'json',
            success: callback,
            error: function () { alert('boo!'); },//for testing purpose
            beforeSend: PaginationViewModel.setRequestHeader
        });
    };
    var question_short_template;
    return { getById: getById, getByUrl: getByUrl, getCommentsByQuestionID: getCommentsByQuestionID, question_short_template: question_short_template, getQuestions_short: getQuestions_short };
})();

