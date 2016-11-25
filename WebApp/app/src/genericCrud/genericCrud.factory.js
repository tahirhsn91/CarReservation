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
  function genericCrudFactory(Restangular){

      return {
        getModuleName: getModuleName,
        getAll: getAll,
        getSingle: getSingle,
        save: save,
        remove: remove
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
          return Restangular.all(module).put(data); 
        } else {
          return Restangular.all(module).post(data);
        }
      }

      function remove(module, id){
        return Restangular.one(module, id).remove();
      }
    
  }

}());
