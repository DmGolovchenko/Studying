var app = angular
    .module('defaultModule', [
    	'LocalStorageModule',
        'ngMaterial'
    ]);

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);
