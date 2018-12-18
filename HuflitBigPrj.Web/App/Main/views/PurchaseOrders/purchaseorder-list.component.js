(function () {
    "use strict"
    var app = angular.module("app");
    app.component("purchaseorderList", {
        templateUrl: "~/App/Main/views/PurchaseOrders/purchaseorder.cshtml",
        controllerAs: "vm",
        controller: ['abp.services.app.purchase', Controller]
    })
    function Controller(purchaseorderService) {
       
        var vm = this;
        vm.purchases = [];
        vm.showSubmit = true;
        vm.showEdit = false;
        vm.purchase = {
            orderDate: '',
            orderType: '',
            overdueDate: '',
            discAmt: '',
            promAmt: '',
            comAmt: '',
            taxtAmt: '',
            totalAmt: '',
            isDeleted: '',           
            creationTime: '',
            id: ''
        }

        //get all purchase order form database
        function getPurchaseOrders() {
            purchaseorderService.listAll()
                .then(function (result) {
                    vm.purchases = result.data;
                });
        }
        getPurchaseOrders();

        //open model to create
        vm.openModalForNew = function () {
            $('#myModal').modal('show');
            vm.showSubmit = true;
            vm.showEdit = false;

            var date = new Date();
            vm.purchase.orderDate = '';
            vm.purchase.orderType = '';
            vm.purchase.overdueDate= '';
            vm.purchase.discAmt= '1';
            vm.purchase.promAmt= '1';
            vm.purchase.comAmt= '1';
            vm.purchase.taxtAmt= '1';
            vm.purchase.totalAmt= '1';
            vm.purchase.isDeleted = 'False';
            vm.purchase.creationTime = date.getFullYear() + '-' + ('0' + (date.getMonth() + 1)).slice(-2) + '-' + ('0' + date.getDate()).slice(-2);
        }

        //open model to update 
        vm.openModalForUpdate = function (data) {
            $('#myModal').modal('show');
            vm.purchase.orderDate = data.orderDate;
            vm.purchase.orderType = data.orderType;
            vm.purchase.overdueDate = data.overdueDate;
            vm.purchase.discAmt = data.discAmt;
            vm.purchase.promAmt = data.promAmt;
            vm.purchase.comAmt = data.comAmt;
            vm.purchase.taxtAmt = data.taxtAmt;
            vm.purchase.totalAmt = data.totalAmt;
            vm.purchase.isDeleted = data.isDeleted;
            vm.purchase.creationTime = data.creationTime;
            vm.showSubmit = false;
            vm.showEdit = true;
            vm.entity = data;
        }

        //save data 
        vm.save = function () {
            abp.ui.setBusy();
            purchaseorderService.create(vm.purchase)
                .then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function () {
                    abp.ui.clearBusy();
                    getPurchaseOrders();
                });
        }
        //update
        vm.edit = function (data) {
            debugger
            var x = {};
            x = vm.entity;
            x.OrderDate = data.purchase.orderDate;
            x.OrderType = data.purchase.orderType;
            x.OverdueDate = data.purchase.overdueDate;
            x.DiscAmt = data.purchase.discAmt;
            x.PromAmt =data.purchase.promAmt;
            x.ComAmt =data.purchase.comAmt;
            x.TaxtAmt =data.purchase.taxtAmt;
            x.TotalAmt =data.purchase.totalAmt;
            x.IsDeleted = data.purchase.isDeleted;
            x.CreationTime = data.purchase.creationTime;
            abp.ui.setBusy();
            purchaseorderService.update(x)
                .then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function () {
                    abp.ui.clearBusy();
                    getPurchaseOrders();
                });
        }

        //delete 
        vm.delete = function (orderNo) {
            debugger
            var x = { orderNo };
            abp.ui.setBusy();
            purchaseorderService.delete(x)
                .then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function () {
                    abp.ui.clearBusy();
                    getPurchaseOrders();
                });
        }
    }
})();


