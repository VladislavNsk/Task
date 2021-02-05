using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DocumentsStorage.Models
{
    public class Document
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Display(Name = "Тип документа")]
        public DocumentType Type { get; set;}

        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [HiddenInput(DisplayValue = false)]
        public byte[] DocumentBytes { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string FullName { get; set; }

        public Document(DocumentType documentType)
        {
            Type = documentType;
        }

        public Document()
        {

        }
    }
}