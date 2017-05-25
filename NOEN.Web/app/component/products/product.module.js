/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('noenshop.products', ['noenshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('products', {
            url: "/products",
            templateUrl: "/app/component/products/productListView.html",
            controller: "productListController"

        }).state('products_add', {
            url: "/products_add",
            templateUrl: "/app/component/products/productAddView.html",
            controller: "productAddController"

        }).state('products_edit', {
            url: "/products_edit/:id",
            templateUrl: "/app/component/products/productEditView.html",
            controller: "productEditController"

        }).state('product_import', {
            url: "/product_import",
            templateUrl: "/app/component/products/productImportView.html",
            controller: "productImportController"
        });
    }
})();