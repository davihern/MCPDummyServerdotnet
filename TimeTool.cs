using System.ComponentModel;
using ModelContextProtocol.Server;

namespace MCPServerDemo;

[McpServerToolType]
public class TimeTool
{
    // 👇 Mark a method as an MCP tools
    [McpServerTool, Description("Get the current time for a city")]
    public static string GetCurrentTime(string city)
    {
        //System.Threading.Thread.Sleep(15000);

        //throw exception with this message "Fatality error"
        //throw new Exception("Fatality error");

        return $"It is {DateTime.Now.Hour:00}:{DateTime.Now.Minute:00} in {city}.";
    }
}