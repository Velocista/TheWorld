//tripsController.js
(function () {

    "use strict";

    //This is referencing or getting the existing module 
    //This returns an object so we can add our controller
    angular.module("app-trips")
    .controller("tripsController", tripsController);

    function tripsController($http) {

        //this represents the object that is returned from the controller
        // the code is going to call  'new controller()', which will return a prototypical class
        // which is obtained through the 'this' pointer

        var vm = this;

        vm.trips = [];

        vm.newTrip = {};

        //Error member - non-functional data, will only show on the view if it exists
        vm.errorMessage = "";

        vm.isBusy = true;

        //$http is Angular service
        $http.get("/api/trips")
            .then(function (response) {
                // Success
                angular.copy(response.data, vm.trips);
            }, function (error)
            {
                // Failure
                vm.errorMessage = "Error loading data: " + error;
            })
        .finally(function () {
            vm.isBusy = false;
        });

        vm.addTrip = function () {

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/trips", vm.newTrip)
                .then(function (response) {
                    //Success
                    //This will add the returned added trip to the collection
                    vm.trips.push(response.data);
                    vm.newTrip = {};  //empty the newTrip form if successful
                }, function (error) {
                    //Error
                    vm.errorMessage = "Failed to save new trip: " + error;
                })
                .finally(function () {
                    vm.isBusy = false;
                });

        };

    }

})();