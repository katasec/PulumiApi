namespace PulumiApi.Test
{
    public class Tests
    {
        private readonly ApiClient client;

        public Tests()
        {
            client = new ApiClient();
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ListStacks()
        {

            var result = await client.ListStacks();

            foreach (Stack stack in result.Stacks)
            {
                Console.WriteLine($"{stack.OrgName} {stack.ProjectName} {stack.StackName} {stack.ResourceCount}");
            }
        }

        [Test]
        public async Task GetStack()
        {
            var result = await client.GetStack("katasec","azurecloudspace","dev");

            Console.WriteLine(result.ToString());
        }
    }
}