
$(document).ready(function () {

    CargarCategoria();

    CargarProveedores();

})



///Funcion que carga categorias

function CargarCategoria() {

    


        $.ajax(

            {

                type: "GET",

                url: '/Compra/ObtenerCategorias',

                data: { },

                contentType: "application/json; charset=utf-8",

                dataType: "json",

                cache: false,

                success: function (data) {



                    if (!data.success) {

                        alert("Se presento un error al cargar los datos");

                        return;

                    }


                    $("#categoria").empty();

                    var $select = $('#categoria');

                    $('<option>', {

                        value: ''

                    }).html('-- Seleccionar --').appendTo($select);

                    $.each(data.dato, function (i, item) {

                        $('<option>', {

                            value: item.Cod_Cat

                        }).html(item.Nom_Cat).appendTo($select);

                    });



                },


                error: function (msg) {



                    alert(msg.responseText);

                }

            });
}



//funcion que carga subcategorias por categoria

function CargarSubCategoria() {


    var codCategoria = $('#categoria').val();



    if (codCategoria != '') {

    $.ajax(

        {

            type: "GET",

            url: '/Compra/ObtenerSubCategorias',

            data: { codCategoria: codCategoria },


            contentType: "application/json; charset=utf-8",

            dataType: "json",

            cache: false,

            success: function (data) {



                if (!data.success) {

                    alert("Se presento un error al cargar los datos");

                    return;

                }


                $("#subcategoria").empty();

                var $select = $('#subcategoria');

                $('<option>', {

                    value: ''

                }).html('-- Seleccionar --').appendTo($select);

                $.each(data.dato, function (i, item) {

                    $('<option>', {

                        value: item.Cod_Scat

                    }).html(item.Nom_Sbcat).appendTo($select);

                });

            },


            error: function (msg) {



                alert(msg.responseText);

            }

        });
    }
}



//funcion que carga subcategorias por categoria

function CargarProductos() {


    var codSubCategoria = $('#subcategoria').val();


    if (codSubCategoria != '') {

        $.ajax(

            {

                type: "GET",

                url: '/Compra/ObtenerProductos',

                data: { codSubCategoria: codSubCategoria },

                contentType: "application/json; charset=utf-8",

                dataType: "json",

                cache: false,

                success: function (data) {



                    if (!data.success) {

                        alert("Se presento un error al cargar los datos");

                        return;

                    }


                    $("#producto").empty();

                    var $select = $('#producto');

                    $('<option>', {

                        value: ''

                    }).html('-- Seleccionar --').appendTo($select);

                    $.each(data.dato, function (i, item) {

                        $('<option>', {

                            value: item.Cod_Produc

                        }).html(item.Nombre_Produc).appendTo($select);

                    });

                },


                error: function (msg) {



                    alert(msg.responseText);

                }

            });
    }
}




///Funcion que carga categorias

function CargarProveedores() {




    $.ajax(

        {

            type: "GET",

            url: '/Compra/ObtenerProveedores',

            data: {},

            contentType: "application/json; charset=utf-8",

            dataType: "json",

            cache: false,

            success: function (data) {



                if (!data.success) {

                    alert("Se presento un error al cargar los datos");

                    return;

                }


                $("#Proveedor").empty();

                var $select = $('#Proveedor');

                $('<option>', {

                    value: ''

                }).html('-- Seleccionar --').appendTo($select);

                $.each(data.dato, function (i, item) {

                    $('<option>', {

                        value: item.Cod_Pers

                    }).html(item.NombreCompleto).appendTo($select);

                });


            },


            error: function (msg) {



                alert(msg.responseText);

            }

        });
}





// funcion para guardar una compra

function GuardarCompra() {





    var codCategoria = $('#categoria').val();
    var codsubcategoria = $('#subcategoria').val();
    var codproducto = $('#producto').val();
    var txtExistencias = $('#txtExistencias').val();
    var txtValorTotal = $('#txtValorTotal').val();

    if (codCategoria != "" && codsubcategoria != "" && codproducto != "" && txtExistencias != "" && txtValorTotal != "") {



        $.ajax(

            {

                type: "GET",

                url: '/Compra/GuardarCompra',

                data: { codproducto: codproducto, txtExistencias: txtExistencias, txtValorTotal: txtValorTotal},

                contentType: "application/json; charset=utf-8",

                dataType: "json",

                cache: false,

                success: function (data) {

                    if (!data.success) {

                        alert("Se presento un error al cargar los datos");

                        return;

                    }

                    LimpiarPantalla();

                    alert("Se creo con exito la compra");



                },



                error: function (msg) {



                    alert(msg.responseText);

                }

            });

    } else {

        alert("Debe ingresar los datos requeridos para hacer la compra");
        return;
    }      
}






function GuardarVenta() {


    var codCategoria = $('#categoria').val();
    var codsubcategoria = $('#subcategoria').val();
    var codproducto = $('#producto').val();
    var txtExistencias = $('#txtExistencias').val();
    var txtValorTotal = $('#txtValorTotal').val();

    if (codCategoria != "" && codsubcategoria != "" && codproducto != "" && txtExistencias != "" && txtValorTotal != "") {



        $.ajax(

            {

                type: "GET",

                url: '/Compra/GuardarVenta',

                data: { codproducto: codproducto, txtExistencias: txtExistencias, txtValorTotal: txtValorTotal },

                contentType: "application/json; charset=utf-8",

                dataType: "json",

                cache: false,

                success: function (data) {

                    if (!data.success) {

                        alert("No se encontraron existencias del producto o la cantidad a vender es mayor a las existencias.");

                        return;

                    }

                    LimpiarPantalla();

                    alert("Se creo con exito la venta");



                },



                error: function (msg) {



                    alert(msg.responseText);

                }

            });

    } else {

        alert("Debe ingresar los datos requeridos para hacer la venta");
        return;
    }
}



function GuardarDevolucion() {


    var codCategoria = $('#categoria').val();
    var codsubcategoria = $('#subcategoria').val();
    var codproducto = $('#producto').val();
    var txtExistencias = $('#txtExistencias').val();
    var txtValorTotal = $('#txtValorTotal').val();
    var txtDetalle = $('#txtDetalle').val();
    var codProveedor = $('#Proveedor').val();




    if (codCategoria != "" && codsubcategoria != "" && codproducto != "" && txtExistencias != "" && txtValorTotal != "" && txtDetalle != "" && codProveedor != "" ) {



        $.ajax(

            {

                type: "GET",

                url: '/Compra/GuardarDevolucion',

                data: { codproducto: codproducto, txtExistencias: txtExistencias, txtValorTotal: txtValorTotal, txtDetalle: txtDetalle, codProveedor: codProveedor },

                contentType: "application/json; charset=utf-8",

                dataType: "json",

                cache: false,

                success: function (data) {

                    if (!data.success) {

                        alert("No se encontraron existencias del producto o la cantidad a devolver es mayor a las existentes.");

                        return;

                    }

                    LimpiarPantalla();

                    alert("Se creo con exito la devolucion");
                    CargarProveedores();
                    $('#txtDetalle').val('');


                },



                error: function (msg) {



                    alert(msg.responseText);

                }

            });

    } else {

        alert("Debe ingresar los datos requeridos para hacer la devolucion");
        return;
    }
}







//Funcion para limpiar pantalla

function LimpiarPantalla() {



    $('#categoria').val('');
    $('#subcategoria').val('');
    $('#producto').val('');
    $('#txtExistencias').val('');
    $('#txtValorTotal').val('');


    CargarCategoria();
}

