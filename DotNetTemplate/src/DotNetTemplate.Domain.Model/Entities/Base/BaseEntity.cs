using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTemplate.Domain.Model.Entities.Base {

    public abstract class BaseEntity {

        public BaseEntity() { }

        public BaseEntity(Guid id) {
            Id = id;
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required()]
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Required()]
        [Column("update_date")]
        public DateTime UpdateDate { get; set; }
    }
}
