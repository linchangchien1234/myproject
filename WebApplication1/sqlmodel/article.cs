//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.sqlmodel
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public article()
        {
            this.article_message = new HashSet<article_message>();
        }
    
        public int id { get; set; }
        public string header { get; set; }
        public string body { get; set; }
        public byte[] createtime { get; set; }
        public Nullable<System.DateTime> delettime { get; set; }
        public int userid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<article_message> article_message { get; set; }
        [JsonIgnore]
        public virtual user user { get; set; }
    }
}