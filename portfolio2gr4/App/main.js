var my = my || {};

my.viewModel = (function () {
    var currentMenu = ko.observable("");
    var menuItems = ["Orders", "Products", "Categories"],
        currentView = ko.observable("orders_view"),
        data = ko.observableArray([]),
        showContent = function () {
            //var name = menu.toLowerCase();
  //          currentView(name + "_view");
//currentMenu(menu);
            $.getJSON("localhost:3133/api/users" , function (result) {
                data(result);
            });
        },

        isActive = function (menu) {
            return menu === currentMenu();
        },
    showList = ko.observable(true)
    ;
    return {
        showContent: showContent,
        currentView: currentView,
        data: data,
        menuItems: menuItems,
        isActive: isActive,
        showList: showList
    };
}());

my.viewModel.showContent("Orders");

ko.applyBindings(my.viewModel);