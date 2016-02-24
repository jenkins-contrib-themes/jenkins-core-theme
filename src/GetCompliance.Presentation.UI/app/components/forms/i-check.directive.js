(function() {
  'use strict';

  angular
    .module('app')
    .directive('iCheck', ICheck);

  ICheck.$inject = ['$timeout'];

  function ICheck($timeout) {
    return {
      require: 'ngModel',
      replace: true,
      template: '<input type="checkbox">',
      link: linker,
      restrict: 'EA'
    };

    function linker($scope, element, $attrs, ngModel) {
      return $timeout(function () {
        var value = $attrs.value;
        var $element = $(element);

        $element.iCheck({
          checkboxClass: 'icheckbox_flat-green',
          radioClass: 'iradio_flat-green'
        });

        $scope.$watch($attrs.ngModel, function (newValue) {
          $element.iCheck('update');
        });

        $element.on('ifChanged', function (event) {
          if ($element.attr('type') === 'radio' && $attrs.ngModel) {
            $scope.$apply(function () {
              ngModel.$setViewValue(value);
            });
          }
        });

      });
    }
  }

})();