
var masterVM = masterVM || (function () {
    this.navigationViewModel = navigationViewModel;

})();
var navigationViewModel = (function () {
    var Body = ko.observable("Default");
   
    var menuItems = [ "Questions"],
        currentView = ko.observable("questions_view"),
       currentViewId = ko.observable("questionsId_view"),
       
        questions = ko.observableArray([]),
        questionsId = ko.observableArray([]),
      
		

    GoToId = function () {
     
            $.getJSON("http://localhost:3133/api/questions/7664", function (result) {


                questionsId.push(new QuesItem(result));

            });
    
    },
        showContent = function () {
           
                $.getJSON("http://localhost:3133/api/questions/10-1", function (result) {

                    for (var i = 0; i < result.length; i++) {
                        questions.push(new QuesItem(result[i]));
                        //console.log("res:");
                        //console.log(history());
                    };

                });
            
        },

  
  
showList = ko.observable(true);

   
    function QuesItem(data) {
        var self = this;
        console.log(data);
        self.Url = data.Url;
        self.CreationDate = data.CreationDate;
        self.Body = data.Body;
        self.Title = data.Title;


    };
    return {
      
        showContent: showContent,
        currentView: currentView,
       // currentViewId: currentViewId,
       // data: data,
       
        menuItems: menuItems,
       // isActive: isActive,
        showList: showList,
       
        questions: questions,
        GoToId: GoToId

    };
}());

navigationViewModel.showContent("questions");
ko.applyBindings(masterVM);



