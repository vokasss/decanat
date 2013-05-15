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
    
    public partial class Chair
    {
        public Chair()
        {
            this.Professors = new HashSet<Professor>();
            this.Specialities = new HashSet<Speciality>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> FacultyId { get; set; }
    
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Professor> Professors { get; set; }
        public virtual ICollection<Speciality> Specialities { get; set; }
    }
}
