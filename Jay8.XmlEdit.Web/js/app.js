'use strict';


// Declare app level module which depends on filters, and services
var crtConfig = angular.module('crtConfig', [
  'ngRoute',
  'angularFileUpload',
  'crtConfig.filters',
  'crtConfig.directives'
]).
config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/uploadNewXml', {templateUrl: 'partials/XmlUpload.html'});
  $routeProvider.when('/editSchema', {templateUrl: 'partials/Schema.html'});
  $routeProvider.otherwise({ redirectTo: '/uploadNewXml' });
}]);
