var UserModel = (function () {
    var getById = function (userID, callback) {
        $.getJSON("/api/users/" + userID, function (result) {
            callback(result);
        });
    };
    var getByUrl = function (Url, callback) {
        $.getJSON(Url, function (result) {
            callback(result);
        });
    };
    return { getById: getById, getByUrl: getByUrl };
})();

