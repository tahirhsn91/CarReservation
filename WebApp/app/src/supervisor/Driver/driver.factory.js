/**
 * @ngdoc overview
 * @name app.genericCrud.factory: packageFactory
 * @description generic Crud factory for most modules.
 */

(function(){

  angular
    .module('app.driver')
    .factory('driverFactory', driverFactory);

  /* @ngInject */
  function driverFactory(Restangular, lodash, store, appModules, $state){

      return {
        getModuleName: getModuleName,
        getAll: getAll,
        getSingle: getSingle,
        save: save,
        remove: remove,
        checkString: checkString,
        getFieldName: getFieldName,
        fillChoices: fillChoices,
        redirect: redirect,
        checkDriver: checkDriver
      };

      function getModuleName(name){
        return name.replace(/([A-Z])/g, ' $1')
                .replace(/^./, function(str){ return str.toUpperCase(); });
      }

      function getAll(module, param){
        var url = module;
        if(param){
          url += param;
        }
        return Restangular.one(url).get();
      }

      function getSingle(module, id){
        return Restangular.one(module, id).get();
      }

      function save(module, data){
        if(data.Id){
          return Restangular.all('Driver').customPUT(data);
        } else {
          data.UserId = '12345';
          return Restangular.all(module).post(data);
        }
      }

      function remove(module, id){
        return Restangular.all(module).remove(id);
      }

      function checkString(data) {
          if (typeof data === 'string' || data instanceof String){
            return true;
          }
          else{
            return false;
          }
      }

      function getFieldName(obj){
        return obj.Field;
      }

      function fillChoices(obj, choices) {
        lodash.forEach(obj, function(value){
          if(!checkString(value)){
            if(value.Type ==='DropDown' || value.Type ==='MultiDropDown' || value.Type ==='Ignore'){
              getAll(value.Field).then(function(res){
                choices[value.Field] = res;
              });
            }
          }
        });
      }

      function redirect(url, obj){
        $state.go(url, obj);
      }

      function checkDriver(driver) {
          var obj = {
              Email: driver.User.Email
          }
          return Restangular.all('Supervisor/CheckDriver/').post(obj);
      }
  }
}());
