var masterViewModel = masterViewModel || (function () {
    this.navigationViewModel = navigationViewModel;
    this.searchViewModel = searchViewModel;
    this.loginViewModel = loginViewModel;
    this.validatorViewModel = validatorViewModel;
    //this.UserModel = UserModel;
    this.QuestionViewModel = QuestionViewModel;
})();
ko.applyBindings(masterViewModel);
$("#Users_menu").trigger('click');