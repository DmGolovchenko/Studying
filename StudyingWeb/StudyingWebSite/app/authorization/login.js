angular
    .module('defaultModule')
    .controller('loginController', loginController);

loginController.$inject = 
    ['$scope', 'authService'];

function loginController($scope, authService) {
    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {

        },
         function (err) {
             $scope.message = err.error_description;
         });
    };

    $scope.logout = function(){
        authService.logOut();
    }

};