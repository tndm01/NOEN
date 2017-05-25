/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('noenshop.product_categories', ['noenshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('product_categories', {
                url: "/product_categories",
                templateUrl: "/app/component/product_categories/productCategoryListView.html",
                controller: "productCategoryListController"

            }).state('product_categories_add', {
                url: "/product_categories_add",
                templateUrl: "/app/component/product_categories/productCategoryAddView.html",
                controller: "productCategoryAddController"

            }).state('product_categories_edit', {
                url: "/product_categories_edit/:id",
                templateUrl: "/app/component/product_categories/productCategoryEditView.html",
                controller: "productCategoryEditController"
            });
    }
})();