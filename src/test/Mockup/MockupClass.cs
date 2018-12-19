using System.ComponentModel.DataAnnotations;

namespace Dime.Utilities.Core.Tests
{
    public class Customer
    {
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:N1}")]
        public int Id { get; set; }
    }
}