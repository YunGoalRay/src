
(function () {
    appModule.controller('common.views.providers.index', [
        '$scope', '$uibModal', '$stateParams', 'uiGridConstants', 'abp.services.app.provider',
        function ($scope, $uibModal, $stateParams, uiGridConstants, providerService) {
            //$stateParams 获取的是浏览器后面跟的参数
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                //这里应该是当页面加载完毕后，进行信息的初始化
                //实际会去调用 icheck、select2等js的初始化插件。来渲染页面
                App.initAjax();
            });
            //告知页面信息已经下载完毕
            vm.loading = false;
            //默认是关闭高级按钮。我们这里用不到。参考
            //  vm.advancedFiltersAreShown = false;
            //获取传递的参数，判断模糊查询字段，是否为空
            vm.filterText = $stateParams.filterText || '';
            //获取Session中的userId
            //   vm.currentUserId = abp.session.userId;
            //制作权限组，进行页面权限的判断 
            vm.permissions = {
                create: abp.auth.hasPermission("Pages.Provider.CreateProvider"),
                edit: abp.auth.hasPermission("Pages.Provider.EditProvider"),
                'delete': abp.auth.hasPermission("Pages.Provider.DeleteProvider")
            };
            //请求参数，默认用于分页
            vm.requestParams = {
                permission: '',
                role: '',
                skipCount: 0,
                //这里是个常量文件，如果你没有找到这个常量文件，那么就手动改成10吧
                maxResultCount: app.consts.grid.defaultPageSize,
                sorting: null
            };

            //配置表格信息

            vm.providerGridOptions = {
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                //这里是个常量文件，如果你没有找到这个常量文件，那么就手动改成[10, 20, 50, 100]吧
                paginationPageSizes: app.consts.grid.defaultPageSizes,
                paginationPageSize: app.consts.grid.defaultPageSize,
                useExternalPagination: true,
                useExternalSorting: true,
                appScopeProvider: vm,
                rowTemplate: '<div ng-repeat="(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name" class="ui-grid-cell" ng-class="{ \'ui-grid-row-header-cell\': col.isRowHeader, \'text-muted\': !row.entity.isActive }"  ui-grid-cell></div>',

                columnDefs: [
                    {
                        //这里是在处理多语言本地化的问题，如果你这里报错。那么手动修改名字吧。
                        name: app.localize('Actions'),
                        enableSorting: false,
                        width: 120,
                        cellTemplate:
                        '<div class=\"ui-grid-cell-contents\">' +
                        '  <div class="btn-group dropdown" uib-dropdown="" dropdown-append-to-body>' + '    <button class="btn btn-xs btn-primary blue" uib-dropdown-toggle="" aria-haspopup="true" aria-expanded="false"><i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span></button>' +
                        '    <ul uib-dropdown-menu>' +
                        '      <li><a ng-if="grid.appScope.permissions.edit" ng-click="grid.appScope.editProvider(row.entity)">' + app.localize('Edit') + '</a></li>' +

                        '      <li><a ng-if="grid.appScope.permissions.delete" ng-click="grid.appScope.deleteProvider(row.entity)">' + app.localize('Delete') + '</a></li>' +
                        '    </ul>' +
                        '  </div>' +
                        '</div>'
                    },
                    //让我么开始循环字段吧。

                    //id不展示信息

                    {
                        name: app.localize('ProviderName'),
                        field: 'providerName',
                        //  enableSorting: false,
                        //cellFilter: 'momentFormat: \'L\'',
                        minWidth: 100
                    },
                    {
                        name: app.localize('ProviderId'),
                        field: 'providerId',
                        //  enableSorting: false,
                        //cellFilter: 'momentFormat: \'L\'',
                        minWidth: 100
                    },
                    {
                        name: app.localize('ShortName'),
                        field: 'shortName',
                        //  enableSorting: false,
                        //cellFilter: 'momentFormat: \'L\'',
                        minWidth: 100
                    },
                    {
                        name: app.localize('ProviderType'),
                        field: 'providerType',
                        //  enableSorting: false,
                        //cellFilter: 'momentFormat: \'L\'',
                        minWidth: 100
                    },
                    {
                        name: app.localize('Address'),
                        field: 'address',
                        //  enableSorting: false,
                        //cellFilter: 'momentFormat: \'L\'',
                        minWidth: 100
                    },
                    {
                        name: app.localize('BusinessPhone'),
                        field: 'businessPhone',
                        //  enableSorting: false,
                        //cellFilter: 'momentFormat: \'L\'',
                        minWidth: 100
                    },
                    {
                        name: app.localize('BusinessContact'),
                        field: 'businessContact',
                        //  enableSorting: false,
                        //cellFilter: 'momentFormat: \'L\'',
                        minWidth: 100
                    },
                    {
                        name: app.localize('Owner'),
                        field: 'owner',
                        //  enableSorting: false,
                        //cellFilter: 'momentFormat: \'L\'',
                        minWidth: 100
                    },],
                // ui-grid进行API注册渲染数据。
                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                    $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                        if (!sortColumns.length || !sortColumns[0].field) {
                            vm.requestParams.sorting = null;
                        } else {
                            vm.requestParams.sorting = sortColumns[0].field + ' ' + sortColumns[0].sort.direction;
                        }
                        vm.getPagedproviders();
                    });
                    //配置UI-grid的 API参数
                    gridApi.pagination.on.paginationChanged($scope, function (pageNumber, pageSize) {
                        vm.requestParams.skipCount = (pageNumber - 1) * pageSize;
                        vm.requestParams.maxResultCount = pageSize;
                        //执行查询语句
                        vm.getPagedproviders();
                    });
                },
                data: []
            };

            //声明查询方法
            vm.getPagedproviders = function () {
                vm.loading = true;
                providerService.getPagedProvidersAsync($.extend({ filter: vm.filterText }, vm.requestParams))
                    .then(function (result) {
                        vm.providerGridOptions.totalItems = result.data.totalCount;
                        //       console.log(result.data.items);                        
                        vm.providerGridOptions.data = result.data.items;
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            //删除方法
            vm.deleteProvider = function (provider) {
                abp.message.confirm(
                    app.localize('ProviderDeleteWarningMessage', provider.id),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            providerService.deleteProviderAsync({
                                id: provider.id
                            }).then(function () {
                                vm.getPagedproviders();
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                            });
                        }
                    }
                );
            };

            //导出为excel文档
            vm.exportToExcel = function () {
                providerService.getProviderToExcel({})
                    .then(function (result) {
                        app.downloadTempFile(result.data);
                    });
            };


            //编辑功能
            vm.editProvider = function (provider) {
                //     console.log(provider);
                openCreateOrEditProviderModal(provider.id);
            };
            //创建功能
            vm.createProvider = function () {
                openCreateOrEditProviderModal(null);
            };

            //打开模态框，进行创建或者编辑的功能操作
            function openCreateOrEditProviderModal(providerId) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/common/views/providers/createOrEditModal.cshtml',
                    controller: 'common.views.providers.createOrEditModal as vm',
                    backdrop: 'static',
                    resolve: {
                        providerId: function () {
                            return providerId;
                        }
                    }
                });

                modalInstance.result.then(function (result) {
                    vm.getPagedproviders();
                });
            }


            //执行查询方法
            vm.getPagedproviders();
        }
    ]);
})();