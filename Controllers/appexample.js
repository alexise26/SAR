var app = angular.module("app", []);

app.controller("regCtrl", function ($scope, $http, $filter) {
    //var emisora = (angular.element($('#ContentPlaceHolder1_ddlEmisora')).val());
    //$http.get('GetPases.asmx/get5Pases', { params: { "emisora": emisora } }).then(function (response) { $scope.pases = response.data; });
    //--$http.get('TestService.asmx/getPantallas').then(function (response) { $scope.pantallas = response.data; });
    $http.get('Services/getService.asmx/getCiclos').then(function (response) { $scope.ciclos = response.data; });
    $http.get('Services/getService.asmx/getEstados').then(function (response) { $scope.estados = response.data; });
    $http.get('Services/getService.asmx/getMunicipios').then(function (response) { $scope.municipios = response.data; });
    $http.get('Services/getService.asmx/getTipoSolicitud').then(function (response) { $scope.tipo_solicitud = response.data; });
    $http.get('Services/getService.asmx/getTipoAgricultura').then(function (response) { $scope.tipo_agricultura = response.data; });
    $http.get('Services/getService.asmx/getProductos').then(function (response) { $scope.productos = response.data; });
    //--$http.get('TestService.asmx/getCampos', { params: { "pantalla_id": $scope.pantalla_id } }).then(function (response) { $scope.campos = response.data; });
    //$scope.regiones = [{ "REGION_ID": 1.0, "REGION_NAME": "Europe" }, { "REGION_ID": 2.0, "REGION_NAME": "Americas" }, { "REGION_ID": 3.0, "REGION_NAME": "Asia" }, { "REGION_ID": 4.0, "REGION_NAME": "Middle East and Africa" }] ;
    //$scope.getPaseId = function (id) {

    //    var found = $filter('getById')($scope.regiones, id);
    //    $scope.paseid = found.REGION_NAME;
    //}

    $scope.estado = null;
    $scope.municipio = null;
    $scope.localidad = null;
    $scope.ciclo = null;
    $scope.tipoSoli = null;
    $scope.tipoAgri = null;
    $scope.producto = null;

    $scope.setLocalidad = function (mun_id) {
        $http.get('Services/getService.asmx/getLocalidades', { params: { "mun_id": mun_id } }).then(function (response) { $scope.localidades = response.data; });
    }

});

//app.filter('getById', function () {

//    return function (input, id) {
//        for (var i = 0; i < input.length; i++) {
//            if (+input[i].REGION_NAME == +id) {
//                return input[i];
//            }
//        }
//    };
//});