﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WpfTestMailSender.ViewModel
{
    class EmailValidationRule : ValidationRule
    {
        readonly Regex regexMail = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z0-9]+\.[A-Za-z]{2,6}");
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value.ToString();
            if (!regexMail.IsMatch(email)) return new ValidationResult(false, "Не соответствует email!");
            else return new ValidationResult(true, null);
        }
    }
}
