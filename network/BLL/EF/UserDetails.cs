//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace network.BLL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDetails()
        {
            this.Photoalbum = new HashSet<Photoalbum>();
            this.Conversation = new HashSet<Conversation>();
            this.Participants = new HashSet<Participants>();
            this.Messages = new HashSet<Messages>();
        }
    
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public Nullable<System.DateTime> DateOfBirthday { get; set; }
        public Nullable<int> FamilyStatusId { get; set; }
        public Nullable<int> ImagesId { get; set; }
        public Nullable<int> WorkPlaceId { get; set; }
        public Nullable<int> SchoolId { get; set; }
        public Nullable<int> HomeTownLocationId { get; set; }
        public Nullable<int> CurrentLocationId { get; set; }
        public string Gender { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual FamilyStatus FamilyStatus { get; set; }
        public virtual Images Images { get; set; }
        public virtual Location Location { get; set; }
        public virtual Location Location1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photoalbum> Photoalbum { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Conversation> Conversation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participants> Participants { get; set; }
        public virtual School School { get; set; }
        public virtual WorkPlace WorkPlace { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Messages> Messages { get; set; }
    }
}
