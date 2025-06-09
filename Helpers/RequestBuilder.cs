using RestSharp;


public class RequestBuilder(string baseUrl)
{
    private readonly IRestClient _client = new RestClient(baseUrl);
    private RestRequest _request;

    public RequestBuilder WithEndpoint(string endpoint)
    {
        _request = new RestRequest(endpoint);
        return this;
    }

    public RequestBuilder WithMethod(Method method)
    {
        _request.Method = method;
        return this;
    }

    public RequestBuilder AddHeader(string key, string value)
    {
        _request.AddHeader(key, value);
        return this;
    }

    public RequestBuilder AddQueryParameter(string key, string value)
    {
        _request.AddQueryParameter(key, value);
        return this;
    }

    public RequestBuilder WithJsonBody(object body)
    {
        _request.AddJsonBody(body);
        return this;
    }

    public async Task<RestResponse> SendAsync()
    {
        var response = await _client.ExecuteAsync(_request);
        ArgumentNullException.ThrowIfNull(response.Content);
        return response; 
    }
}