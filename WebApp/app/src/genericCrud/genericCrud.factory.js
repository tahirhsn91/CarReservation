/**
 * @ngdoc overview
 * @name app.genericCrud.factory: genericCrudFactory
 * @description generic Crud factory for most modules.
 */

(function(){

  angular
    .module('app.auth')
    .factory('genericCrudFactory', genericCrudFactory);

  /* @ngInject */
  function genericCrudFactory(Restangular, lodash){

      return {
        getModuleName: getModuleName,
        getAll: getAll,
        getSingle: getSingle,
        save: save,
        remove: remove,
        checkString: checkString,
        getFieldName: getFieldName,
        fillChoices: fillChoices
      };

      function getModuleName(name){
        return name.replace(/([A-Z])/g, ' $1')
                .replace(/^./, function(str){ return str.toUpperCase(); })
      }

      function getAll(module){
        return Restangular.one(module).get();
      }

      function getSingle(module, id){
        return Restangular.one(module, id).get();
      }

      function save(module, data){
        if(data.Id){
          return Restangular.all(module).customPUT(data); 
        } else {
          return Restangular.all(module).post(data);
        }
      }

      function remove(module, id){
        return Restangular.all(module).remove(id);
      }

      function checkString(data){
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
            getAll(value.Field).then(function(res){
              choices[value.Field] = res;
            });
          }
        });
      }
    
  }

}());
