using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephonkey.Models.Entities
{
    public class EntityLogin
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        //[MaxLength(250), Unique]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
