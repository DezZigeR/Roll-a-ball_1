using Geekbrains.NewDirectory1;

namespace Geekbrains
{
    internal sealed class ControllerTest2
    {
        private readonly ITest2 _test1;

        public ControllerTest2(ITest2 test1)
        {
            _test1 = test1;
        }

        private void NameMethod()
        {
            _test1.SaveHp(7.0f);
        }
    }
}
