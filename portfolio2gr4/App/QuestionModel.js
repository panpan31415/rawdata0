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
    return { getById: getById, getByUrl: getByUrl, getCommentsByQuestionID: getCommentsByQuestionID };
})();

