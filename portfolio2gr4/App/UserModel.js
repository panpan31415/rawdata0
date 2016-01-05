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
    var getUsers_short = function (callback)
    {
        $.ajax({
            url: "/api/users/",
            type: 'GET',
            dataType: 'json',
            success: callback,
            error: function () { alert('boo!'); },//for testing purpose
            beforeSend: PaginationViewModel.setRequestHeader
        });
    }
    var user_short_template;
    return { getById: getById, getByUrl: getByUrl, user_short_template: user_short_template, getUsers_short: getUsers_short };
})();

