﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace EcommerceProject.Specflow.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ProductFeature : object, Xunit.IClassFixture<ProductFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Product.feature"
#line hidden
        
        public ProductFeature(ProductFeature.FixtureData fixtureData, EcommerceProject_Specflow_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Product", "In order to have available products for customer to buy in ecommcerce website.\r\nA" +
                    "s an admin of the website. I want to manage (get, create, update and delete) pro" +
                    "ducts.\r\nAnd customer can find products that they want to.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="CreateProduct")]
        [Xunit.TraitAttribute("FeatureTitle", "Product")]
        [Xunit.TraitAttribute("Description", "CreateProduct")]
        [Xunit.TraitAttribute("Category", "createProduct")]
        public virtual void CreateProduct()
        {
            string[] tagsOfScenario = new string[] {
                    "createProduct"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CreateProduct", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Value",
                            "Currency",
                            "TradeMark",
                            "Origin",
                            "Discription"});
                table1.AddRow(new string[] {
                            "1",
                            "Product 1",
                            "100",
                            "USA",
                            "Viet Nam",
                            "Viet Nam",
                            "This is a product 1"});
#line 9
 testRunner.Given("The following product dataset", ((string)(null)), table1, "Given ");
#line hidden
#line 12
 testRunner.When("Admin wants to create an product", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Value",
                            "Currency",
                            "TradeMark",
                            "Origin",
                            "Discription"});
                table2.AddRow(new string[] {
                            "1",
                            "Product 1",
                            "100",
                            "USA",
                            "Viet Nam",
                            "Viet Nam",
                            "This is a product 1"});
#line 13
 testRunner.Then("The product repository should has an product", ((string)(null)), table2, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="GetProducts")]
        [Xunit.TraitAttribute("FeatureTitle", "Product")]
        [Xunit.TraitAttribute("Description", "GetProducts")]
        [Xunit.TraitAttribute("Category", "getProducts")]
        public virtual void GetProducts()
        {
            string[] tagsOfScenario = new string[] {
                    "getProducts"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetProducts", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Value",
                            "Currency",
                            "TradeMark",
                            "Origin",
                            "Discription"});
                table3.AddRow(new string[] {
                            "1",
                            "Product 1",
                            "100",
                            "USA",
                            "Viet Nam",
                            "Viet Nam",
                            "This is a product 1"});
                table3.AddRow(new string[] {
                            "2",
                            "Product 2",
                            "200",
                            "USA",
                            "Viet Nam",
                            "China",
                            "This is a product 2"});
#line 19
 testRunner.Given("The product repository already exists the following products", ((string)(null)), table3, "Given ");
#line hidden
#line 23
 testRunner.When("User wants to get all products", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Value",
                            "Currency",
                            "TradeMark",
                            "Origin",
                            "Discription"});
                table4.AddRow(new string[] {
                            "1",
                            "Product 1",
                            "100",
                            "USA",
                            "Viet Nam",
                            "Viet Nam",
                            "This is a product 1"});
                table4.AddRow(new string[] {
                            "2",
                            "Product 2",
                            "200",
                            "USA",
                            "Viet Nam",
                            "China",
                            "This is a product 2"});
#line 24
 testRunner.Then("The product repository should return all products", ((string)(null)), table4, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="GetTheDetailsOfAnExistingProduct")]
        [Xunit.TraitAttribute("FeatureTitle", "Product")]
        [Xunit.TraitAttribute("Description", "GetTheDetailsOfAnExistingProduct")]
        [Xunit.TraitAttribute("Category", "getTheDetailsOfAnExistProduct")]
        public virtual void GetTheDetailsOfAnExistingProduct()
        {
            string[] tagsOfScenario = new string[] {
                    "getTheDetailsOfAnExistProduct"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetTheDetailsOfAnExistingProduct", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 30
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Value",
                            "Currency",
                            "TradeMark",
                            "Origin",
                            "Discription"});
                table5.AddRow(new string[] {
                            "1",
                            "Product 1",
                            "100",
                            "USA",
                            "Viet Nam",
                            "Viet Nam",
                            "This is a product 1"});
                table5.AddRow(new string[] {
                            "2",
                            "Product 2",
                            "200",
                            "USA",
                            "Viet Nam",
                            "China",
                            "This is a product 2"});
#line 31
 testRunner.Given("The product repository already exists the following products", ((string)(null)), table5, "Given ");
