namespace API.src.Core.Filters
{
    public class FilterInterval<T>
    {
        public T minValue { get; set; }
        public T maxValue { get; set; }

        public FilterInterval(T minValue, T maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
    }
}
