using System;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Infra
{
    public class ObrigatorioAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var valorString = value as string;
            if (valorString != null && string.IsNullOrWhiteSpace(valorString))
            {
                return false;
            }
            else
            {
                var guid = value as Guid?;
                if (guid.HasValue && guid == Guid.Empty)
                {
                    return false;
                }

                if (value is int)
                {
                    int numerico = Convert.ToInt32(value);
                    return numerico > 0;
                }

                if (value is double)
                {
                    double numerico = Convert.ToDouble(value);
                    return numerico > 0;
                }
                if (value is decimal)
                {
                    decimal numerico = Convert.ToDecimal(value);
                    return numerico > 0;
                }
                if (value is long)
                {
                    long numerico = Convert.ToInt64(value);
                    return numerico > 0;
                }
                return value != null;
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var nomeCampo = string.IsNullOrWhiteSpace(validationContext.DisplayName) ? validationContext.MemberName : validationContext.DisplayName;
            ErrorMessage = $"O campo '{nomeCampo}' é obrigatório.";
            return base.IsValid(value, validationContext);
        }
    }
}