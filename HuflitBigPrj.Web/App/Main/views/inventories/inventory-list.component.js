(function () {
    "use strict"
    var app = angular.module("app");
    app.component("inventoryList", {
        templateUrl: "~/App/Main/views/Inventories/inventory.cshtml",
        controllerAs: "vm",
        controller: ['abp.services.app.inventory', Controller]
    })
    function Controller(inventoryService) {
        var vm = this;
        vm.inventories = [];
        vm.showSubmit = true;
        vm.showEdit = false;
        vm.inventory = {
            invtName: '',
            qtyStock: '',
        }

        //get all inventories order form database
        function getInventories() {
            inventoryService.listAll()
                .then(function (result) {
                    vm.inventories = result.data;
                });
        }
        getInventories();

        //open model to create
        vm.openModalForNew = function () {
            $('#myModal').modal('show');
            vm.showSubmit = true;
            vm.showEdit = false;
            vm.inventory.invtName = '';
            vm.inventory.qtyStock = '';
        }
        //open model to update 
        vm.openModalForUpdate = function (data) {
            $('#myModal').modal('show');
            vm.inventory.invtName = data.invtName;
            vm.inventory.qtyStock = data.qtyStock;
            vm.showSubmit = false;
            vm.showEdit = true;
            vm.entity = data;
        }

        //save data 
        vm.save = function () {
            debugger
            abp.ui.setBusy();
            inventoryService.create(vm.inventory)
                .then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function () {
                    abp.ui.clearBusy();
                    getInventories();
                });
        }
        //update
        vm.edit = function (data) {
            debugger
            var x = {};
            x = vm.entity;
            x.InvtName = data.inventory.invtName;
            x.QtyStock = data.inventory.qtyStock;
            abp.ui.setBusy();
            inventoryService.update(x)
                .then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function () {
                    abp.ui.clearBusy();
                    getInventories();
                });
        }

        //delete 
        vm.delete = function (invtID) {
            debugger
            var x = { invtID };
            abp.ui.setBusy();
            inventoryService.delete(x)
                .then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function () {
                    abp.ui.clearBusy();
                    getInventories();
                });
        }
    }
})();