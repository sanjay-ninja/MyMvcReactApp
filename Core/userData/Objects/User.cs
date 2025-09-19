namespace MyMvcReactApp.Core.UserData.Objects
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("users")]
    public class User
    {
        [Column("id")] // map to lowercase column
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("normalizedemail")]
        public string NormalizedEmail { get; set; }

        [Column("createdat")]
        public DateTime CreatedAt { get; set; }
    }
}