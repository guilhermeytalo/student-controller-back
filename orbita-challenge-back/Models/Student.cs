using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("academic_register")]
        public string AcademicRegister { get; set; }
        
        [Column("cpf")]
        public string Cpf { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
    }
    
}