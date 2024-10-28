angular.module('SUO', [])
    .service('RutService', function () {
        this.validarRut = function (rut) {
            rut = rut.replace(/\s/g, '').replace(/[^0-9kK]/g, '');
            if (rut.length < 2) return false;

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

            return cuerpo.replace(/\B(?=(\d{3})+(?!\d))/g, '.') + '-' + dv.toUpperCase();
        };
    })

    .controller('LoginController', function ($scope, $http, RutService) {
        $scope.message = "";   




        $scope.login = function () {
            var rutSinFormato = $scope.RUT.replace(/\./g, '').replace(/-/g, '');
            var password = $scope.PASSWORD;

            if (!RutService.validarRut(rutSinFormato)) {
                $scope.message = 'El RUT ingresado no es válido.';
                showAlert();
                return;
            }

            if (!password) {
                $scope.message = 'La clave no puede estar vacía.';
                showAlert();
                return;
            }

            var dv = rutSinFormato.slice(-1);
            var rutSinDv = rutSinFormato.slice(0, -1);
            var rutFormateado = rutSinDv + '-' + dv;

            var requestData = {
                Usuario: rutFormateado,
                Password: password
            };

            $http.post('/Login/LoginUser', requestData)
                .then(function (response) {
                    console.log('Inicio de sesión exitoso:', response.data);
                    const userData = response.data;

                    sessionStorage.setItem('LoginResponse', JSON.stringify(userData));

                    asignarDatosUsuario(userData);    

                    window.location.href = 'Login/LoginUsuario';

                })
                .catch(function (error) {
                    console.error('Error al iniciar sesión:', error.data);
                });
        };

        function showAlert() {
            var alertElement = document.getElementById('alertInfo');
            alertElement.style.display = 'block';
            setTimeout(function () {
                alertElement.style.opacity = 1;
                var fadeEffect = setInterval(function () {
                    if (!alertElement.style.opacity) {
                        alertElement.style.opacity = 1;
                    }
                    if (alertElement.style.opacity > 0) {
                        alertElement.style.opacity -= 0.1;
                    } else {
                        clearInterval(fadeEffect);
                        alertElement.style.display = 'none';
                    }
                }, 300);
            }, 3000);
        }


        function asignarDatosUsuario(userData) {
            $scope.nombreCompleto = userData.nombreUsuario + ' ' + userData.apellidoPaterno + ' ' + userData.apellidoMaterno;
            $scope.correoUsuario = userData.correoUsuario;
            $scope.nombreEntidad = userData.nombreEntidad;
            $scope.rutEntidad = RutService.formatearRut(userData.rutEntidad);
            $scope.ultimaSession = userData.ultimaSession;
            $scope.idPerfil = userData.idPerfil;  

            if (userData.idEntidad > 0) {
                const idEntidad = userData.idEntidad;

                $scope.obtenerImages(idEntidad);
            } else {
                alert('No se encontró IdEntidad para el usuario.');
            }
        }
      

        $scope.obtenerImages = function (idEntidad) {
            if (!idEntidad) {
                alert('No se ha proporcionado IdEntidad.');
                return;
            }

            $http.get('/ListaImgCarrusel/obtenerImages?IdEntidad=' + idEntidad)
                .then(function (response) {
                    console.log("Respuesta de la API:", response.data);

                    if (response.data && response.data.length > 0) {
                        var img = response.data[0];
                        $scope.img = {
                            idEntidad: img.idEntidad,
                            imgEntidad1: 'data:image/png;base64,' + img.imgEntidad1,
                            imgEntidad2: 'data:image/png;base64,' + img.imgEntidad2,
                            imgEntidad3: 'data:image/png;base64,' + img.imgEntidad3
                        };
                    } else {
                        alert('No se encontró entidad.');
                    }
                })          

                .catch(function (error) {
                    console.error('Error al obtener imágenes:', error);
                    alert('Error al obtener imágenes. Por favor, intenta de nuevo.');
                });


        };

        $scope.$watch('idPerfil', function (tipoPerfil) {
            if (tipoPerfil !== undefined) {
                $scope.mostrarAgregaUser = tipoPerfil === 1;
                $scope.mostrarAgregaEntidad = tipoPerfil === 1;
                $scope.mostrarAgregaEnt = tipoPerfil === 1;
            }
        });

        $scope.obtenerDatosUsuario = function () {
            const userData = JSON.parse(sessionStorage.getItem('LoginResponse'));
            if (userData) {
                asignarDatosUsuario(userData);
                document.getElementById("Logout").style.display = "block";
                document.getElementById("home").style.display = "block";
                document.getElementById("agregaUsuario").style.display = "block";
            }
        };

        $scope.logout = function () {
            sessionStorage.removeItem('LoginResponse');
            document.cookie.split(";").forEach(function (c) {
                document.cookie = c.trim().split("=")[0] + "=;expires=Thu, 01 Jan 1970 00:00:00 UTC;path=/;";
            });
            window.location.href = '/Home/Index';
            document.getElementById("Logout").style.display = "none";
            document.getElementById("home").style.display = "none";
            document.getElementById("agregaUsuario").style.display = "none";
        };

        $scope.togglePassword = function () {
            var passwordField = document.getElementById("PASSWORD");
            passwordField.type = passwordField.type === "password" ? "text" : "password";
        };

        $scope.formatearRutInput = function () {
            var rut = $scope.RUT || '';
            $scope.RUT = RutService.formatearRut(rut);
        };

        $scope.obtenerDatosUsuario();
    });
