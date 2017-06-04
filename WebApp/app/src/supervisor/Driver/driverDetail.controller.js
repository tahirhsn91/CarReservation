/**
 * @ngdoc controller
 * @name app.genericCrud.controller:GenericDetailCtrl
 * @description Generic Detail Controller
 */

(function(){

  'use strict';

  angular.module('app.supervisor')
    .controller('DriverDetailCtrl', DriverDetailCtrl);

  /* @ngInject */
  function DriverDetailCtrl($stateParams, $state, store, driverFactory, appModules, toast, appFormats, lodash){
    var vm = this;

    vm.currentUser = store.get('user');
    vm.module = 'Driver';
    vm.recordId = $stateParams.id;
    vm.pageTitle = driverFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.currentUser.Role][vm.module];
    vm.appFormats = appFormats;

    vm.deleteRecord = deleteRecord;
  
    function init() {
      driverFactory.getSingle(vm.module, vm.recordId).then(function(result){
        vm.data = result;
      });
      driverFactory.getDriverLocation(vm.recordId).then(function (result) {
          var myLatLng = {lat: result.Location.Latitude, lng: result.Location.Longitude};
          var mapOptions = {
              zoom: 14,
              center: new google.maps.LatLng(result.Location.Latitude, result.Location.Longitude),
              mapTypeId: google.maps.MapTypeId.ROADMAP,
              disableDefaultUI: true,
              draggable: false,
              scrollwheel: false
          };
          vm.geocoder = new google.maps.Geocoder();
          vm.map = new google.maps.Map(document.getElementById('map_canvas'), mapOptions);

          var marker = new google.maps.Marker({
              position: myLatLng,
              map: vm.map,
              title: 'Driver Location'
          });
      });
    }

    vm.redirect = redirect;

    init();

    function deleteRecord(){
      driverFactory.remove(vm.module, vm.recordId).then(function(){
        toast.success(vm.module + 'module record ' + vm.data.Name + ' deleted successfully');
        redirect('genericCrud.genericCrudList', {'moduleName': vm.module});
      });
    }

    function redirect(url, obj){
      driverFactory.redirect(url, obj);
    }

  }

}());
