using System.Net;
using System.Text.Json;
using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Models.API;
using log4net;
using Reqnroll;
using RestSharp;

[Binding]
public class UserAPISteps
{
    private RestResponse _response;
    private APIHelpers _helpers;
    private List<User> _users;
    private readonly RequestBuilder _requestBuilder;

    public UserAPISteps(ConfigsManager configs, ILog logger)
    {
        _requestBuilder = new RequestBuilder(configs.AppConfiguration.APIBaseURL);
        _helpers = new APIHelpers(logger);
    }

    [Given("I create a {Method} request to the {string} endpoint")]
    public void GivenICreateARequestToTheEndpoint(Method method, string endpoint)
    {
        _requestBuilder
            .WithEndpoint(endpoint)
            .WithMethod(method);
    }

    [When("I send the request")]
    public async Task WhenISendTheRequest()
    {
        _response = await _requestBuilder.SendAsync();
    }

    [Then("the response status code is {HttpStatusCode}")]
    public void ThenTheResponseStatusCodeIs(HttpStatusCode statusCode)
    {
        Assert.That(_response.StatusCode, Is.EqualTo(statusCode));
    }

    [Then("the response should contain a list of users with the following fields:")]
    public void ThenTheResponseShouldContainAListOfUsersWithTheFollowingFields(Table table)
    {
        _users = JsonSerializer.Deserialize<List<User>>(_response.Content);
        Assert.Multiple(() =>
        {
            foreach (var user in _users)
            {
                foreach (var row in table.Rows)
                {
                    var value = user.GetType().GetProperty(row["Field"]);
                    Assert.That(value, Is.Not.Null);
                }
            }
        });
    }

    [Then("the response header should contain content-type as {string}")]
    public void ThenTheResponseHeaderShouldContainContentTypeAs(string expectedContentType)
    {
        string actualContentType = _helpers.GetFullContentType(_response);
        Assert.That(actualContentType, Is.EqualTo(expectedContentType));
    }

    [Then("the response should contain an array of {int} users")]
    public void ThenTheResponseShouldContainAnArrayOfUsers(int expectedCount)
    {
        _users = _helpers.DeserializeResponseIntoListOf<User>(_response);
        Assert.That(_users, Has.Count.EqualTo(expectedCount));
    }

    [Then("each user should have a unique id")]
    public void ThenEachUserShouldHaveAUniqueId()
    {
        var ids = _users.Select(u => (int)u.Id).ToList();
        Assert.That(ids.Count, Is.EqualTo(ids.Distinct().Count()), "There are duplicated IDs.");
    }

    [Then("each user should have non-empty name and username")]
    public void ThenEachUserShouldHaveNonEmptyNameAndUsername()
    {
        _helpers.ValidateFieldIsNotNullFromListOf<User>(_users, "Name");
        _helpers.ValidateFieldIsNotNullFromListOf<User>(_users, "Username");

    }

    [Then("each user should contain a company with a non-empty name")]
    public void ThenEachUserShouldContainACompanyWithANonEmptyName()
    {
        _helpers.ValidateFieldIsNotNullFromListOfObjects<User>(_users, "Company", "Name");
    }

    [Given("I add the following data to the request body in JSON format:")]
    public void GivenIAddTheFollowingDataToTheRequestBodyInJSONFormat(Table table)
    {
        var data = table.Rows.ToDictionary(r => r["Field"], r => r["Value"]);
        _requestBuilder.WithJsonBody(data);
    }

    [Then("the response contains the field {string}")]
    public void ThenTheResponseContainTheField(string fieldName)
    {
        var fieldFound = _helpers.GetFieldFromResponse<User>(_response, fieldName);
        Assert.That(fieldFound, Is.Not.Null.And.Not.WhiteSpace.And.Not.Empty, $"Response did not contain the field {fieldName}: {_response.Content}");
    }
}