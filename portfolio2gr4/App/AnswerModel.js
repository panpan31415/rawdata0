var AnswerModel = (function () {

    var getCommentsByAnswerId = function (AnswerId, callback) {
        $.getJSON("/api/answer/comments/" + AnswerId, function (result) {
            callback(result);
        });
    };
    var getAnswersByQuestionId = function (questionID, callback) {
        $.getJSON("/api/question/answers/" + questionID, function (result) {
            callback(result);
        });
    };

    return { getCommentsByAnswerId: getCommentsByAnswerId, getAnswersByQuestionId: getAnswersByQuestionId };
})();

