 
  


// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-06-20T11:53:18. All Rights Reserved.
//<生成时间>2017-06-20T11:53:18</生成时间>

 (function () {
    appModule.controller('common.views.providers.createOrEditModal', [
         '$scope', '$uibModalInstance', 'abp.services.app.provider', 'providerId',
        function ($scope, $uibModalInstance, providerService, providerId) {
            var vm = this;
            vm.saving = false;
            //首先将provider数据设置为null
            vm.provider = null;

             

            //触发保存方法
            vm.save = function () {
                vm.saving = true;
                providerService.createOrUpdateProviderAsync({ providerEditDto:vm.provider }).then(function() {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function() {
                    vm.saving = false;
                });


            };
            //取消关闭页面
            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };

            //初始化页面
            function init() {
             //   console.log(providerId);
                providerService.getProviderForEditAsync({
                    id: providerId
                }).then(function (result) {
              //      console.log(result);
                    //console.log(result.data);
                    vm.provider = result.data.provider;
					
																																																																																														 
				 

                });
            }
            //执行初始化方法
            init();
        }
    ]);
})();