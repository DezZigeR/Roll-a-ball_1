using Geekbrains.NewDirectory1;

namespace Geekbrains
{
    internal sealed class ControllerTest1
    {
        private readonly ITest1 _test1;

        public ControllerTest1(ITest1 test1)
        {
            _test1 = test1;
        }

        private void NameMethod()
        {
            _test1.SaveGold(7);
        }
    }
}
