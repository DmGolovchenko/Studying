var app = angular
    .module('defaultModule', [
    	'ngMaterial',
    	'LocalStorageModule'
    ]);

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);
