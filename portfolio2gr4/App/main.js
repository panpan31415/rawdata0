﻿var my = my || {};

my.viewModel = (function () {
	var currentMenu = ko.observable(""); 
	var menuItems = ["Users", "Annotations", "Categories", "History"],
		currentView = ko.observable("users_view"),
		data = ko.observableArray([]),
		history = ko.observableArray([]),
		showContent = function (menu) {
			var name = menu.toLowerCase();
			currentView(name + "_view");
			currentMenu(menu);
			if (name === "history") {
				name = "users/108/historys";
				$.getJSON("http://localhost:3133/api/" + name, function (result) {
 
					for(var i=0;i<result.length;i++){
						history.push(new HistoryItem(result[i]));
						console.log("res:");
						console.log(history());
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

		},
		isActive = function (menu) {
			return menu === currentMenu();
		},
	showList = ko.observable(true)
	;

	function HistoryItem(data) {
		var self = this;
		console.log(data);
		self.Url = data.Url;
		self.userId = data.UserId;
		self.body = data.Body;
		self.searchDate = data.SearchDate;

	};
	return {
		showContent: showContent,
		currentView: currentView,
		data: data,
		history: history,
		menuItems: menuItems,
		isActive: isActive,
		showList: showList
	};


}());



my.viewModel.showContent("users");

ko.applyBindings(my.viewModel);
