/*******************************
****Revealing module experimen** 
var calculator = (function () {

    function add(a, b) {
        alert(a + b);
    }
    function minus(a, b) {
        alert(a - b);
    }
    return {
        Add: add, Minus: minus
    }

})();

calculator.Add(1, 1);
******************************/
var stof = stof || {};
stof.searchViewModel = (function () {
    var searchText = ko.observable("");
    var suggestions = ko.observableArray([]);
    var visible = ko.observable(false);
    //var selected = false;
    //var toggle = function (target, event) {
    //    alert(selected);
    //    selected=!selected;
    //};
    var getSuggestions = function (target, event) {
        $.getJSON("api/questions/search/" + this.searchText(), function (result) {
            if (result.length >= 1) {
            	visible(true);
            	
            	suggestions(result);
            	console.log(suggestions());
            } else { visible(false); }
        });

    }
    return {
        searchText: searchText,
        suggestions: suggestions,
        getSuggestions: getSuggestions,
        visible: visible
        //selected: selected
        //toggle: toggle
    };
})();









ko.applyBindings(stof.searchViewModel);