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
    
    public partial class Student
    {
        public int Id { get; set; }
        public Nullable<int> EntryYear { get; set; }
        public Nullable<int> GraduationYear { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> GroupId { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
