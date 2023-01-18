using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

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
            Console.WriteLine(result.ToString());
        }

        [Test]
        public async Task GetStackState()
        {
            var result = await client.GetStackState(orgName, projectName, stackName );
            Console.WriteLine(result.ToString());
        }

        [Test]
        public async Task GetStackOutput()
        {
            var result = await client.GetStackOutput(orgName, projectName, stackName);
            foreach (var item in result)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        [Test]
        public async Task ListStackUpdates()
        {
            var result = await client.ListStackUpdates(orgName, projectName, stackName);
            Console.WriteLine(result.ToString());
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
    }
}