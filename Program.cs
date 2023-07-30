// See https://aka.ms/new-console-template for more information
using IronPython.Hosting;

// Pre
var engine = Python.CreateEngine();
var scope = engine.CreateScope();

for (var i = 0; i < 10_000; i++) // add 10,000 random variable
    scope.SetVariable($"variable{i}", Convert.ToDecimal(Random.Shared.NextDouble() * 100));
scope.SetVariable("result", false);
// Script
var script = $"if variable10 < 50:{Environment.NewLine}" +
             $" print('Variable 10 is ' + str(variable10))";

var functionalScript = "def main():" + Environment.NewLine +
                       "    result=true" + Environment.NewLine +
                       "    if variable10 < 50:" + Environment.NewLine +
                       "        return 'true'";

var functionalScript2 = "def main():" + Environment.NewLine +
                        "    return 'xxxx'";
var functionalScript3 =
    "import random\r\n\r\nv1=random.randint(0,100)\r\nv2=random.randint(0,100)\r\nv3=random.randint(0,100)\r\nv4=random.randint(0,100)\r\nv5=random.randint(0,100)\r\nv6=random.randint(0,100)\r\nv7=random.randint(0,100)\r\nv8=random.randint(0,100)\r\nv9=random.randint(0,100)\r\nresult=0\r\n\r\ndef main():\r\n    result = (v1+v2+v3+v4+v5+v6+v7+v8+v9)/9\r\n    return result";
var functionalScript4 =
    "v1=100\r\nv2=724\r\nv3=543\r\nv4=123\r\nv5=25\r\nv6=62\r\nv7=23\r\nv8=245\r\nv9=32\r\nresult=0\r\n\r\ndef main():\r\n    result = (v1+v2+v3+v4+v5+v6+v7+v8+v9)/9\r\n    return result";

// Execute script

var result = engine.Execute(functionalScript4, scope);
dynamic main = scope.GetVariable("main");
var sss = main();

Console.ReadKey();