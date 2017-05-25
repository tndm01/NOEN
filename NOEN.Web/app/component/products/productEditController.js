(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', 'apiService', 'notificationService', 'commonService', '$stateParams', '$state'];

    function productEditController($scope, apiService, notificationService, commonService, $stateParams, $state) {
        $scope.products = {
            CreatedDate: new Date(),
            Status : true
        }
        $scope.flatFolders = [];
        $scope.UpdateProduct = UpdateProduct;

        function UpdateProduct() {
            apiService.put('/api/product/update', $scope.products,
                function (result) {
                    notificationService.displaySuccess('Cập nhật thành công ' + $scope.products.Name);
                    $state.go('products');
                }, function () {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function loadParentCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = commonService.getTree(result.data, "ID", "ParentID");
                $scope.parentCategories.forEach(function (item) {
                    recur(item, 0, $scope.flatFolders);
                });
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        function times(n, str) {
            var result = '';
            for (var i = 0; i < n; i++) {
                result += str;
            }
            return result;
        };
        function recur(item, level, arr) {
            arr.push({
                Name: times(level, '–') + ' ' + item.Name,
                ID: item.ID,
                Level: level,
                Indent: times(level, '–')
            });
            if (item.children) {
                item.children.forEach(function (item) {
                    recur(item, level + 1, arr);
                });
            }
        };

        function loadDetailProduct() {
            apiService.get('/api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.products = result.data;
            }, function () {
                notificationService.displayError('Không tải được sản phẩm!');
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.products.Image = fileUrl;
                });
            }
            finder.popup();
        }

        loadDetailProduct();
        loadParentCategory();

    }
})(angular.module('noenshop.products'));