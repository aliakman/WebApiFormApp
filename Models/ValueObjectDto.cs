using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiFormApp.Models
{
    public class ValueObjectDto
    {
        // Bu sınıf sadece FirstName, LastName gibi nesne dönen yerler için
        public object Value { get; set; } = default!;
        public override string ToString() => Value?.ToString() ?? string.Empty;
    }
}
