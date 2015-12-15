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
    //var visible = ko.observable(false);
    //var selected = false;
    //var toggle = function (target, event) {
    //    alert(selected);
    //    selected=!selected;
    //};
    var getSuggestions = function (target, event) {
        $.getJSON("api/questions/search/" + searchText(), function (result) {            
            if (result.length >= 1) {
               
                var titles = $.map(result, function (q) {
                    return q.Title;
                });
                suggestions(result);
            }
        });
        ;
    };

    return {
        searchText: searchText,
        suggestions: suggestions,
        getSuggestions: getSuggestions,
        //visible: visible
        //selected: selected
        //toggle: toggle
    };
})();
var viewModel = stof.searchViewModel;
ko.applyBindings(viewModel);
//var substringMatcher = function (strs) {
//    return function findMatches(q, cb) {
//        var matches, substringRegex;

//        // an array that will be populated with substring matches
//        matches = [];

//        // regex used to determine if a string contains the substring `q`
//        substrRegex = new RegExp(q, 'i');

//        // iterate through the pool of strings and for any string that
//        // contains the substring `q`, add it to the `matches` array
//        $.each(strs, function (i, str) {
//            if (substrRegex.test(str)) {
//                matches.push(str);
//            }
//        });

//        cb(matches);
//    };
//};

////var states = viewModel.suggestions;

//$('#the-basics .typeahead').typeahead({
//    hint: true,
//    highlight: true,
//    minLength: 1
//},
//{
//    name: 'states',
//    source: substringMatcher(states)
//});
//$('#scrollable-dropdown-menu .typeahead').typeahead(null, {
//    name: 'countries',
//    limit: 10,
//    source: viewModel.suggestions
//});
////$('#scrollable-dropdown-menu .typeahead').typeahead(null, {
////    name: 'titles',
////    limit: 10,
////    source: stof.searchViewModel.suggestions
////});

////$(document).ready(function () {
////    var substringMatcher = function (strs) {
////        return function findMatches(q, cb) {
////            var matches, substringRegex;
////            alert("hello");
////            // an array that will be populated with substring matches
////            matches = [];

////            // regex used to determine if a string contains the substring `q`
////            substrRegex = new RegExp(q, 'i');

////            // iterate through the pool of strings and for any string that
////            // contains the substring `q`, add it to the `matches` array
////            $.each(strs, function (i, str) {
////                if (substrRegex.test(str)) {
////                    matches.push(str);
////                }
////            });

////            cb(matches);
////        };
////    };
////});





