using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WesaamEcomerce.Common.Enums;

namespace WesaamEcomerce.EntityFramework.Converters
{
    public class CountriesConverter: ValueConverter<List<Country>, List<string>>
    {
        public CountriesConverter(): base(
                   countries => countries.Select(c => c.ToString()).ToList(),
                   countriesString => countriesString
                       .Select(s=> Enum.Parse<Country>(s)).ToList()
            )
        {
        }
    }
}
