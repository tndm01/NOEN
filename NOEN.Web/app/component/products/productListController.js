(function (app) {
    app.controller('productListController', productListController);

    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter']

    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.products = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;
        $scope.getProducts = getProducts;
        $scope.selectAll = selectAll;
        $scope.deleteMultiple = deleteMultiple;
        $scope.deleteProduct = deleteProduct;
        $scope.exportExcel = exportExcel;

        $scope.exportPdf = exportPdf;

        function exportPdf(productId) {
            var config = {
                params: {
                    id: productId
                }
            }
            apiService.get('/api/product/ExportPdf', config, function (response) {
                if (response.status = 200) {
                    window.location.href = response.data.Message;
                }
            }, function (error) {
                notificationService.displayError(error);

            });
        }

        function exportExcel() {
            var config = {
                params: {
                    filter: $scope.keyword
                }
            }
            apiService.get('/api/product/ExportXls', config, function (result) {
                if (result.status = 200) {
                    window.location.href = result.data.Message;
                }
            }, function () {
                notificationService.displayError('Xuất Excel không thành công!');
            });
        }

        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn có muốn xóa không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/product/delete', config, function (result) {
                    $scope.products = result.data.Name;
                    notificationService.displaySuccess('Xóa thành công ' + $scope.products);
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                });
            });
        }

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    listId : JSON.stringify(listId)
                }
            }
            apiService.del('/api/product/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                search();
            }, function () {
                notificationService.displayError('Xóa không thành công!');
            });
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("products", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function search() {
            getProducts();
        }

        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 10,
                    keyword: $scope.keyword
                }
            }
            apiService.get('/api/product/getall', config, function (result) {
                $scope.products = result.data.Items,
                $scope.page = result.data.Pages,
                $scope.pagesCount = result.data.TotalPages,
                $scope.totalCount = result.data.TotalCount
            }, function () {
                notificationService.displayError('Tải danh sách sản phẩm không thành công!');
            });
        }

        $scope.getProducts();
    }
})(angular.module('noenshop.products'));