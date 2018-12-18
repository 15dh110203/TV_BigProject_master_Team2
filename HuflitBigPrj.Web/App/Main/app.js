(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', '$qProvider',
        function ($stateProvider, $urlRouterProvider, $locationProvider, $qProvider) {
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('/');
            $qProvider.errorOnUnhandledRejections(false);

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in HuflitBigPrjNavigationProvider
                    });
                $urlRouterProvider.otherwise('/users');
            }

            if (abp.auth.hasPermission('Pages.Roles')) {
                $stateProvider
                    .state('roles', {
                        url: '/roles',
                        templateUrl: '/App/Main/views/roles/index.cshtml',
                        menu: 'Roles' //Matches to name of 'Tenants' menu in HuflitBigPrjNavigationProvider
                    });
                $urlRouterProvider.otherwise('/roles');
            }

            if (abp.auth.hasPermission('Pages.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in HuflitBigPrjNavigationProvider
                    });
                $urlRouterProvider.otherwise('/tenants');
            }

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in HuflitBigPrjNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in HuflitBigPrjNavigationProvider
                })
                .state('purchaseorder', {
                    url: '/purchaseorders',
                    template: '<purchaseorder-list></purchaseorder-list>',
                    menu: 'PurchaseOrders' //Matches to name of 'Author' menu in HuflitBigPrjNavigationProvider
                })
                .state('payment', {
                    url: '/payment',
                    template: '<payment-list></payment-list>',
                    menu: 'Payment' //Matches to name of 'SaleOrders' menu in HuflitBigPrjNavigationProvider
                })
                .state('customer', {
                    url: '/customer',
                    template: '<customer-list></customer-list>',
                    menu: 'Customer' //Matches to name of 'SaleOrders' menu in HuflitBigPrjNavigationProvider
                })
                .state('inventory', {
                    url: '/inventory',
                    template: '<inventory-list></inventory-list>',
                    menu: 'Inventory' //Matches to name of 'Author' menu in HuflitBigPrjNavigationProvider
                });


        }
    ]);

})();