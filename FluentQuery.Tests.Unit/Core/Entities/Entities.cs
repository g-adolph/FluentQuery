using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentQuery.Tests.Unit.Core.Entities
{
    [Table(name:"Users")]
    public class AnnotationUser
    {
        [Key]        
        public long Id { get; set; }
        [Column(name:"UserName")]
        public string Name { get; set; }
        [Column(name: "UserBirthDay")]
        public DateTime BirthDay { get; set; }
    }

    [Table(name: "Users",Schema = "dbo")]
    public class AnnotationWithSchemaUser
    {
        [Key]
        public long Id { get; set; }
        [Column(name: "UserName")]
        public string Name { get; set; }
        [Column(name: "UserBirthDay")]
        public DateTime BirthDay { get; set; }
    }

    public class SimpleUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
