﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:1.0.0.0
//      Reqnroll Generator Version:1.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RealTrend.UnitTests.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class GetBFENumberFromAAddressFeature : object, Xunit.IClassFixture<GetBFENumberFromAAddressFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private static Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ApiBDDTest.feature"
#line hidden
        
        public GetBFENumberFromAAddressFeature(GetBFENumberFromAAddressFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.GetWorkerId());
            Reqnroll.FeatureInfo featureInfo = new Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Get BFE number from a address", "As a user I want to get the BFE number from a address,\nso i\'m able to use the BFE" +
                    " number,\nto see information about the address.", ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            string testWorkerId = testRunner.TestWorkerId;
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
            Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.ReleaseWorker(testWorkerId);
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="User types in a address and get address id")]
        [Xunit.TraitAttribute("FeatureTitle", "Get BFE number from a address")]
        [Xunit.TraitAttribute("Description", "User types in a address and get address id")]
        public async System.Threading.Tasks.Task UserTypesInAAddressAndGetAddressId()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("User types in a address and get address id", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 8
 await testRunner.GivenAsync("the user types in a address \"Provstebakken+23D\"", ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 9
 await testRunner.WhenAsync("the user clicks on the submit button", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 10
 await testRunner.ThenAsync("the user will get the correct address id", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="System is able to find the jordstykke number from address id")]
        [Xunit.TraitAttribute("FeatureTitle", "Get BFE number from a address")]
        [Xunit.TraitAttribute("Description", "System is able to find the jordstykke number from address id")]
        public async System.Threading.Tasks.Task SystemIsAbleToFindTheJordstykkeNumberFromAddressId()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("System is able to find the jordstykke number from address id", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 12
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 13
 await testRunner.GivenAsync("the system has a address id", ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 14
 await testRunner.WhenAsync("the system sends a GET jordstykke request to the api", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 15
 await testRunner.ThenAsync("the system will retrieve the correct jordstykke number", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="System is able to find the BFE number from jordstykke number")]
        [Xunit.TraitAttribute("FeatureTitle", "Get BFE number from a address")]
        [Xunit.TraitAttribute("Description", "System is able to find the BFE number from jordstykke number")]
        public async System.Threading.Tasks.Task SystemIsAbleToFindTheBFENumberFromJordstykkeNumber()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("System is able to find the BFE number from jordstykke number", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 17
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 18
 await testRunner.GivenAsync("the system has a jordstykke number", ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 19
 await testRunner.WhenAsync("the system sends the GET BFE request to the api", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 20
 await testRunner.ThenAsync("the system will retrieve the BFE number", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "1.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await GetBFENumberFromAAddressFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await GetBFENumberFromAAddressFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
