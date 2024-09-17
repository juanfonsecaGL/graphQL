using System.Text.Json;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json.Linq;

namespace dotNetGraphiQL;

public class Tests
{
    GraphQLHttpClient _graphQLClient;
    string _logFilePath;

    [SetUp]
    public void Setup()
    {
        InitGraphQL();
        InitLogs();
    }

    void InitGraphQL()
    {
        _graphQLClient = new GraphQLHttpClient(
            //"https://swapi-graphql.netlify.app/.netlify/functions/index", // Apollo's Star Wars Service
            "https://graphql.postman-echo.com/graphql",   // Postman Echo Service
            new NewtonsoftJsonSerializer()
        );
    }

    void InitLogs()
    {
        string logsDirectoryPath = Path.Combine(Environment.CurrentDirectory, "logs");
        if(!Directory.Exists(logsDirectoryPath))
        {
            Directory.CreateDirectory(logsDirectoryPath);
        }
        _logFilePath = Path.Combine(logsDirectoryPath, $"logs_{DateTime.Now.Ticks}.txt");
    }

    void WriteLog(string message)
    {
        using (StreamWriter outputFile = new StreamWriter(_logFilePath))
        {
            outputFile.WriteLine(message);
        }
    }

    [TearDown]
    public void TearDown()
    {
        _graphQLClient.Dispose();
    }

    T SendRequest<T>(string request)
    {
        var graphQLResponse = _graphQLClient.SendQueryAsync<T>(
            new GraphQLRequest {
                Query = request
            }
        ).Result;
        WriteLog(JsonSerializer.Serialize(graphQLResponse));     
        return graphQLResponse.Data;
    }

    [Test]
    public void Test1()
    {
        /*var allFilmsResponse = SendRequest<JObject>("""
            query Query {
                allFilms {
                    films {
                    id 
                    title
                    director
                    releaseDate
                    }
                }
            }
            """);*/
        var allFilmsResponse = SendRequest<JObject>("""
            query Hello {
                hello
            }
            """);
    }
}