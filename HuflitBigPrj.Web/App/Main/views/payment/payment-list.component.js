(function () {
    "use strict"
    var app = angular.module('app');
    app.component("paymentList", {
        templateUrl: "~/App/Main/views/Payment/payment.cshtml",
        controllerAs: "vm",
        controller: ['abp.services.app.payment', 'abp.services.app.customer', 'abp.services.app.user', Controller]
    });
    function Controller(paymentService, customerService, userService) {
        var vm = this;
        vm.payments = [];
        vm.payment = {
            paymentNo: '',
            paymentDate: '',
            custID: '',
            userID: '',
            paymentAmt: ''
        };
        //vm.users = [];
        vm.showSubmit = true;
        vm.showEdit = false;

        //get all payments
        function getPayment() {
            paymentService.listAll()
                .then(function (result) {
                    vm.payments = result.data;
                });
        }
        getPayment();

        //get all customer
        function getCustomers() {
            customerService.listAll()
                .then(function (result) {
                    vm.customer = result.data;
                });
        }
        getCustomers();

//}

        function getUsers() {
            userService.getAll({}).then(function (result) {
                vm.users = result.data.items;
            });
        }

        getUsers();



        //open modal to add new payment
        vm.openModalforNew = function () {
            $('#myModal').modal('show');
            vm.showSubmit = true;
            vm.showEdit = false;
        }

        //open modal to update payment
        vm.openModalforUpdate = function (data) {
            $('#myModal').modal('show');
            vm.showSubmit = false;
            vm.showEdit = true;
            vm.entity = data;
            vm.payment.paymentNo = data.paymentNo;
            vm.payment.paymentDate = data.paymentDate;
            vm.payment.custID = data.custID.toString();
            vm.payment.userID = data.userID.toString();
            vm.payment.paymentAmt = data.paymentAmt;
        }

        //save data
        vm.save = function () {
            abp.ui.setBusy();
            paymentService.create(vm.payment)
                .then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $('#myModal').modal('hide');
                }).finally(function () {
                    abp.ui.clearBusy();
                    getPayment();
                    vm.payment.paymentNo = '';
                    vm.payment.paymentDate = '';
                    vm.payment.custID = '';
                    vm.payment.userID = '';
                    vm.payment.paymentAmt = '';
                });
        }

        //update data
        vm.edit = function (data) {
            var x = {};
            x = vm.entity;
            x.paymentNo = data.payment.paymentNo;
            x.paymentDate = data.payment.paymentDate;
            x.custID = parseInt(data.payment.custID);
            x.userID = parseInt(data.payment.userID);
            x.paymentAmt = parseInt(data.payment.paymentAmt);
            debugger
            abp.ui.setBusy();
            paymentService.update(x)
                .then(function () {
                    abp.notify.info(App.localize('Savedsuccessfully'));
                    $('#myModal').modal('hide');
                }).finally(function () {
                    abp.ui.clearBusy();
                    getPayment();
                });
        }
        //delete data
        vm.delete = function (paymentID) {
            var x = { paymentID };
            abp.ui.setBusy();
            paymentService.delete(x)
                .then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function () {
                    abp.ui.clearBusy();
                    getPayment();
                });
        }
        getPayment();
    }
})();