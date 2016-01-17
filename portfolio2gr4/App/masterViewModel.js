var masterViewModel = masterViewModel || (function () {
    this.navigationViewModel = navigationViewModel;
    this.searchViewModel = searchViewModel;
    this.loginViewModel = loginViewModel;
    this.validatorViewModel = validatorViewModel;
    //this.UserModel = UserModel;
    this.UserViewModel = UserViewModel;
    this.QuestionViewModel = QuestionViewModel;
    this.PaginationViewModel = PaginationViewModel;
})();
ko.applyBindings(masterViewModel);
$(document).ready(function () {
    QuestionModel.question_short_template = $("#questions_short").html;
    UserModel.user_short_template = $("#users_short").html;
    UserModel.userFull_template = $("#user_view").html;
});

