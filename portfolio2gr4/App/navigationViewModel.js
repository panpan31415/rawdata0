
var navigationViewModel = (function () {
    var currentMenu = ko.observable("");
    var menuItems = ["Users", "Annotations", "Questions", "History"];
    var currentView = ko.observable("");
    var showContent = function (menu) {
        var toggle = $("#navbar-toggle-button").attr("aria-expanded");
        if (toggle = (toggle === "true")) {
            $("#navbar-collapse").click(function () {
                $("#navbar-toggle-button").trigger('click');
            });
        }
        var name = menu.toLowerCase();
        currentMenu(menu);
        $("#search_textbox").attr("placeholder", "Search " + currentMenu());
        currentView("questions" + "_view");
        QuestionViewModel.loadQuestionTitles();
    };

    isActive = function (menu) {
        return menu === currentMenu();
    };
    return {
        currentMenu: currentMenu,
        showContent: showContent,
        currentView: currentView,
        menuItems: menuItems,
        isActive: isActive
    };
}());
/***
if (name === "history") {
            history([]);
            $.getJSON("api/historys/search/" + searchText() + "-" + navigationViewModel.uid() + "-" + navigationViewModel.size() + "-" + navigationViewModel.page(), function (result) {
                if (result.length >= 1) {
                    history(result);
                } else {
                    alert("no result found!");
                }

            });
        } else if (name === "users") {
            name = "users/10-1";
            users([]);
            //$("#suggestionList option").attr(" data-bind", "value:$data.Title");
            $.getJSON("http://localhost:3133/api/" + name, function (result) {

                for (var i = 0; i < result.length; i++) {
                    users.push(new UsersItem(result[i]));
                    //console.log("res:");
                    //console.log(history());
                    function uri() {

                    }
                };

            });
        } else if (name === "questions") {
            name = "questions/10-1";
            questions([]);
            // $("#suggestionList option").attr(" data-bind", "value:$data.Title");
            $.getJSON("http://localhost:3133/api/" + name, function (result) {

                for (var i = 0; i < result.length; i++) {
                    questions.push(new QuesItem(result[i]));
                    //console.log("res:");
                    //console.log(history());
                };

            });
        } else {
            $.getJSON("http://localhost:3133/api/" + name, function (result) {
                //console.log(result);
                data(result);
                console.log("res:");
                console.log(data());
            });
        }
*/