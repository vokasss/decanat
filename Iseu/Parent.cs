//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Iseu
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parent
    {
        public int Id { get; set; }
        public string Job { get; set; }
        public Nullable<int> StudentId { get; set; }
    
        public virtual User User { get; set; }
    }
}