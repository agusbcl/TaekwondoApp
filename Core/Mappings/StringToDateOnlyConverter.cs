using AutoMapper;

namespace Mappings
{
    public class StringToDateOnlyConverter : ITypeConverter<string, DateOnly>
    {
        public DateOnly Convert(string src, DateOnly dest, ResolutionContext context)
        {
            return DateOnly.Parse(src);
        }
    }
}
