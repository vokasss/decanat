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
    
    public partial class Speciality
    {
        public Speciality()
        {
            this.Groups = new HashSet<Group>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ChairId { get; set; }
        public string Title { get; set; }
        public Nullable<int> SyllabusId { get; set; }
    
        public virtual Chair Chair { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual Syllabus Syllabus { get; set; }
    }
}