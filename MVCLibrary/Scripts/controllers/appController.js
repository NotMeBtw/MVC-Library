var app = angular.module('mvcLibrary', []);

app.controller('booksController', function ($scope) {
    $scope.editmode = 0;

    $scope.setEditMode = function (id) {
        $scope.editmode = id;
    };
    $scope.cancel = function () {
        $scope.editmode = 0;
    };
    $scope.submit = function () {
        console.log('Submit');
    };
});

app.controller('categoriesController', function ($scope) {
    $scope.editmode = '';

    $scope.setEditMode = function (name) {
        $scope.editmode = name;
    };
    $scope.cancel = function () {
        $scope.editmode = '';
    };
    $scope.submit = function () {
        console.log('Submit');
    };
});