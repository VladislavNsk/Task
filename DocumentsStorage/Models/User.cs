using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentsStorage.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [RegularExpression("^[A-Za-zА-Яа-я][A-Za-zА-Яа-я0-9]{5,20}$", ErrorMessage = "Не правильно введен пароль")]
        public string Login { get; set; }

        [RegularExpression("^[A-Za-zА-Яа-я][A-Za-zА-Яа-я0-9]{5,20}$", ErrorMessage = "Не правильно введен пароль")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
