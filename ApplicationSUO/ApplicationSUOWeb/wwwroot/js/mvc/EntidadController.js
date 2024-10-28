var app = angular.module('SUO', []);

app.service('RutService', function () {
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
});

app.controller('EntidadController', ['$scope', '$http', 'RutService', function ($scope, $http, RutService) {

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

    $scope.formatearRutInput = function () {
        var rut = $scope.rutEntidad || '';
        $scope.rutEntidad = RutService.formatearRut(rut);
    };

    $scope.cargarEntidades = function () {
        $http.get('/Entidad/ObtineneListadoEntidades')
            .then(function (response) {
                console.log(response.data);
                $scope.entidades = response.data;
            })
            .catch(function (error) {
                console.error('Error al cargar las entidades:', error);
            });
    };

    $scope.cargarEntidades();

    document.getElementById("home").style.display = "block";
    $scope.mostrarBuscaPaciente = true;
    $scope.mostrarAgregaUser = true;
    $scope.mostrarAgregaEntidad = true;
    $scope.mostrarLogin = true;
    document.getElementById("Logout").style.display = "block";    

    $scope.regiones = [];
    $scope.comunas = [];

    $scope.region = {
        idRegion: null,
    };

    $scope.comuna = {
        idComuna: null,
    };
    $scope.listComunas = false; 

    $scope.btnModificar = false;
    $scope.btnEliminar = false;
    $scope.tituloEntidades = false; 

    $scope.GetRegiones = function () {
        $http.get('/Entidad/ObtenerRegiones')
            .then(function (response) {
                if (response.data) {
                    if (response.data.length > 0) {
                        var defaultOption = { idRegion: -1, region: "--- SELECCIONA UNA REGIÓN ---" };
                        response.data.unshift(defaultOption);
                        $scope.regiones = response.data;
                        $scope.region.idRegion = defaultOption.idRegion;
                    } else {
                        alert("No se encontraron regiones.");
                    }
                } else {
                    alert("La respuesta no contiene datos válidos.");
                }
            }, function (error) {
                console.error("Error al obtener las regiones: ", error);
                alert("Ocurrió un error al intentar obtener las regiones. Intente nuevamente más tarde.");
            });
    };

    $scope.GetRegiones();
    $scope.GetComunas = function () {
        if ($scope.region.idRegion && $scope.region.idRegion !== -1) {
            $scope.listComunas = true;
            $http.get('/Entidad/ObtenerComunasPorRegiones?IDREGION=' + $scope.region.idRegion)
                .then(function (response) {
                    if (response.data) {
                        if (response.data.length > 0) {
                            var defaultOption = { idComuna: -1, comuna: "--- SELECCIONA UNA COMUNA ---" };
                            response.data.unshift(defaultOption);
                            $scope.comunas = response.data;
                            $scope.comuna.idComuna = defaultOption.idComuna;
                        } else {
                            alert("No se encontraron comunas para la región seleccionada.");
                        }
                    } else {
                        alert("La respuesta no contiene datos válidos.");
                    }
                }, function (error) {
                    console.error("Error al obtener las comunas: ", error);
                    alert("Ocurrió un error al intentar obtener las comunas. Intente nuevamente más tarde.");
                });
        } else {
            $scope.comunas = [];
            $scope.comuna.idComuna = null;
            alert("Por favor, selecciona una región válida.");
        }
    };

    
    $scope.tituloEntidades = '';   
    function procesarImagen(inputElement, callback) {
        var file = inputElement.files[0];
        if (file) {
            console.log("Tamaño original del archivo: " + file.size + " bytes");
           
            if (file.type.startsWith('image/')) {
                var reader = new FileReader();
                reader.onload = function (e) {
                   
                    console.log("Tamaño del base64: " + e.target.result.length + " caracteres");                   
                    $scope.$apply(function () {
                        callback(e.target.result);
                    });
                };
                reader.readAsDataURL(file);
            } else {
                alert("Por favor selecciona un archivo de imagen.");
            }
        }
    }

   

    document.getElementById('uploadButton1').addEventListener('click', function () {
        document.getElementById('fileInput1').click();
    });
    document.getElementById('fileInput1').addEventListener('change', function (event) {
        procesarImagen(event.target, function (base64) {
            $scope.imgEntidad1 = base64;
        });
    });

    document.getElementById('uploadButton2').addEventListener('click', function () {
        document.getElementById('fileInput2').click();
    });
    document.getElementById('fileInput2').addEventListener('change', function (event) {
        procesarImagen(event.target, function (base64) {
            $scope.imgEntidad2 = base64;
        });
    });
 
    document.getElementById('uploadButton3').addEventListener('click', function () {
        document.getElementById('fileInput3').click();
    });
    document.getElementById('fileInput3').addEventListener('change', function (event) {
        procesarImagen(event.target, function (base64) {
            $scope.imgEntidad3 = base64;
        });
    });

    $scope.agregarEntidad = function () {
        $scope.tituloEntidades = 'Agregar Nueva Entidad';
       
        var rutSinPuntos = $scope.rutEntidad.replace(/\./g, '');
        var dv = rutSinPuntos.slice(-1).trim();
        var rutCuerpo = rutSinPuntos.slice(0, -1);

        while (rutCuerpo.length < 7) {
            rutCuerpo = '0' + rutCuerpo;
        }

        dv = dv.replace(/\s/g, '');
        var rutFinal = rutCuerpo + dv;

        const formData = new FormData();
        formData.append('rutEntidad', rutFinal);
        formData.append('nombreEntidad', $scope.nombreEntidad);
        formData.append('direccionEntidad', $scope.direccionEntidad);
        formData.append('idRegion', $scope.region.idRegion);
        formData.append('idComuna', $scope.comuna.idComuna);
        formData.append('telefonoEntidad', $scope.telefonoEntidad);
        formData.append('contactoEntidad', $scope.contactoEntidad);
        formData.append('imgEntidad1', $scope.imgEntidad1);
        formData.append('imgEntidad2', $scope.imgEntidad2);
        formData.append('imgEntidad3', $scope.imgEntidad3);       
     
        $http.post('/Entidad/CrearNuevaEntidad', formData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined } 
        })
            .then(function (response) {
                if (response.status === 200) {
                    $('#modalAgregarEntidades').modal('hide');
                    Swal.fire({
                        title: "Se ha registrado entidad",
                        text: $scope.nombreEntidad + ' correctamente!',
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
                    Swal.fire({
                        title: "Error",
                        text: $scope.nombreEntidad + ' no se ha podido registrar!',
                        icon: "error"
                    });
                }
            })
            .catch(function (error) {
                Swal.fire({
                    title: "Error",
                    text: $scope.nombreEntidad + ' no se ha podido registrar!',
                    icon: "error"
                });
            });
    }; 


    document.getElementById('uploadButton4').addEventListener('click', function () {
        document.getElementById('fileInput4').click();
    });
    document.getElementById('fileInput4').addEventListener('change', function (event) {
        procesarImagen(event.target, function (base64) {
            $scope.ent.imgEntidad1 = base64;
        });
    });

    document.getElementById('uploadButton5').addEventListener('click', function () {
        document.getElementById('fileInput5').click();
    });
    document.getElementById('fileInput5').addEventListener('change', function (event) {
        procesarImagen(event.target, function (base64) {
            $scope.ent.imgEntidad2 = base64;
        });
    });

    document.getElementById('uploadButton6').addEventListener('click', function () {
        document.getElementById('fileInput6').click();
    });
    document.getElementById('fileInput6').addEventListener('change', function (event) {
        procesarImagen(event.target, function (base64) {
            $scope.ent.imgEntidad3 = base64;
        });
    });

    $scope.editarEntidad = function (idEntidad, rutEntidad) {
        $scope.tituloEntidades = 'Modificar o Eliminar Entidad';
        if (!idEntidad || !rutEntidad) {
            alert('ID o RUT no válidos.');
            return;
        }

        var rutSinPuntos = rutEntidad.replace(/\./g, '');
        var dv = rutSinPuntos.slice(-1).trim();
        var rutCuerpo = rutSinPuntos.slice(0, -1);

        while (rutCuerpo.length < 7) {
            rutCuerpo = '0' + rutCuerpo;
        }

        dv = dv.replace(/\s/g, '');
        var rutFinal = rutCuerpo + dv;


        $http.get('/Entidad/ObtienerEntidadByIdRut?ID=' + idEntidad + '&RUT=' + rutFinal)
            .then(function (response) {
                console.log("Respuesta de la API:", response.data);

                if (response.data && response.data.length > 0) {
                    var ent = response.data[0];                    
                    $scope.ent = {
                        idEntidad: ent.idEntidad,
                        rutEntidad: ent.rutEntidad,
                        nombreEntidad: ent.nombreEntidad,
                        direccionEntidad: ent.direccionEntidad,
                        regionEntidad: ent.regionEntidad,                           
                        comunaEntidad: ent.comunaEntidad,
                        telefonoEntidad: ent.telefonoEntidad,
                        contactoEntidad: ent.contactoEntidad,
                        imgEntidad1: 'data:image/png;base64,' + ent.imgEntidad1,
                        imgEntidad2: 'data:image/png;base64,' + ent.imgEntidad2,
                        imgEntidad3: 'data:image/png;base64,' + ent.imgEntidad3,                       
                        fechaModificacion: ent.fechaModificacion
                    };                   
                    
                } else {
                    alert('No se encontró entidad.');
                }
            })
            .catch(function (error) {
                console.error('Error al obtener entidad:', error);
                alert('Error al obtener entidad: ' + (error.data ? error.data.Message : 'Error desconocido'));
            });
    }; 

    $scope.modificarEntidad = function () {
                

        var rutSinPuntos = $scope.ent.rutEntidad.replace(/\./g, '');
        var dv = rutSinPuntos.slice(-1).trim();
        var rutCuerpo = rutSinPuntos.slice(0, -1);


        while (rutCuerpo.length < 7) {
            rutCuerpo = '0' + rutCuerpo;
        }
             
        dv = dv.replace(/\s/g, '');      

        var rutFinal = rutCuerpo + dv;      

        var updEntidadRequest = {

            IdEntidad: $scope.ent.idEntidad,
            RutEntidad: rutFinal,           
            TelefonoEntidad: $scope.ent.telefonoEntidad,
            ContactoEntidad: $scope.ent.contactoEntidad,
            imgEntidad1: $scope.ent.imgEntidad1,
            imgEntidad2: $scope.ent.imgEntidad2,
            imgEntidad3: $scope.ent.imgEntidad3
        };


        $http.put('/Entidad/ActualizaEntidad', updEntidadRequest)
            .then(function (response) {
                if (response.status === 200) {
                    Swal.fire({
                        title: "Entidad modificado exitosamente",
                        text: `${$scope.ent.nombreEntidad} ha sido actualizada correctamente!`,
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
                    Swal.fire({
                        title: "Error al modificar Entidad",
                        text: `${$scope.ent.nombreEntidad} no se pudo actualizar.`,
                        icon: "error",
                        confirmButtonText: "OK"
                    });
                }
            })
            .catch(function (error) {
                Swal.fire({
                    title: "Error al modificar entidad",
                    text: `Hubo un error al intentar actualizar entidad: ${error.message || 'Error desconocido'}`,
                    icon: "error",
                    confirmButtonText: "OK"
                });
            });
    };  

    $scope.btnModificar = function () {
        $scope.modificarEntidad();
    };

    $scope.logout = function () {
        sessionStorage.removeItem('LoginResponse');
        document.cookie.split(";").forEach(function (c) {
            document.cookie = c.trim().split("=")[0] + "=;expires=Thu, 01 Jan 1970 00:00:00 UTC;path=/;";
        });
        window.location.href = '/Home/Index';
    };

}]);
