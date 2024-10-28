angular.module('SUO', []) 
    .service('RutService', function () {
        this.validarRut = function (rut) {
            
            rut = rut.replace(/\s/g, '').replace(/[^0-9kK]/g, '');
       
            if (rut.length < 8) return false;

            const cuerpo = rut.slice(0, -1);
            const dv = rut.slice(-1).toLowerCase(); 

            
            let suma = 0;
            let multiplo = 2;

            for (let i = cuerpo.length - 1; i >= 0; i--) {
                suma += multiplo * cuerpo.charAt(i);
                multiplo = (multiplo === 7) ? 2 : multiplo + 1;
            }

            const dvCalculado = 11 - (suma % 11);
            const dvFinal = dvCalculado === 10 ? 'k' : (dvCalculado === 11 ? '0' : dvCalculado.toString());

            return dv === dvFinal;
        };

        this.formatearRut = function (rut) {
           
            rut = rut.replace(/[^0-9kK]/g, '');
            
            if (rut.length < 2) return rut;

            const cuerpo = rut.slice(0, -1); 
            const dv = rut.slice(-1);       
            const rutFormateado = cuerpo.replace(/\B(?=(\d{3})+(?!\d))/g, '.') + '-' + dv.toUpperCase();

            return rutFormateado;
        };
    })
    .controller('LoginController', function ($scope, $http, RutService) {
        $scope.login = function () {
            
            var rut = $scope.RUT;
            var password = $scope.PASSWORD;

            if (!RutService.validarRut(rut)) {
                alert('El RUT ingresado no es válido.');
                return;
            }

           
            rut = rut.replace(/\./g, '').replace(/\s/g, ''); 
            rut = RutService.formatearRut(rut); 

            var requestData = {
                Usuario: rut,
                Password: password
            };

            $http.post('/Login/LoginUser', requestData)
                .then(function (response) {
                    console.log('Inicio de sesión exitoso:', response.data);
                    sessionStorage.setItem('userSession', JSON.stringify(response.data));
                    window.location.href = '/Home';
                })
                .catch(function (error) {
                    console.error('Error al iniciar sesión:', error.data);
                    alert(error.data.Message || 'Error en el inicio de sesión.');
                });;
        };

       
        $scope.togglePassword = function () {
            var passwordField = document.getElementById("PASSWORD");
            if (passwordField.type === "password") {
                passwordField.type = "text";
            } else {
                passwordField.type = "password";
            }
        };
    })
    .controller('PacienteController', ['$scope', '$http', 'RutService', function ($scope, $http, RutService) {
        document.getElementById("Logout").style.display = "block";
        document.getElementById("home").style.display = "block";
        document.getElementById("agregaUsuario").style.display = "block";
        
        $scope.pacientes = [];
        
        $scope.buscarPaciente = function () {
            var rut = $scope.search.replace(/\./g, '').replace(/\s/g, ''); 

            $http.get('/BuscarPaciente/BuscarPaciente?RUT=' + rut)
                .then(function (response) {
                    
                    if (response.data && Array.isArray(response.data) && response.data.length > 0) {
                        $scope.pacientes = response.data;
                    } else if (response.data && response.data.rut) {                        
                        $scope.pacientes = [response.data];
                    } else {
                       
                        alert(response.data.Message || 'No se encontraron pacientes.');
                    }
                })
                .catch(function (error) {
                    console.error('Error al buscar el paciente:', error);
                });
            
            $scope.search = '';
        };        
        $scope.formatearRutInput = function () {
            var rut = $scope.search || '';
            $scope.search = RutService.formatearRut(rut);
        };
    }]);
