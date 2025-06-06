using System.Reflection;
using System.Text.Json;
using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Models.API;
using Reqnroll;
using RestSharp;

[Binding]
public class APISteps
{
    private RestResponse _response;
    private List<User> _users;
    private readonly RequestBuilder _requestBuilder;

    public APISteps(ConfigsManager configs)
    {
        _requestBuilder = new RequestBuilder(configs.AppConfiguration.APIBaseURL);
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

    [Then("the response status code is {string}")]
    public void ThenTheResponseStatusCodeIs(string statusCode)
    {
        var response_status =_response.StatusCode.ToString();
        Assert.That(response_status, Is.EqualTo(statusCode));
    }

    [Then("the response should contain a list of users with the following fields:")]
    public void ThenTheResponseShouldContainAListOfUsersWithTheFollowingFields(Table table)
    {
        ArgumentNullException.ThrowIfNull(_response);
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
        string actualContentType = _response.ContentHeaders.FirstOrDefault(h => h.Name.Contains("Content-Type")).Value;
        Assert.That(actualContentType, Is.EqualTo(expectedContentType));
    }

    [Then("the response should contain an array of {int} users")]
    public void ThenTheResponseShouldContainAnArrayOfUsers(int expectedCount)
    {
        _users = JsonSerializer.Deserialize<List<User>>(_response.Content);
        Assert.That(_users.Count, Is.EqualTo(expectedCount));
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
        Assert.Multiple(() =>
        {
            foreach (var user in _users)
            {
                Assert.That(user.Name, Is.Not.Null.And.Not.WhiteSpace);
                Assert.That(user.Username, Is.Not.Null.And.Not.WhiteSpace);
            }
        });
    }

    [Then("each user should contain a company with a non-empty name")]
    public void ThenEachUserShouldContainACompanyWithANonEmptyName()
    {
        Assert.Multiple(() =>
        {
            foreach (var user in _users)
            {
                Assert.That(user.Company.Name, Is.Not.Null.And.Not.WhiteSpace);
            }
        });
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
        ArgumentNullException.ThrowIfNull(_response.Content);
        User? requestResponse = JsonSerializer.Deserialize<User>(_response.Content);
        ArgumentNullException.ThrowIfNull(requestResponse);
        var deserializedField = requestResponse.GetType().GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
        Assert.That(deserializedField, Is.Not.Null, $"Actual response: {_response.Content}");
    }
}