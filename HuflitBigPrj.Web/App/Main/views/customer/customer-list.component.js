(function () {
    "use strict"
    var app = angular.module('app');
    app.component("customerList", {
        templateUrl: "~/App/Main/views/Customer/customer.cshtml",
        controllerAs: "vm",
        controller: [ 'abp.services.app.customer', Controller]
    });
    function Controller(customerService) {
        //debugger
        var vm = this;
        vm.customers = [];

        vm.customer = {
            custName : '',
            address : '',
            phone : '',
            email : '',
            status : '',
        };


        //get all customer
        function getCustomers() {
            customerService.listAll()
                .then(function (result) {
                    
                    vm.customers = result.data;
                });
        }
        getCustomers();

        vm.openModalforNew = function () {
            $('#myModal').modal('show');
            vm.showSubmit = true;
            vm.showEdit = false;
        }

        vm.save = function () {
            abp.ui.setBusy();
            customerService.create(vm.customer)
                .then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $('#myModal').modal('hide');
                }).finally(function () {
                    abp.ui.clearBusy();
                    getCustomers();
                });
        }
    }

        //get all user
        //function getUsers() {
        //    userService.getUsers({ Filter: "" })
        //        //.then(function (result) {
        //        //    vm.user = result.data;
        //        .done(function (result) {
        //            var users = result.items;
        //            console.log(users);
        //        });
        //}
        //function getUsers() {
        //    userService.getAll({}).then(function (result) {
        //        vm.users = result.data.items;
        //    });
        //}
        //getUsers();

        //function getUsers() {
        //    userService.getUsers()
        //        .then(function (result) {
        //            debugger
        //            vm.users = result.data;
        //        });
        //}
})();