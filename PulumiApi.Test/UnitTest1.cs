namespace PulumiApi.Test
{
    public class Tests
    {
        private ApiClient client;

        [SetUp]
        public void Setup()
        {
             client = new ApiClient();
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

        [Test]
        public async Task GetStackState()
        {
            var result = await client.GetStackState("katasec","ark-init","dev");
            Console.WriteLine(result.ToString());
        }

        [Test]
        public async Task GetStackOutput()
        {
            var result = await client.GetStackOutput("katasec","ark-init","dev");
            foreach (var item in result)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}