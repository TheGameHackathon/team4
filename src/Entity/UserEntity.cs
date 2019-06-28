using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thegame.Entity
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public int Fails { get; set; }

        public UserEntity(string name)
        {
            Id = new Guid();
            Name = name;
        }
    }
}
