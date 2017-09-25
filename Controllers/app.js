var app = angular.module("app", []);
//---------------------------------------------Controller for Beneficiarios-------------------------------------------
app.controller("benCtrl", function ($scope, $http, $filter) {
    $scope.reiniciar = function () {
        $scope.requerido = false;
        $scope.estado = null;
        $scope.municipio = null;
        $scope.localidad = null;
        $scope.ngCurp = null;
        $scope.ngUpp = "";
        $scope.ngPaterno = null;
        $scope.ngMaterno = "";
        $scope.ngNombre = null;
        $scope.ngCivil = "0";
        $scope.ngDomicilio = null;
        $scope.ngOcupacion = "";
        $scope.ngTel = "";
        $scope.ngObs = "";
        $scope.ngfnac = null;
        $scope.ngGenero = "0";
    }
    $scope.reiniciar();
    $http.get('../Services/getService.asmx/getEstados').then(function (response) { $scope.estados = response.data; });
    $http.get('../Services/getService.asmx/getMunicipios').then(function (response) { $scope.municipios = response.data; });
    $http.get('../Services/getService.asmx/getProductos').then(function (response) { $scope.productos = response.data; });

    $scope.setLocalidad = function (mun_id) {
        $http.get('../Services/getService.asmx/getLocalidades', { params: { "mun_id": mun_id } }).then(function (response) { $scope.localidades = response.data; });
    }

    $scope.insertBeneficiario = function () {
        if ($scope.ngfnac != null) {
            var today = $filter('date')($scope.ngfnac, 'yyyy-MM-dd');
        }        
        $http.get('../Services/postService.asmx/postBeneficiario', {
            params: {
                'curp': $scope.ngCurp, 'upp': $scope.ngUpp, 'municipio': $scope.municipio.CVE_MPIO, 'localidad': $scope.localidad.CVE_LOCALIDAD, 'paterno': $scope.ngPaterno, 'materno': $scope.ngMaterno,
                'nombre': $scope.ngNombre, 'genero': $scope.ngGenero, 'fecha_nac': today, 'edo_nac': $scope.estado.ID_ESTADO, 'domicilio': $scope.ngDomicilio, 'edo_civil': $scope.ngCivil,
                'ocupacion': $scope.ngOcupacion, 'telefono': $scope.ngTel, 'capturo': '1', 'observacion': $scope.ngObs
            }
        }).then(function onSuccess(response) { $scope.value = response.data; alertify.success($scope.value); })
          .catch(function onError(response) { $scope.value = response.data; alertify.error('Ha ocurrido un error'); console.log($scope.value); $scope.requerido = true; });
    }

});
//---------------------------------------------Controller for Ciclos-------------------------------------------
app.controller("cicCtrl", function ($scope, $http, $filter) {
    $http.get('../Services/getService.asmx/getCiclos').then(function (response) { $scope.ciclos = response.data; });

    $scope.ciclo = null;


});

//---------------------------------------------Controller for Productos-------------------------------------------
app.controller("prdCtrl", function ($scope, $http, $filter) {
    $http.get('../Services/getService.asmx/getCiclos').then(function (response) { $scope.ciclos = response.data; });
    $http.get('../Services/getService.asmx/getProductos').then(function (response) { $scope.productos = response.data; });


    $scope.ciclo = null;
    $scope.producto = null;


});
//---------------------------------------------Controller for Solicitud Agrícola-------------------------------------------
app.controller("solagCtrl", function ($scope, $http, $filter) {
    $http.get('../Services/getService.asmx/getCiclos').then(function (response) { $scope.ciclos = response.data; });
    $http.get('../Services/getService.asmx/getTipoSolicitud').then(function (response) { $scope.tipo_solicitud = response.data; });
    $http.get('../Services/getService.asmx/getTipoAgricultura').then(function (response) { $scope.tipo_agricultura = response.data; });
    $http.get('../Services/getService.asmx/getProductos').then(function (response) { $scope.productos = response.data; });
    $http.get('../Services/getService.asmx/getBeneficiarios').then(function (response) { $scope.beneficiarios = response.data; });

    $scope.ciclo = null;
    $scope.tipoSoli = null;
    $scope.tipoAgri = null;
    $scope.producto = null;
    $scope.beneficiario = null;

    $scope.getBeneficiario = function (id_benef) {
        console.log("paso");
        var found = $filter('getById')($scope.beneficiarios, id_benef);
        $scope.benNombre = found.NOMBRE;
        $scope.benCurp = found.CURP;
        $scope.benMun = found.MUNICIPIO;
        $scope.benLoc = found.LOCALIDAD;
    }


});
//---------------------------------------------getById FILTER-------------------------------------------

app.filter('getById', function () {
    return function (input, id) {
        var i = 0, len = input.length;
        for (; i < len; i++) {
            if (+input[i].BENEFICIARIO_ID == +id) {
                return input[i];
            }
        }
        return null;
    }
});

//---------------------------------------------tel FILTER-------------------------------------------
app.filter('tel', function () {
    return function (tel) {
        if (!tel) { return ''; }

        var value = tel.toString().trim().replace(/^\+/, '');

        if (value.match(/[^0-9]/)) {
            return tel;
        }

        var country, city, number;

        switch (value.length) {
            case 1:
            case 2:
            case 3:
                city = value;
                break;

            default:
                city = value.slice(0, 3);
                number = value.slice(3);
        }

        if (number) {
            if (number.length > 3) {
                number = number.slice(0, 3) + '-' + number.slice(3, 7);
            }
            else {
                number = number;
            }

            return ("(" + city + ") " + number).trim();
        }
        else {
            return "(" + city;
        }

    };
});