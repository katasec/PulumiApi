namespace PulumiApi.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {

            var client = new ApiClient();
            var result = await client.GetStacks();

            if (result.Stacks != null)
                foreach (var stack in result.Stacks)
                {
                    Console.WriteLine($"{stack.OrgName} {stack.ProjectName} {stack.StackName} {stack.ResourceCount}");
                }
        }
    }
}