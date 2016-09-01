//tripsController.js
(function () {

    "use strict";

    //This is referencing or getting the existing module 
    //This returns an object so we can add our controller
    angular.module("app-trips")
    .controller("tripsController", tripsController);

    function tripsController() {

        //this represents the object that is returned from the controller
        // the code is going to call  'new controller()', which will return a prototypical class
        // which is obtained through the 'this' pointer

        var vm = this;

        vm.trips = [{
            name: "US Trip",
            created: new Date()
        }, {
            name: "World Trip",
            created: new Date()
        }];

        vm.newTrip = {} ;

        vm.addTrip = function () {
            alert(vm.newTrip.name);
        }

    }

})();