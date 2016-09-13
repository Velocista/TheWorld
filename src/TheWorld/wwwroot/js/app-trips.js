//app-trips.js
(function () {
    
    "use strict";

    //This defines the module because of the dependency parameter of type array []
    //thus this is creating the Module
    angular.module("app-trips", ["simpleControls", "ngRoute"])
        .config(function ($routeProvider) {
            
            $routeProvider.when("/", {
                controller: "tripsController",
                controllerAs: "vm",
                templateUrl: "/views/tripsView.html"
            });

            $routeProvider.when("/editor/:tripName", {
                controller: "tripEditorController",
                controllerAs: "vm",
                templateUrl: "/views/tripEditorView.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });

        });

})();
