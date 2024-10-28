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

app.controller('PerfilUsuarioController', ['$scope', '$http', 'RutService', function ($scope, $http, RutService) {
    $scope.tiposPerfil = [];
    $scope.estadosPerfil = [];

    document.getElementById("home").style.display = "block";  
    $scope.mostrarBuscaPaciente = true;
    $scope.mostrarAgregaUser = true;  
    $scope.mostrarAgregaEntidad = true;
    $scope.mostrarLogin = true;
    document.getElementById("Logout").style.display = "block";    
    

    $scope.perfil = {
        idTiposPerfiles: null,
    };

    $scope.estado = {
        idEstadoPerfil: null,
    };

    $scope.listRut = false;   

    $scope.cargarUsuarios = function () {
        $http.get('/PerfilUsuario/ObtineneListadoUsuarios')
            .then(function (response) {
                console.log(response.data); 
                $scope.perfiles = response.data;
            })
            .catch(function (error) {
                console.error('Error al cargar los usuarios:', error);
            });
    };
    
    $scope.cargarUsuarios();   
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

    $scope.tituloAgregar = "Agregar Nuevo Usuario";  


    $scope.tiposPerfil = [];  
    $scope.GetTiposPerfil = function () {
        $http.get('/PerfilUsuario/ObtenerListaTipoPerfil')
            .then(function (response) {
                if (response.data && response.data.length > 0) {
                    var defaultOption = { idPerfil: -1, descripcionPerfil: "--- SELECCIONA UN TIPO DE PERFIL ---" };
                    response.data.unshift(defaultOption);
                    $scope.tiposPerfil = response.data;
                    $scope.perfil = {
                        idTiposPerfiles: defaultOption.idPerfil,
                        descripcionPerfil: defaultOption
                    };
                } else {
                    alert("No se encontraron perfiles.");
                }
            }, function (error) {
                console.error("Error al obtener los perfiles: ", error);
            });
    };


    $scope.estadosPerfil = [];

    $scope.GetEstadosPerfil = function () {
        $http.get('/PerfilUsuario/ObtenerListaEstadoPerfil')
            .then(function (response) {
                if (response.data && response.data.length > 0) {
                    var defaultOption = { idEstado: -1, descripcionEstado: "--- SELECCIONA UN ESTADO DE PERFIL ---" };
                    response.data.unshift(defaultOption);
                    $scope.estadosPerfil = response.data;
                    $scope.estado = {
                        idEstadoPerfil: defaultOption.idEstado,
                        descripcionEstado: defaultOption
                    };
                } else {
                    alert("No se encontraron estados de perfil.");
                }
            }, function (error) {
                console.error("Error al obtener los estados de perfil: ", error);
            });
    };


    $scope.entidades = [];
    $scope.rutEntidad = [];
    $scope.nombreEntidad = { idEntidad: null };
    $scope.rutEntidad = { rutEntidad: null };
    $scope.listComunas = false;

    $scope.GetEntidades = function () {
        if (!$scope.nombreEntidad) {
            $scope.nombreEntidad = { idEntidad: -1, nombreEntidad: "--- SELECCIONA UNA ENTIDAD ---" };
        }

        $http.get('/PerfilUsuario/ListaEntidades')
            .then(function (response) {
                if (response.data && response.data.length > 0) {
                    var defaultOption = { idEntidad: -1, nombreEntidad: "--- SELECCIONA UNA ENTIDAD ---" };
                    response.data.unshift(defaultOption);
                    $scope.entidades = response.data;
                    $scope.nombreEntidad = defaultOption;
                } else {
                    alert("No se encontraron entidades.");
                }
            }, function (error) {
                console.error("Error al obtener las entidades: ", error);
                alert("Ocurrió un error al intentar obtener las entidades. Intente nuevamente más tarde.");
            });
    };
    //$scope.GetEntidades = function () {
    //    $http.get('/PerfilUsuario/ListaEntidades')
    //        .then(function (response) {
    //            if (response.data && response.data.length > 0) {
    //                $scope.entidades = response.data;
                   
    //                if ($scope.nombreEntidad && $scope.nombreEntidad.idEntidad) {
    //                    $scope.nombreEntidad = response.data.find(entity => entity.idEntidad === $scope.nombreEntidad.idEntidad) || null;
    //                } else {
    //                    $scope.nombreEntidad = null;
    //                }
    //            } else {
    //                alert("No se encontraron entidades.");
    //                $scope.entidades = [];
    //            }
    //        }, function (error) {
    //            console.error("Error al obtener las entidades: ", error);
    //            alert("Ocurrió un error al intentar obtener las entidades. Intente nuevamente más tarde.");
    //        });
    //};


    $scope.GetRut = function () {
        if ($scope.nombreEntidad.idEntidad && $scope.nombreEntidad.idEntidad !== null) {
            $scope.listRut = true;
            $http.get('/PerfilUsuario/ListaRutPorNombre?IdEntidad=' + $scope.nombreEntidad.idEntidad)
                .then(function (response) {
                    if (response.data && response.data.length > 0) {                       
                        $scope.rut = response.data;
                        if ($scope.rut.length > 0) {
                            $scope.rutEntidad = $scope.rut[0].rutEntidad;
                        } else {
                            $scope.rutEntidad = null;
                        }
                    } else {
                        $scope.rutEntidad = null;
                        alert("No se encontraron RUT para la entidad seleccionada.");
                    }
                }, function (error) {
                    console.error("Error al obtener los RUT: ", error);
                    alert("Ocurrió un error al intentar obtener el RUT. Intente nuevamente más tarde.");
                });
        } else {
            $scope.rut = [];
            $scope.rutEntidad = null;
            alert("Por favor, selecciona una entidad válida.");
        }
    };


    $scope.GetTiposPerfil();
    $scope.GetEstadosPerfil();   
    $scope.GetEntidades();
    
    $scope.validarPassword = function () {
        if ($scope.password && $scope.confirmaPass) {
            $scope.passwordsCoinciden = ($scope.password === $scope.confirmaPass);
        } else {
            $scope.passwordsCoinciden = true;
        }
    };
    $scope.agregarUsuario = function () {

        $scope.validarPassword();

        if (!$scope.passwordsCoinciden) {
            alert("Las contraseñas no coinciden. Por favor verifica.");
            return;
        }

        var rutSinPuntos = $scope.rutUsuario.replace(/\./g, '');         
        var dv = rutSinPuntos.slice(-1).trim();
        var rutCuerpo = rutSinPuntos.slice(0, -1); 

        var rutEnSinPuntos = $scope.rutEntidad.replace(/\./g, ''); 
        var dvEnt = rutEnSinPuntos.slice(-1).trim();
        var rutEnCuerpo = rutEnSinPuntos.slice(0, -1); 

       
        while (rutCuerpo.length < 7) {
            rutCuerpo = '0' + rutCuerpo;
        }

        while (rutEnCuerpo.length < 7) {
            rutEnCuerpo = '0' + rutEnCuerpo;
        }

        dv = dv.replace(/\s/g, '');

        dvEnt = dvEnt.replace(/\s/g, '');

        var rutFinal = rutCuerpo + dv;
        var rutFinalEnt = rutEnCuerpo + dvEnt;

        var addPerfilUsuarioRequest = {
            RutUsuario: rutFinal,
            NombreUsuario: $scope.nombre,
            ApellidoPaterno: $scope.apPaterno,
            ApellidoMaterno: $scope.apMaterno,
            CorreoUsuario: $scope.correoUsuario,
            RutEntidad: rutFinalEnt,
            IdEntidad: $scope.nombreEntidad.idEntidad,
            Password: $scope.password,
            IdPerfil: $scope.perfil.idTiposPerfiles,
            IdEstado: $scope.estado.idEstadoPerfil,
        };

        $http.post('/PerfilUsuario/CrearPerfilUsuario', addPerfilUsuarioRequest)
            .then(function (response) {
                if (response.status === 200) {
                    $('#modalPerfilUsuario').modal('hide');
                    Swal.fire({
                        title: "Se ha registrado usuario(a)",
                        text: $scope.nombre + ' ' + $scope.apPaterno + ' ' + $scope.apMaterno + ' ' + 'correctamente!',
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
                    alert("Error al agregar usuario: " + (response.data.Message || "Mensaje no disponible"));
                }
            })
            .catch(function (error) {
                alert("Error al agregar usuario: " + (error.data && error.data.Message) || (error.message || "Mensaje no disponible"));
            });
    };

    $scope.modificarUsuario = function (idLogin, rutUsuario) {
        if (!idLogin || !rutUsuario) {
            alert('ID o RUT no válidos.');
            return;
        }

        var rutSinPuntos = rutUsuario.replace(/\./g, '');
        var dv = rutSinPuntos.slice(-1).trim();
        var rutCuerpo = rutSinPuntos.slice(0, -1);

        while (rutCuerpo.length < 7) {
            rutCuerpo = '0' + rutCuerpo;
        }

        dv = dv.replace(/\s/g, '');
        var rutFinal = rutCuerpo + dv;
       

        $http.get('/PerfilUsuario/ObtienePerfilUsuarioIdRut?ID=' + idLogin + '&RUT=' + rutFinal)
            .then(function (response) {
                console.log("Respuesta de la API:", response.data); 

                if (response.data && response.data.length > 0) {
                    var user = response.data[0];                    

                    $scope.user = {
                         idLogin: user.idLogin,
                         idUsuario: user.idUsuario,
                         rutUsuario: user.rutUsuario,
                         nombreUsuario: user.nombreUsuario,
                         apellidoPaterno: user.apellidoPaterno,
                         apellidoMaterno: user.apellidoMaterno,
                         correoUsuario: user.correoUsuario,
                         IdEntidad: user.idEntidad,
                         rutEntidad: user.rutEntidad,                         
                         descripcionEstado: user.idEstado,
                         idPerfil: user.descripcionPerfil,
                         fechaRegistro: user.fechaRegistro,
                         fechaModificacion: user.fechaModificacion

                    };
                   
                } else {
                    alert('No se encontró el usuario.');
                }
            })
            .catch(function (error) {
                console.error('Error al obtener el usuario:', error);
                alert('Error al obtener el usuario: ' + (error.data ? error.data.Message : 'Error desconocido'));
            });
    };  

    $scope.modificarPerfilUsuario = function () {

        var rutSinPuntos = $scope.user.rutUsuario.replace(/\./g, '');
        var dv = rutSinPuntos.slice(-1).trim();
        var rutCuerpo = rutSinPuntos.slice(0, -1);

        var rutEnSinPuntos = $scope.rutEntidad.replace(/\./g, '');
        var dvEnt = rutEnSinPuntos.slice(-1).trim();
        var rutEnCuerpo = rutEnSinPuntos.slice(0, -1);


        while (rutCuerpo.length < 7) {
            rutCuerpo = '0' + rutCuerpo;
        }

        while (rutEnCuerpo.length < 7) {
            rutEnCuerpo = '0' + rutEnCuerpo;
        }

        dv = dv.replace(/\s/g, '');

        dvEnt = dvEnt.replace(/\s/g, '');

        var rutFinal = rutCuerpo + dv;
        var rutFinalEnt = rutEnCuerpo + dvEnt;
       
        var updPerfilUsuarioRequest = {

            IdLogin: $scope.user.idLogin,
            RutUsuario: rutFinal,
            CorreoUsuario: $scope.user.correoUsuario,
            RutEntidad: rutFinalEnt,
            IdEntidad: $scope.nombreEntidad.idEntidad,
            IdPerfil: $scope.idPerfil,
            IdEstado: $scope.user.descripcionEstado
        };

        
        $http.put('/PerfilUsuario/UpdateUsuario', updPerfilUsuarioRequest)
            .then(function (response) {
                if (response.status === 200) {
                    Swal.fire({
                        title: "Usuario modificado exitosamente",
                        text: `${$scope.user.nombreUsuario} ${$scope.user.apellidoPaterno} ${$scope.user.apellidoMaterno} ha sido actualizado correctamente.`,
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
                        title: "Error al modificar el usuario",
                        text: `${$scope.user.nombreUsuario} ${$scope.user.apellidoPaterno} ${$scope.user.apellidoMaterno} no se pudo actualizar.`,
                        icon: "error",
                        confirmButtonText: "OK"
                    });
                }
            })
            .catch(function (error) {
                Swal.fire({
                    title: "Error al modificar el usuario",
                    text: `Hubo un error al intentar actualizar el usuario: ${error.message || 'Error desconocido'}`,
                    icon: "error",
                    confirmButtonText: "OK"
                });
            });
    };    

    $scope.eliminarPerfilUsuario = function () {

        var rutSinPuntos = $scope.user.rutUsuario.replace(/\./g, '');
        var dv = rutSinPuntos.slice(-1).trim();
        var rutCuerpo = rutSinPuntos.slice(0, -1);


        while (rutCuerpo.length < 7) {
            rutCuerpo = '0' + rutCuerpo;
        }

        dv = dv.replace(/\s/g, '');

        var rutFinal = rutCuerpo + dv;

        const deletePerfilUsuarioRequest = {
            idLogin: $scope.user.idLogin,
            rutUsuario: rutFinal,
            
        };

        $http.delete('/PerfilUsuario/DeleteUsuario', {
            data: deletePerfilUsuarioRequest,
            headers: { 'Content-Type': 'application/json' }
        })
            .then(function (response) {
                if (response.status === 200) {
                    Swal.fire({
                        title: "Usuario eliminado exitosamente",
                        text: `El usuario ${$scope.user.nombreUsuario} ${$scope.user.apellidoPaterno} ${$scope.user.apellidoMaterno} ha sido eliminado correctamente.`,
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
                        title: "Error al eliminar el usuario",
                        text: `El usuario ${$scope.user.nombreUsuario} ${$scope.user.apellidoPaterno} ${$scope.user.apellidoMaterno} no se pudo eliminar.`,
                        icon: "error",
                        confirmButtonText: "OK"
                    });
                }
            })
            .catch(function (error) {
                Swal.fire({
                    title: "Error al eliminar el usuario",
                    text: `Hubo un error al intentar eliminar el usuario: ${error.message || 'Error desconocido'}`,
                    icon: "error",
                    confirmButtonText: "OK"
                });
            });
    };  
      

    $scope.formatearRutInput = function () {
        var rut = $scope.rutUsuario || '';
        $scope.rutUsuario = RutService.formatearRut(rut);
    };

  
    $scope.submitForm = function () {
        $scope.agregarUsuario();
    };

    $scope.btnModificar = function () {
        $scope.modificarPerfilUsuario();
    };

    $scope.btnEliminar = function () {
        $scope.eliminarPerfilUsuario();
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
}]);
