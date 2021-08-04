using Interfaces;

namespace ServicesNew
{
    public class Counter : ICounter
    {
        private int value = 0;

        public int GetValue()
        {
            return value;
        }

        public void IncrementValue()
        {
            value++;
        }
    }
}