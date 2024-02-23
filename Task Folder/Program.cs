using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// SETUP 
const string myPersonalID = "198aa4ab2a4bf1b2cd6e55676663bc5ce2196dd1bcef49d6efe68fff9db26218"; // GET YOUR PERSONAL ID FROM THE ASSIGNMENT PAGE https://mm-203-module-2-server.onrender.com/
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/"; // baseURl + startEndpoint + myPersonalID
const string taskEndpoint = "task/";   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
// We start by registering and getting the first task
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); // Print the response from the server to the console
string taskID = "psu31_4"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

//#### FIRST TASK 
// Fetch the details of the task from the server.
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Console.WriteLine(task1Response);

// ANSWER TO FIRST TASK
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);

string[] parameter = task1?.parameters.Split(',');
int sum = 0;
foreach (string integers in parameter)
{
    if (int.TryParse(integers, out int totalValue))
    {
        sum += totalValue;
    }
}

string Result = sum.ToString();

Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, Result);

Console.WriteLine($"Answer: {Colors.Green}{task1AnswerResponse}{ANSICodes.Reset}");



//SECOND TASK
taskID = "aAaa23"; 

Console.WriteLine("\n-----------------------------------\n");
Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Console.WriteLine(task2Response);

//ANSWER TO SECOND TASK
Task task2 = JsonSerializer.Deserialize<Task>(task2Response.content);

double fahrenheit = double.Parse(task2.parameters);
double FahrenheitToCelsiusFormula = (fahrenheit - 32) * 5/9;

string Result2 = FahrenheitToCelsiusFormula.ToString("0.00");

Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, Result2);

Console.WriteLine($"Answer: {Colors.Green}{task2AnswerResponse}{ANSICodes.Reset}");

// THIRD TASK
taskID = "otYK2";

Console.WriteLine("\n-----------------------------------\n");








class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}