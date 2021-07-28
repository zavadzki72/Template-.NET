using System;

namespace DotNetTemplate.Domain {

    public class Team {

        public static readonly Team Empty = new();

        private Team() { }

        public Team(string name, string initials, string city, string state, string nickName, string logoImage) {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;

            Name = name;
            Initials = initials;
            City = city;
            State = state;
            NickName = nickName;
            LogoImage = logoImage;
        }

        public Guid Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public string Name { get; private set; }
        public string Initials { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string NickName { get; private set; }
        public string LogoImage { get; private set; }
    }
}
