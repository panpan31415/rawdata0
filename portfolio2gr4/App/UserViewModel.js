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
                    users_short.push({ Name: u.Name, Age:u.Age, Url: u.Url, Reputation: u.Reputation, DownVotes: u.DownVotes, UpVotes: u.UpVotes, Location: u.Location, CreationDate: u.CreationDate });
                });
            } 
            PaginationViewModel.initialize(xhr, loadUserShort);
            navigationViewModel.currentView("users" + "_view");
        });
    }
    return { users_short: users_short, loadUserShort: loadUserShort }


})();