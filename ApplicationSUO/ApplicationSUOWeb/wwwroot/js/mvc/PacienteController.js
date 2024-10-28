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

            const rutFormateado = cuerpo.replace(/\B(?=(\d{3})+(?!\d))/g, '.') + '-' + dv.toUpperCase();

            return rutFormateado;
        };
    })
    .controller('PacienteController', ['$scope', '$http', 'RutService', function ($scope, $http, RutService) {
    
        $scope.pacientes = [];
       
        function obtenerDatosSesion() {
           
            const userDataString = sessionStorage.getItem('LoginResponse');

            if (userDataString) {
                try {
                    const userData = JSON.parse(userDataString);
                    
                    if (userData && userData.nombreUsuario && userData.apellidoPaterno && userData.apellidoMaterno && userData.idPerfil) {
                        $scope.nombreCompleto = userData.nombreUsuario + ' ' + userData.apellidoPaterno + ' ' + userData.apellidoMaterno;
                        $scope.idPerfil = userData.idPerfil;
                        console.log('Nombre completo:', $scope.nombreCompleto);
                        console.log('ID Perfil:', $scope.idPerfil);
                    } else {
                        console.error('Faltan datos de sesión, no se pudo crear nombreCompleto o idPerfil.');
                    }
                } catch (error) {
                    console.error('Error al parsear userDataString:', error);
                }
            } else {
                console.error('No se encontraron datos de sesión en sessionStorage.');
            }
        }

        obtenerDatosSesion();

        document.getElementById("Logout").style.display = "block";
        document.getElementById("home").style.display = "block";
        document.getElementById("agregaUsuario").style.display = "block";

        $scope.mostrarBotonRut = false; 
        $scope.mostrarTdRut = false;  
        $scope.mostrarAgregaUser = false;
        $scope.mostrarAgregaEnt = false;
        $scope.mostrarAgregaEntidad = false;

        $scope.$watch('idPerfil', function (tipoPerfil) {
            if (tipoPerfil !== undefined) {
                if (tipoPerfil === 3) {
                    $scope.mostrarBotonRut = false;
                    $scope.mostrarTdRut = true;
                } else if (tipoPerfil === 1 || tipoPerfil === 2) {
                    $scope.mostrarBotonRut = true;
                    $scope.mostrarTdRut = false;
                } else {
                   
                    $scope.mostrarBotonRut = false;
                    $scope.mostrarTdRut = false;
                }
            }
        });
        $scope.$watch('idPerfil', function (tipoPerfil) {
            if (tipoPerfil !== undefined) {
                if (tipoPerfil === 3 || tipoPerfil === 2) {
                    $scope.mostrarAgregaUser = false; 
                    $scope.mostrarAgregaEntidad = false;
                } else if (tipoPerfil === 1) {
                    $scope.mostrarAgregaUser = true;
                    $scope.mostrarAgregaEntidad = true;
                } else {

                    $scope.mostrarAgregaUser = false;
                    $scope.mostrarAgregaEntidad = false;
                    
                }
            }
        });
        $scope.$watch('idPerfil', function (tipoPerfil) {
            if (tipoPerfil !== undefined) {
                if (tipoPerfil === 3 || tipoPerfil === 2) {
                    $scope.mostrarAgregaEnt = false;
                } else if (tipoPerfil === 1) {
                    $scope.mostrarAgregaEnt = true;
                } else {

                    $scope.mostrarAgregaEnt = false;

                }
            }
        });
                
        $scope.buscarPaciente = function () {
            var rut = $scope.search;
            var rutSinPuntos = rut.replace(/\./g, '').trim();
            $scope.muestraRut = document.getElementById('search').value;           

            console.log('Buscando paciente con RUT:', rutSinPuntos);

            $http.get('/BuscarPaciente/BuscarPaciente?RUT=' + rutSinPuntos)
            

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
                    Swal.fire({
                        title: "No se encontraron registros!",
                        text: 'Para el RUT: ' + $scope.muestraRut,
                        icon: "info"
                    });
                });

            $scope.search = '';
        };

        $scope.formatearRutInput = function () {
            var rut = $scope.search || '';
            $scope.search = RutService.formatearRut(rut);
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

        $scope.llenarModalFicha = function (idAtenciones, rut) {
            if (!idAtenciones || !rut) {
                alert('ID o RUT no válidos.');
                return;
            }

            $http.get('/BuscarPaciente/FichaPacienteByIdRut?ID=' + idAtenciones + '&RUT=' + rut)
                .then(function (response) {
                    console.log("Respuesta de la API:", response.data); 

                    if (response.data) {
                        var ficha = response.data;

                        $scope.ficha = {
                            id: ficha.id,
                            rutPaciente: ficha.rutPaciente,
                            nombresPaciente: ficha.nombresPaciente,
                            apellidoPaterno: ficha.apellidoPaterno,
                            apellidoMaterno: ficha.apellidoMaterno,
                            direccionPaciente: ficha.direccionPaciente,
                            comunaPaciente: ficha.comunaPaciente,
                            regionPaciente: ficha.regionPaciente,
                            rutEntidad: ficha.rutEntidad,
                            nombreEntidad: ficha.nombreEntidad,
                            direccionEntidad: ficha.direccionEntidad,
                            comunaEntidad: ficha.comunaEntidad,
                            regionEntidad: ficha.regionEntidad,
                            horaAtencion: ficha.horaAtencion,
                            fechaAtencion: ficha.fechaAtencion,
                            fechaAlta: ficha.fechaAlta,
                            estado: ficha.estado,
                            diagnostico: ficha.diagnostico
                        };
                        
                    } else {
                        alert('No se encontró la ficha del paciente.');
                    }
                })
                .catch(function (error) {
                    console.error('Error al obtener la ficha del paciente:', error);
                    alert('Error al obtener la ficha del paciente: ' + (error.data ? error.data.Message : 'Error desconocido'));
                });
        };
       
        $scope.GeneraPDF = async function (id, rut) {         
            if (!id || !rut) {
                alert("Por favor, ingrese un ID y un RUT válidos.");
                return;
            }

            try {
              
                const fichaResponse = await $http.get(`/BuscarPaciente/FichaPacienteByIdRut?ID=${id}&RUT=${rut}`);
                console.log("Respuesta de la API:", fichaResponse.data);

                if (fichaResponse.data) {
                    const ficha = fichaResponse.data;
                  
                    const pdfData = {
                        
                        rutPaciente: ficha.rutPaciente,
                        nombresPaciente: ficha.nombresPaciente,
                        apellidoPaterno: ficha.apellidoPaterno,
                        apellidoMaterno: ficha.apellidoMaterno,
                        direccionPaciente: ficha.direccionPaciente,
                        comunaPaciente: ficha.comunaPaciente,
                        regionPaciente: ficha.regionPaciente,
                        rutEntidad: ficha.rutEntidad,
                        nombreEntidad: ficha.nombreEntidad,
                        direccionEntidad: ficha.direccionEntidad,
                        comunaEntidad: ficha.comunaEntidad,
                        regionEntidad: ficha.regionEntidad,
                        horaAtencion: ficha.horaAtencion,
                        fechaAtencion: ficha.fechaAtencion,
                        fechaAlta: ficha.fechaAlta,
                        estado: ficha.estado,
                        diagnostico: ficha.diagnostico
                    };
                    
                    const pdfResponse = await $http.post('/GeneraFichaPDF/GeneraPDF', pdfData, {
                        responseType: 'arraybuffer' 
                    });
                   
                    const blob = new Blob([pdfResponse.data], { type: 'application/pdf' });
                    const urlBlob = URL.createObjectURL(blob);

                    const a = document.createElement('a');
                    a.href = urlBlob;
                    a.download = 'Ficha_' + ficha.rutPaciente +'.pdf';
                    document.body.appendChild(a);
                    a.click();
                    document.body.removeChild(a);
                    URL.revokeObjectURL(urlBlob);

                    Swal.fire({
                        title: "Buen trabajo!",
                        text: 'Ficha para el paciente: ' + ficha.nombresPaciente + ' ' + ficha.apellidoPaterno + ' ' + ficha.apellidoMaterno + ', generada correctamente!',
                        icon: "success",
                        confirmButtonText: "OK"
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $scope.$applyAsync(function () {
                                window.location.reload();
                            });
                        }
                    });
                } else {
                    alert('No se encontró la ficha del paciente.');
                }
            } catch (error) {
                console.error("Error al generar el PDF:", error);
                alert("Ocurrió un error al generar el PDF. Inténtelo de nuevo.");
            }
        };



    }]);
