using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //run metoduna isteiğimiz kadar ıresult verebiliyoruz.logics iş kuralları demek
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;//parametre ile gönderdiğimiz iş kurallarından başarız olanı businessa haber ediyoruz. checkif ile başlayan kurallar iş kuralları
                }
            }

            return null;
        }
    }
}
