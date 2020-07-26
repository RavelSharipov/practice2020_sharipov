using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurfClub.Models.DBModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        ///<summary>
        ///Псевдоним
        ///</summary> 
        [Display(Name = "Псевдоним*")]
        [Required(ErrorMessage = "Указание псевдонима обязательно")]
        [RegularExpression(@"^[a-zA-Z0-9а-я''-'\s]{3,20}$", ErrorMessage = "Ошибка в псевдониме")]

        public string Nickname { get; set; }
        ///<summary>
        ///Электронная почта
        ///</summary>
        [Display(Name = "Почта*")]
        [Required(ErrorMessage = "Указание электронной почты обязательно")]
        [StringLength(31, ErrorMessage = "Максимальная длина 31 символ")]
        [EmailAddress(ErrorMessage = "Неверно указан электронный адрес")]
        public string Email { get; set; }
        ///<summary>
        ///Пароль
        ///</summary>
        [Display(Name = "Пароль*")]
        [StringLength(31, ErrorMessage = "Максимальная длина 31 символ")]
        [Required(ErrorMessage = "Указание пароля обязательно")]
        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{6,20}$",ErrorMessage = "Ошибка в пароле")]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль*")]
        [NotMapped]
        public string PasswordConfirm { get; set; }
        ///<summary>
        ///Фамилия
        ///</summary>
        [Display(Name = "Фамилия")]
        [StringLength(31, ErrorMessage = "Максимальная длина 31 символ")]
        public string Lastname { get; set; }
        ///<summary>
        ///Имя
        ///</summary>
        [Display(Name = "Имя")]
        [StringLength(31, ErrorMessage = "Максимальная длина 31 символ")]
        public string Name { get; set; }
        ///<summary>
        ///Контактная информация
        ///</summary>
        [Display(Name = "Контактная информация")]
        [StringLength(255, ErrorMessage = "Максимальная длина 255 символов")]

        public string ContactInfo { get; set; }
        ///<summary>
        ///О себе
        ///</summary>
        [Display(Name = "О себе")]
        [StringLength(255, ErrorMessage = "Максимальная длина 255 символов")]

        public string About { get; set; }
        ///<summary>
        ///Достижения
        ///</summary>
        [Display(Name = "Достижения")]
        [StringLength(255, ErrorMessage = "Максимальная длина 255 символов")]

        public string Achivements { get; set; }
        ///<summary>
        ///Фото
        ///</summary>
        [Display(Name = "Выберете фото")]
        public Guid Photo { get; set; }

    }
}