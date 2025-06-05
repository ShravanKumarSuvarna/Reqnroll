using System;
//using TechTalk.SpecFlow;

using Reqnroll;

using ReqnrollProject1.Pages;
using ReqnrollProject1.Utilities;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class FormStepDefinitions
    {
        private readonly FormPage _formPage;

        public FormStepDefinitions(DriverContext context)
        {
            _formPage = new FormPage(context.Driver);
        }

        [Given("I am on the Student Registration Form page")]
        public void GivenIAmOnTheStudentRegistrationFormPage()
        {
            _formPage.LaunchBrowser();
        }

        [When("I fill the form with:")]
        public void WhenIFillTheFormWith(Table table)
        {
            //var row = table.Rows[0];
            foreach (var row in table.Rows)
            {

                _formPage.EnterInput(
                row["Name"],
                row["Email"],
                row["DateOfBirth"],
                row["Mobile"],
                row["Subjects"],
                row["PicturePath"],
                row["Address"],
                row["City"],
                row["State"],
                row["Hobbies"]
            );
            }
            }

            [When("I submit the registration form")]
        public void WhenISubmitTheRegistrationForm()
        {
            _formPage.Submit();
        }

        [Then("the form should be submitted successfully")]
        public void ThenTheFormShouldBeSubmittedSuccessfully()
        {
            _formPage.HomePageDisplay();
        }
    }
}
