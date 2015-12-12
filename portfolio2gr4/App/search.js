var stof = stof || {};
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

stof.searchViewModel = (function () {
    var searchText = ko.observable("");
    var suggestions = ko.observableArray([]);
    var visible = ko.observable(false);
    var getSuggestions = function (target, event) {
        $.getJSON("api/questions/search/" + this.searchText(), function (result) {
            if (result.length >= 1) {
                visible(true);
                suggestions(result);
            } else { visible(false);}
        });

    }
    return {
        searchText: searchText,
        suggestions: suggestions,
        getSuggestions: getSuggestions,
        visible:visible
    };
})();

ko.applyBindings(stof.searchViewModel);
//stof.searchViewModel.searchText("panpan");