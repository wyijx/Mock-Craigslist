namespace CraigslistMockUp {

    angular.module("CraigslistMockUp", ['ngRoute'])
        .config(function($routeProvider) {
            //$routeProvider.when('/', {
            // templateUrl: '/path/to/view',
            // controller: CraigslistMockUp.Controllers.ControllerClass,
            // controllerAs: 'views variable name for controller'
            //});
            $routeProvider.when('/', {
                template: 'Hello World!',
            })
            .when('/listings', {
                templateUrl: '/ngApp/views/listListings.html',
                controller: CraigslistMockUp.Controllers.ListOfListingsController,
                controllerAs: 'controller'
            });
        });
}