#line hidden
#line 35
 testRunner.When("User wants to get detais of an product with id 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Value",
                            "Currency",
                            "TradeMark",
                            "Origin",
                            "Discription"});
                table6.AddRow(new string[] {
                            "1",
                            "Product 1",
                            "100",
                            "USA",
                            "Viet Nam",
                            "Viet Nam",
                            "This is a product 1"});
#line 36
 testRunner.Then("The product repository should return required product dataset", ((string)(null)), table6, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="GetTheDetailsThatDoNotExist")]
        [Xunit.TraitAttribute("FeatureTitle", "Product")]
        [Xunit.TraitAttribute("Description", "GetTheDetailsThatDoNotExist")]
        [Xunit.TraitAttribute("Category", "getTheDetailsThatDoNotExist")]
        public virtual void GetTheDetailsThatDoNotExist()
        {
            string[] tagsOfScenario = new string[] {
                    "getTheDetailsThatDoNotExist"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetTheDetailsThatDoNotExist", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Value",
                            "Currency",
                            "TradeMark",
                            "Origin",
                            "Discription"});
                table7.AddRow(new string[] {
                            "1",
                            "Product 1",
                            "100",
                            "USA",
                            "Viet Nam",
                            "Viet Nam",
                            "This is a product 1"});
                table7.AddRow(new string[] {
                            "2",
                            "Product 2",
                            "200",
                            "USA",
                            "Viet Nam",
                            "China",
                            "This is a product 2"});
#line 42
 testRunner.Given("The product repository already exists the following products", ((string)(null)), table7, "Given ");
#line hidden
#line 46
 testRunner.When("User wants to get detais of an product with id 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 47
 testRunner.Then("There is no product with id 3 and the return status is NotFound", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="UpdateProduct")]
        [Xunit.TraitAttribute("FeatureTitle", "Product")]
        [Xunit.TraitAttribute("Description", "UpdateProduct")]
        [Xunit.TraitAttribute("Category", "updateProduct")]
        public virtual void UpdateProduct()
        {
            string[] tagsOfScenario = new string[] {
                    "updateProduct"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("UpdateProduct", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 50
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Value",
                            "Currency",
                            "TradeMark",
                            "Origin",
                            "Discription"});
                table8.AddRow(new string[] {
                            "1",
                            "Product 1",
                            "100",
                            "USA",
                            "Viet Nam",
                            "Viet Nam",
                            "This is a product 1"});
                table8.AddRow(new string[] {
                            "2",
                            "Product 2",
                            "200",
                            "USA",
                            "Viet Nam",
                            "China",
                            "This is a product 2"});
#line 51
 testRunner.Given("The product repository already exists the following products", ((string)(null)), table8, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Value",
                            "Currency",
                            "TradeMark",
                            "Origin",
                            "Discription"});
                table9.AddRow(new string[] {
                            "1",
                            "Product 1",
                            "200",
                            "USA",
                            "China",
                            "China",
                            "This is a changed product"});
#line 55
 testRunner.When("User wants to update product with id 1 according to the following dataset", ((string)(null)), table9, "When ");
#line hidden
#line 58
 testRunner.Then("In the product repository the data of the product is 1 is changed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="DeleteProduct")]
        [Xunit.TraitAttribute("FeatureTitle", "Product")]
        [Xunit.TraitAttribute("Description", "DeleteProduct")]
        [Xunit.TraitAttribute("Category", "deleteProduct")]
        public virtual void DeleteProduct()
        {
            string[] tagsOfScenario = new string[] {
                    "deleteProduct"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DeleteProduct", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 62
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Value",
                            "Currency",
                            "TradeMark",
                            "Origin",
                            "Discription"});
                table10.AddRow(new string[] {
                            "1",
                            "Product 1",
                            "100",
                            "USA",
                            "Viet Nam",
                            "Viet Nam",
                            "This is a product 1"});
                table10.AddRow(new string[] {
                            "2",
                            "Product 2",
                            "200",
                            "USA",
                            "Viet Nam",
                            "China",
                            "This is a product 2"});
#line 63
 testRunner.Given("The product repository already exists the following products", ((string)(null)), table10, "Given ");
#line hidden
#line 67
 testRunner.When("User wants to delete product with id 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 68
 testRunner.Then("There is no product with id 2 and the return status is NotFound", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ProductFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ProductFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
