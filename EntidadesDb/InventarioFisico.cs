//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntidadesDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class InventarioFisico
    {
        public int Id { get; set; }
        public int IdAlmacen { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    
        public virtual Almacen Almacen { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
