(function () {

    const app = angular.module('pruebaTecnica');

    app.controller("VentaController", function ($scope, VentaService, ProductoService) {

        $scope.venta = {};
        $scope.listaVentas = [];
        $scope.producto = {};
        
        // Metodos de carga
        CargarVentas();

        function CargarVentas()
        {
            VentaService.obtenerVentas().then(function (e)
            {
                const lista = angular.fromJson(e.data);
                if (lista != null && lista.data.length > 0)
                {
                    $scope.listaVentas = lista.data;
                } else {
                    $scope.listaVentas = "No hay ninguna venta creada recientemente.";
                }
            });
        }

        $scope.crear = function (venta)
        {
            debugger;

            venta.productId = venta.id;
            delete venta.id;

            const resultado = VentaService.guardar(venta);
            resultado.then(success, error);

            function success(e) {

                const resultado = angular.fromJson(e.data);

                if (resultado) {
                    alert("Venta guardada exitosamente");
                    location.reload();
                }
            }

            function error(e) {
                alert("Error al guardar la venta");
            }
        };

        $scope.productoPorCodigo = function (code)
        {
            ProductoService.obtenerPorCodigo(code).then(function (e)
            {
                const producto = angular.fromJson(e.data);
                debugger;

                if(producto.data == null){
                    alert("no existe productos con ese codigo");
                }else{
                    $scope.producto = producto.data;
                }

            });
        }

    });


    app.service("VentaService", function ($http, $q) {

        this.obtenerVentas = function () {

            const response = $q.defer();

            const data = {};
            const config = {};

            $http.get('https://localhost:5001/api/sales', data, config).then(successCallback, errorCallback);

            function successCallback(e) {

                const resultado = {
                    error: false
                    , mensaje: ""
                    , data: e.data
                }

                response.resolve(resultado);
            };

            function errorCallback(e) {

                const resultado = {
                    error: true
                    , mensaje: ""
                    , data: e.data
                }

                response.reject(resultado);
            };

            return response.promise;
        }

        this.guardar = function (venta) {

            const response = $q.defer();

            const data = venta;
            const config = {};

            $http.post('https://localhost:5001/api/sales', data, config).then(successCallback, errorCallback);

            function successCallback(e) {

                const resultado = {
                    error: false
                    , mensaje: ""
                    , data: e.data
                }

                response.resolve(resultado);

            };

            function errorCallback(e) {

                const resultado = {
                    error: true
                    , mensaje: ""
                    , data: e.data
                }

                response.reject(resultado);

            };

            return response.promise;
        };

    });

})();

