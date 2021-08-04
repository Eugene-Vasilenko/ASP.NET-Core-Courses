using Interfaces;

namespace ServicesNew
{
    public class AnotherService : IAnotherService
    {
        private readonly ICounter _counter;

        public AnotherService(ICounter counter)
        {
            _counter = counter;
        }

        public void DoSomeWork()
        {
            _counter.IncrementValue();
        }
    }
}