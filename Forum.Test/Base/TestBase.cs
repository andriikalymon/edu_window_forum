using AutoFixture;

namespace Forum.Test.Base
{
    public class TestBase
    {
        protected Fixture Fixture { get; set; }

        public TestBase()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}
