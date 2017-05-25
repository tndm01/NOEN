(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService']

    function productAddController($scope, apiService, notificationService, $state, commonService) {
        $scope.products = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.flatFolders = [];
        $scope.ckeditorOoptions = {
            language: 'vi',
            height: '200px'
        }

        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.products.Alias = commonService.getSeoTitle($scope.products.Name);
        }

        $scope.AddProduct = AddProduct;

        function AddProduct() {
            apiService.post('/api/product/create', $scope.products,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
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

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.products.Image = fileUrl;
                });
            }
            finder.popup();
        }

        loadParentCategory();
    }

})(angular.module('noenshop.products'));