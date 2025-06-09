using System.Reflection;
using System.Text.Json;
using log4net;
using Reqnroll;
using RestSharp;

namespace DotnetTaskSeleniumNunit.Helpers;

class APIHelpers
{
    private ILog _logger;

    public APIHelpers(ILog logger)
    {
        _logger = logger;
    }

    public void AssertFieldsFromResponseObjects<T>(RestResponse response, Table table)
    {
        _logger.Info($"Validating API response fields: {response.Content}");

        var responseObjects = DeserializeResponseIntoListOf<T>(response);
        Assert.Multiple(() =>
        {
            foreach (var responseObject in responseObjects)
            {
                foreach (var row in table.Rows)
                {
                    var value = responseObject.GetType().GetProperty(row["Field"]);
                    Assert.That(value, Is.Not.Null, $"The expected field {row["Field"]} was not found in the deserialized object");
                }
            }
        });
    }
    public List<T> DeserializeResponseIntoListOf<T>(RestResponse response)
    {
        _logger.Info($"Deserializing API response into a list...");

        try
        {
            return JsonSerializer.Deserialize<List<T>>(response.Content);
        }
        catch (Exception)
        {
            _logger.Error($"There was an error while deserializing the API response: {response.Content}");
            throw;
        }
    }
    public T DeserializeResponseIntoListOfObject<T>(RestResponse response)
    {
        _logger.Info($"Deserializing API response into object...");

        try
        {
            return JsonSerializer.Deserialize<T>(response.Content);
        }
        catch (Exception)
        {
            _logger.Error($"There was an error while deserializing the API response: {response.Content}");
            throw;
        }
    }
    public string GetFullContentType(RestResponse response)
    {
        _logger.Info($"Deserializing API response ...");
        ArgumentNullException.ThrowIfNull(response.ContentHeaders);

        try
        {
            return response.ContentHeaders.FirstOrDefault(h => h.Name.Contains("Content-Type")).Value;
        }
        catch (Exception)
        {
            _logger.Error($"No content type was found from response: {response.Headers}");
            throw;
        }
    }

    public void ValidateFieldIsNotNullFromListOf<T>(List<T> listOfObjects, string fieldName)
    {
        Assert.Multiple(() =>
        {
            foreach (var itemFromList in listOfObjects)
            {
                PropertyInfo fieldProperty = itemFromList.GetType().GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                string fieldValue = fieldProperty.GetValue(itemFromList).ToString();

                Assert.That(fieldValue, Is.Not.Null.And.Not.WhiteSpace,
                    $"The expected field '{fieldName}' was not found on the object: {itemFromList.ToString()}");
            }
        });
    }

    public void ValidateFieldIsNotNullFromListOfObjects<T>(List<T> listOfObjects, string objectParent, string fieldName)
    {
        Assert.Multiple(() =>
        {
            foreach (var itemFromList in listOfObjects)
            {
                var parentField = itemFromList.GetType().GetProperty(objectParent, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                var parentValue = parentField.GetValue(itemFromList);
                var childField = parentValue.GetType().GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                var fieldValue = childField.GetValue(parentValue).ToString();
                Assert.That(fieldValue,
                    Is.Not.Null.And.Not.WhiteSpace,
                    $"The expected field '{fieldName}' was not found on the object '{objectParent}': {itemFromList.ToString()}");
            }
        });
    }

    public string? GetFieldFromResponse<T>(RestResponse response, string fieldName)
    {
        _logger.Info($"Obtaining Field from Response Object ...");

        try
        {
            var responseObject = DeserializeResponseIntoListOfObject<T>(response);
            var fieldProperty = responseObject.GetType().GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            var fieldValue = fieldProperty.GetValue(responseObject).ToString();
            return fieldValue;
        }
        catch (Exception)
        {
            _logger.Error($"Field '{fieldName}' not found in API response");
            return null;
        }

    }
}

