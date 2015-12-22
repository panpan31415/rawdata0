var masterViewModel = masterViewModel || (function () {
    this.navigationViewModel = navigationViewModel;
    this.searchViewModel = searchViewModel;
    this.loginViewModel = loginViewModel;
    this.validatorViewModel = validatorViewModel;
})();
ko.applyBindings(masterViewModel);