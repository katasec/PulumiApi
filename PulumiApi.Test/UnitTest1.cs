using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using PulumiApi.Models;

namespace PulumiApi.Test
{
    public class Tests
    {
        private ApiClient client;
        private string orgName;
        private string projectName;
        private string stackName;

        [SetUp]
        public async Task Setup()
        {
            client = new ApiClient();
            (orgName, projectName, stackName) = await GetStackInfo();
            projectName = "azurecloudspace";
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
            var result = await client.GetStack(orgName,projectName,stackName);
            Console.WriteLine(result.ToJson());
        }

        [Test]
        public async Task GetStackState()
        {
            var result = await client.GetStackState(orgName, projectName, stackName);
            Console.WriteLine(result.ToJson() );
        }

        [Test]
        public async Task GetResourceGroupFromStack()
        {
            var result = await client.GetStackState(orgName, projectName, stackName );
            
            if (result.Deployment != null)
            {
                Console.WriteLine(result.Deployment.GetAzureResourceGroup("rg-ameer"));
            }
        }

        [Test]
        public async Task GetVNetFromStack()
        {
            var result = await client.GetStackState(orgName, projectName, stackName);

            if (result.Deployment != null)
            {
                Console.WriteLine(result.Deployment.GetAzureVnet("ameer"));
            }
        }

        [Test]
        public async Task GetStackOutput()
        {
            var result = await client.GetStackOutput(orgName, projectName, stackName);
            if (result != null)
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
            } 
            else
            {
                Console.WriteLine("Output was null");
            }
        }

        [Test]
        public async Task ListStackUpdates()
        {
            var result = await client.ListStackUpdates(orgName, projectName, stackName);
            Console.WriteLine(result.ToJson());
        }

        [Test]
        public async Task GetUpdateStatus()
        {
            var result = await client.ListStackUpdates(orgName, projectName, stackName);

             
            if (result.Updates != null)
            {
                var latestRevision = result.Updates.Max(x => x.version);
                var latestUpdate = result.Updates.First(x => x.version == latestRevision);

                var updateId = latestUpdate.UpdateID;

                var status  = await client.GetUpdateStatus(orgName, projectName, stackName, updateId);
                Console.WriteLine(status.Status);
                Console.WriteLine(latestUpdate.Info.StartTime);
                Console.WriteLine(latestUpdate.Info.StartTimeDt);
                Console.WriteLine(latestUpdate.Info.EndTime);
                Console.WriteLine(latestUpdate.Info.EndTimeDt);
                

            }
            else
            {
                Console.WriteLine("No updates found");
            }

        }

        public async Task<Tuple<string?,string?,string?>?> GetStackInfo()
        {
            var result = await client.ListStacks();
            if (result.Stacks!= null)
            {
                var myStack = result.Stacks[0];

                var orgName = myStack.OrgName;
                var projectName = myStack.ProjectName;
                var stackName = myStack.StackName;

                return Tuple.Create(orgName, projectName, stackName);
            }
            return null;
        }

                [Test]
        public async Task ListStackUpdatesLatest()
        {
            var result = await client.ListStackUpdatesLatest(orgName, projectName, stackName);
            
            //Console.WriteLine(result);
            Console.WriteLine(result.UpdateID);
            Console.WriteLine(result.Info?.StartTimeDt);
            Console.WriteLine(result.Info?.EndTimeDt);
            Console.WriteLine(result.Info?.Result);

            var delete = result.Info?.ResourceChanges?.Delete == null ? 0 : result.Info.ResourceChanges.Delete;
            var create = result.Info?.ResourceChanges?.Create == null ? 0 : result.Info.ResourceChanges.Create;
            var same = result.Info?.ResourceChanges?.Same == null ? 0 : result.Info.ResourceChanges.Same;
            var update = result.Info?.ResourceChanges?.Update == null ? 0 : result.Info.ResourceChanges.Update;

            Console.WriteLine($"Delete count:{delete}");
            Console.WriteLine($"Create count:{create}");
            Console.WriteLine($"Same count:{same}");
            Console.WriteLine($"Update count:{update}");

            var pulumiUrl = await client.GetStackUpdatesLatestUrl(orgName, projectName, stackName);
            Console.WriteLine(pulumiUrl);
        }

        [Test]
        public void Stuff()
        {
            var x = "This is Ameer";
            Console.WriteLine(x.EndsWith("Ameer"));
        }
    }
}