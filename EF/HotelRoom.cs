//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelISP9_13.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotelRoom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelRoom()
        {
            this.RentRoom = new HashSet<RentRoom>();
        }
    
        public int IdRoom { get; set; }
        public int RoomNumber { get; set; }
        public int IdTypeRoom { get; set; }
        public int CountOfBeds { get; set; }
        public decimal Price { get; set; }
        public int IdHotel { get; set; }
    
        public virtual Hotel Hotel { get; set; }
        public virtual TypeRoom TypeRoom { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RentRoom> RentRoom { get; set; }
    }
}
