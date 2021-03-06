﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sualiado.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SualiadoEntities : DbContext
    {
        public SualiadoEntities()
            : base("name=SualiadoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<kardex> kardex { get; set; }
        public virtual DbSet<movimientos> movimientos { get; set; }
        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<subcategoria> subcategoria { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int SP_Kr_Agregar(Nullable<int> cod_Pers_Fk, Nullable<int> cod_Mov_Fk, Nullable<int> cod_Produc_Fk, Nullable<int> dcto, Nullable<int> cantidad, Nullable<int> costo, Nullable<System.DateTime> fecha, string detalle)
        {
            var cod_Pers_FkParameter = cod_Pers_Fk.HasValue ?
                new ObjectParameter("Cod_Pers_Fk", cod_Pers_Fk) :
                new ObjectParameter("Cod_Pers_Fk", typeof(int));
    
            var cod_Mov_FkParameter = cod_Mov_Fk.HasValue ?
                new ObjectParameter("Cod_Mov_Fk", cod_Mov_Fk) :
                new ObjectParameter("Cod_Mov_Fk", typeof(int));
    
            var cod_Produc_FkParameter = cod_Produc_Fk.HasValue ?
                new ObjectParameter("Cod_Produc_Fk", cod_Produc_Fk) :
                new ObjectParameter("Cod_Produc_Fk", typeof(int));
    
            var dctoParameter = dcto.HasValue ?
                new ObjectParameter("Dcto", dcto) :
                new ObjectParameter("Dcto", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var detalleParameter = detalle != null ?
                new ObjectParameter("Detalle", detalle) :
                new ObjectParameter("Detalle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Kr_Agregar", cod_Pers_FkParameter, cod_Mov_FkParameter, cod_Produc_FkParameter, dctoParameter, cantidadParameter, costoParameter, fechaParameter, detalleParameter);
        }
    
        public virtual int SP_Kr_Editar(Nullable<int> cod_Pers_Fk, Nullable<int> cod_Mov_Fk, Nullable<int> cod_Produc_Fk, Nullable<int> dcto, Nullable<int> cantidad, Nullable<int> costo, Nullable<System.DateTime> fecha, Nullable<int> consecut)
        {
            var cod_Pers_FkParameter = cod_Pers_Fk.HasValue ?
                new ObjectParameter("Cod_Pers_Fk", cod_Pers_Fk) :
                new ObjectParameter("Cod_Pers_Fk", typeof(int));
    
            var cod_Mov_FkParameter = cod_Mov_Fk.HasValue ?
                new ObjectParameter("Cod_Mov_Fk", cod_Mov_Fk) :
                new ObjectParameter("Cod_Mov_Fk", typeof(int));
    
            var cod_Produc_FkParameter = cod_Produc_Fk.HasValue ?
                new ObjectParameter("Cod_Produc_Fk", cod_Produc_Fk) :
                new ObjectParameter("Cod_Produc_Fk", typeof(int));
    
            var dctoParameter = dcto.HasValue ?
                new ObjectParameter("Dcto", dcto) :
                new ObjectParameter("Dcto", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var consecutParameter = consecut.HasValue ?
                new ObjectParameter("Consecut", consecut) :
                new ObjectParameter("Consecut", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Kr_Editar", cod_Pers_FkParameter, cod_Mov_FkParameter, cod_Produc_FkParameter, dctoParameter, cantidadParameter, costoParameter, fechaParameter, consecutParameter);
        }
    
        public virtual int SP_Kr_Eliminar(Nullable<int> consecut)
        {
            var consecutParameter = consecut.HasValue ?
                new ObjectParameter("Consecut", consecut) :
                new ObjectParameter("Consecut", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Kr_Eliminar", consecutParameter);
        }
    
        public virtual int SP_Per_Agregar(string nom_Pers, string ape_Pers, string tipo_iden, string nro_Iden, Nullable<System.DateTime> fec_Nac, string correo, string telefono, string contrasena, Nullable<int> tipo_Rol)
        {
            var nom_PersParameter = nom_Pers != null ?
                new ObjectParameter("Nom_Pers", nom_Pers) :
                new ObjectParameter("Nom_Pers", typeof(string));
    
            var ape_PersParameter = ape_Pers != null ?
                new ObjectParameter("Ape_Pers", ape_Pers) :
                new ObjectParameter("Ape_Pers", typeof(string));
    
            var tipo_idenParameter = tipo_iden != null ?
                new ObjectParameter("Tipo_iden", tipo_iden) :
                new ObjectParameter("Tipo_iden", typeof(string));
    
            var nro_IdenParameter = nro_Iden != null ?
                new ObjectParameter("Nro_Iden", nro_Iden) :
                new ObjectParameter("Nro_Iden", typeof(string));
    
            var fec_NacParameter = fec_Nac.HasValue ?
                new ObjectParameter("Fec_Nac", fec_Nac) :
                new ObjectParameter("Fec_Nac", typeof(System.DateTime));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            var tipo_RolParameter = tipo_Rol.HasValue ?
                new ObjectParameter("Tipo_Rol", tipo_Rol) :
                new ObjectParameter("Tipo_Rol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Per_Agregar", nom_PersParameter, ape_PersParameter, tipo_idenParameter, nro_IdenParameter, fec_NacParameter, correoParameter, telefonoParameter, contrasenaParameter, tipo_RolParameter);
        }
    
        public virtual int SP_Per_Editar(string nom_Pers, string ape_Pers, string tipo_iden, string nro_Iden, Nullable<System.DateTime> fec_Nac, string correo, string telefono, Nullable<int> cod_Pers, string contrasena, Nullable<int> tipo_Rol)
        {
            var nom_PersParameter = nom_Pers != null ?
                new ObjectParameter("Nom_Pers", nom_Pers) :
                new ObjectParameter("Nom_Pers", typeof(string));
    
            var ape_PersParameter = ape_Pers != null ?
                new ObjectParameter("Ape_Pers", ape_Pers) :
                new ObjectParameter("Ape_Pers", typeof(string));
    
            var tipo_idenParameter = tipo_iden != null ?
                new ObjectParameter("Tipo_iden", tipo_iden) :
                new ObjectParameter("Tipo_iden", typeof(string));
    
            var nro_IdenParameter = nro_Iden != null ?
                new ObjectParameter("Nro_Iden", nro_Iden) :
                new ObjectParameter("Nro_Iden", typeof(string));
    
            var fec_NacParameter = fec_Nac.HasValue ?
                new ObjectParameter("Fec_Nac", fec_Nac) :
                new ObjectParameter("Fec_Nac", typeof(System.DateTime));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var cod_PersParameter = cod_Pers.HasValue ?
                new ObjectParameter("Cod_Pers", cod_Pers) :
                new ObjectParameter("Cod_Pers", typeof(int));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            var tipo_RolParameter = tipo_Rol.HasValue ?
                new ObjectParameter("Tipo_Rol", tipo_Rol) :
                new ObjectParameter("Tipo_Rol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Per_Editar", nom_PersParameter, ape_PersParameter, tipo_idenParameter, nro_IdenParameter, fec_NacParameter, correoParameter, telefonoParameter, cod_PersParameter, contrasenaParameter, tipo_RolParameter);
        }
    
        public virtual int SP_Per_Eliminar(Nullable<int> cod_Pers)
        {
            var cod_PersParameter = cod_Pers.HasValue ?
                new ObjectParameter("Cod_Pers", cod_Pers) :
                new ObjectParameter("Cod_Pers", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Per_Eliminar", cod_PersParameter);
        }
    
        public virtual int SP_Pro_Agregar(Nullable<int> cod_Scat, string nombre_Produc, Nullable<int> existencia, string precio_Vta, Nullable<bool> activo)
        {
            var cod_ScatParameter = cod_Scat.HasValue ?
                new ObjectParameter("Cod_Scat", cod_Scat) :
                new ObjectParameter("Cod_Scat", typeof(int));
    
            var nombre_ProducParameter = nombre_Produc != null ?
                new ObjectParameter("Nombre_Produc", nombre_Produc) :
                new ObjectParameter("Nombre_Produc", typeof(string));
    
            var existenciaParameter = existencia.HasValue ?
                new ObjectParameter("Existencia", existencia) :
                new ObjectParameter("Existencia", typeof(int));
    
            var precio_VtaParameter = precio_Vta != null ?
                new ObjectParameter("Precio_Vta", precio_Vta) :
                new ObjectParameter("Precio_Vta", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("Activo", activo) :
                new ObjectParameter("Activo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Pro_Agregar", cod_ScatParameter, nombre_ProducParameter, existenciaParameter, precio_VtaParameter, activoParameter);
        }
    
        public virtual int SP_Pro_Editar(Nullable<int> cod_Scat, string nombre_Produc, Nullable<int> existencia, string precio_Vta, Nullable<bool> activo, Nullable<int> cod_Product)
        {
            var cod_ScatParameter = cod_Scat.HasValue ?
                new ObjectParameter("Cod_Scat", cod_Scat) :
                new ObjectParameter("Cod_Scat", typeof(int));
    
            var nombre_ProducParameter = nombre_Produc != null ?
                new ObjectParameter("Nombre_Produc", nombre_Produc) :
                new ObjectParameter("Nombre_Produc", typeof(string));
    
            var existenciaParameter = existencia.HasValue ?
                new ObjectParameter("Existencia", existencia) :
                new ObjectParameter("Existencia", typeof(int));
    
            var precio_VtaParameter = precio_Vta != null ?
                new ObjectParameter("Precio_Vta", precio_Vta) :
                new ObjectParameter("Precio_Vta", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("Activo", activo) :
                new ObjectParameter("Activo", typeof(bool));
    
            var cod_ProductParameter = cod_Product.HasValue ?
                new ObjectParameter("Cod_Product", cod_Product) :
                new ObjectParameter("Cod_Product", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Pro_Editar", cod_ScatParameter, nombre_ProducParameter, existenciaParameter, precio_VtaParameter, activoParameter, cod_ProductParameter);
        }
    
        public virtual int SP_Pro_Eliminar(Nullable<int> cod_Product)
        {
            var cod_ProductParameter = cod_Product.HasValue ?
                new ObjectParameter("Cod_Product", cod_Product) :
                new ObjectParameter("Cod_Product", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Pro_Eliminar", cod_ProductParameter);
        }
    
        public virtual int SP_Prove_Agregar(Nullable<int> cod_Pers, string locacion, string enlace, Nullable<bool> activo)
        {
            var cod_PersParameter = cod_Pers.HasValue ?
                new ObjectParameter("Cod_Pers", cod_Pers) :
                new ObjectParameter("Cod_Pers", typeof(int));
    
            var locacionParameter = locacion != null ?
                new ObjectParameter("Locacion", locacion) :
                new ObjectParameter("Locacion", typeof(string));
    
            var enlaceParameter = enlace != null ?
                new ObjectParameter("Enlace", enlace) :
                new ObjectParameter("Enlace", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("Activo", activo) :
                new ObjectParameter("Activo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Prove_Agregar", cod_PersParameter, locacionParameter, enlaceParameter, activoParameter);
        }
    
        public virtual int SP_Prove_Editar(Nullable<int> cod_Pers, string locacion, string enlace, Nullable<bool> activo, Nullable<int> cod_Prove)
        {
            var cod_PersParameter = cod_Pers.HasValue ?
                new ObjectParameter("Cod_Pers", cod_Pers) :
                new ObjectParameter("Cod_Pers", typeof(int));
    
            var locacionParameter = locacion != null ?
                new ObjectParameter("Locacion", locacion) :
                new ObjectParameter("Locacion", typeof(string));
    
            var enlaceParameter = enlace != null ?
                new ObjectParameter("Enlace", enlace) :
                new ObjectParameter("Enlace", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("Activo", activo) :
                new ObjectParameter("Activo", typeof(bool));
    
            var cod_ProveParameter = cod_Prove.HasValue ?
                new ObjectParameter("Cod_Prove", cod_Prove) :
                new ObjectParameter("Cod_Prove", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Prove_Editar", cod_PersParameter, locacionParameter, enlaceParameter, activoParameter, cod_ProveParameter);
        }
    
        public virtual int SP_Prove_Eliminar(Nullable<int> cod_Prove)
        {
            var cod_ProveParameter = cod_Prove.HasValue ?
                new ObjectParameter("Cod_Prove", cod_Prove) :
                new ObjectParameter("Cod_Prove", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Prove_Eliminar", cod_ProveParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int SP_SC_Agregar(string nom_Sbcat, Nullable<int> cod_Cat_Fk, Nullable<bool> activo)
        {
            var nom_SbcatParameter = nom_Sbcat != null ?
                new ObjectParameter("Nom_Sbcat", nom_Sbcat) :
                new ObjectParameter("Nom_Sbcat", typeof(string));
    
            var cod_Cat_FkParameter = cod_Cat_Fk.HasValue ?
                new ObjectParameter("Cod_Cat_Fk", cod_Cat_Fk) :
                new ObjectParameter("Cod_Cat_Fk", typeof(int));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("Activo", activo) :
                new ObjectParameter("Activo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_SC_Agregar", nom_SbcatParameter, cod_Cat_FkParameter, activoParameter);
        }
    
        public virtual int SP_SC_Editar(string nom_Sbcat, Nullable<int> cod_Cat_Fk, Nullable<bool> activo, Nullable<int> cod_Scat)
        {
            var nom_SbcatParameter = nom_Sbcat != null ?
                new ObjectParameter("Nom_Sbcat", nom_Sbcat) :
                new ObjectParameter("Nom_Sbcat", typeof(string));
    
            var cod_Cat_FkParameter = cod_Cat_Fk.HasValue ?
                new ObjectParameter("Cod_Cat_Fk", cod_Cat_Fk) :
                new ObjectParameter("Cod_Cat_Fk", typeof(int));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("Activo", activo) :
                new ObjectParameter("Activo", typeof(bool));
    
            var cod_ScatParameter = cod_Scat.HasValue ?
                new ObjectParameter("Cod_Scat", cod_Scat) :
                new ObjectParameter("Cod_Scat", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_SC_Editar", nom_SbcatParameter, cod_Cat_FkParameter, activoParameter, cod_ScatParameter);
        }
    
        public virtual int SP_SC_Eliminar(Nullable<int> cod_Scat)
        {
            var cod_ScatParameter = cod_Scat.HasValue ?
                new ObjectParameter("Cod_Scat", cod_Scat) :
                new ObjectParameter("Cod_Scat", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_SC_Eliminar", cod_ScatParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int SP_CREAR_COMPRA(Nullable<int> cod_Produc, Nullable<int> existencias)
        {
            var cod_ProducParameter = cod_Produc.HasValue ?
                new ObjectParameter("Cod_Produc", cod_Produc) :
                new ObjectParameter("Cod_Produc", typeof(int));
    
            var existenciasParameter = existencias.HasValue ?
                new ObjectParameter("Existencias", existencias) :
                new ObjectParameter("Existencias", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CREAR_COMPRA", cod_ProducParameter, existenciasParameter);
        }
    
        public virtual ObjectResult<LISTAR_PRODUCTOS_POR_SUBCATEGORIA_Result> LISTAR_PRODUCTOS_POR_SUBCATEGORIA(Nullable<int> cod_SubCategoria)
        {
            var cod_SubCategoriaParameter = cod_SubCategoria.HasValue ?
                new ObjectParameter("Cod_SubCategoria", cod_SubCategoria) :
                new ObjectParameter("Cod_SubCategoria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LISTAR_PRODUCTOS_POR_SUBCATEGORIA_Result>("LISTAR_PRODUCTOS_POR_SUBCATEGORIA", cod_SubCategoriaParameter);
        }
    
        public virtual ObjectResult<LISTAR_SUBCATEGORIAS_POR_CATEGORIA_Result> LISTAR_SUBCATEGORIAS_POR_CATEGORIA(Nullable<int> cod_Categoria)
        {
            var cod_CategoriaParameter = cod_Categoria.HasValue ?
                new ObjectParameter("Cod_Categoria", cod_Categoria) :
                new ObjectParameter("Cod_Categoria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LISTAR_SUBCATEGORIAS_POR_CATEGORIA_Result>("LISTAR_SUBCATEGORIAS_POR_CATEGORIA", cod_CategoriaParameter);
        }
    
        public virtual ObjectResult<SP_LISTAR_CATEGORIAS_Result> SP_LISTAR_CATEGORIAS()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_LISTAR_CATEGORIAS_Result>("SP_LISTAR_CATEGORIAS");
        }
    
        public virtual ObjectResult<Nullable<int>> SP_OBTENER_EXISTENCIAS_POR_PRODUCTO(Nullable<int> codProducto)
        {
            var codProductoParameter = codProducto.HasValue ?
                new ObjectParameter("codProducto", codProducto) :
                new ObjectParameter("codProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_OBTENER_EXISTENCIAS_POR_PRODUCTO", codProductoParameter);
        }
    
        public virtual ObjectResult<SP_LISTAR_PROVEEDORES_Result> SP_LISTAR_PROVEEDORES()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_LISTAR_PROVEEDORES_Result>("SP_LISTAR_PROVEEDORES");
        }
    
        public virtual int EditarContrasena(string correo, string contrasena)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("contrasena", contrasena) :
                new ObjectParameter("contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditarContrasena", correoParameter, contrasenaParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SP_VALIDAR_RELACION_PERSONA(Nullable<int> codPersona)
        {
            var codPersonaParameter = codPersona.HasValue ?
                new ObjectParameter("codPersona", codPersona) :
                new ObjectParameter("codPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_VALIDAR_RELACION_PERSONA", codPersonaParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SP_VALIDAR_RELACION_PRODUCTO(Nullable<int> codProducto)
        {
            var codProductoParameter = codProducto.HasValue ?
                new ObjectParameter("codProducto", codProducto) :
                new ObjectParameter("codProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_VALIDAR_RELACION_PRODUCTO", codProductoParameter);
        }
    }
}
