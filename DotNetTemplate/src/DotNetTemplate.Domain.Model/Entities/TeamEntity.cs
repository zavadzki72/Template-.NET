using DotNetTemplate.Domain.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTemplate.Domain.Model.Entities {

    public class TeamEntity : BaseEntity {

        public TeamEntity() { }

        public TeamEntity(Guid id, string name, string initials, string city, string state, string nickName, string logoImage) : base(id){
            Name = name;
            Initials = initials;
            City = city;
            State = state;
            NickName = nickName;
            LogoImage = logoImage;
        }

        [Required()]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required()]
        [Column("initials")]
        [MaxLength(100)]
        public string Initials { get; set; }

        [Required()]
        [Column("city")]
        public string City { get; set; }

        [Required()]
        [Column("state")]
        public string State { get; set; }

        [Required()]
        [Column("nickname")]
        public string NickName { get; set; }

        [Required()]
        [Column("logo_image")]
        public string LogoImage { get; set; }
    }
}
