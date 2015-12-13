var my = my || {};

my.viewModel = (function () {
	var currentMenu = ko.observable("");
	var menuItems = ["Users", "Annotations", "Categories"],
		currentView = ko.observable("users_view"),
		data = ko.observableArray([]),
		showContent = function (menu) {
			var name = menu.toLowerCase();
			currentView(name + "_view");
			currentMenu(menu);
			$.getJSON("http://localhost:3133/api/" + name, function (result) {
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

my.viewModel.showContent("users");

ko.applyBindings(my.viewModel);
