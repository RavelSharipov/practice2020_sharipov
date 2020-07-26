using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurfClub.Models.DBModels
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Введите текст"), MaxLength(4095, ErrorMessage = "Максимальное количество символов 4095")]
        ///<summary>
        ///Текст
        ///</summary>
        public string Text { get; set; }
        [Display(Name = "Прикрепить изображение")]

        ///<summary>
        ///Дата публикации
        ///</summary>
        public DateTime PublishDate { get; set; }
        ///<summary>
        ///Изображение
        ///</summary>
        public Guid Photo { get; set; }
        ///<summary>
        ///Фото
        ///</summary>
        public virtual User Author { get; set; }


    }
}