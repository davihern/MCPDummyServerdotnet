# MCPDummyServerdotnet

This repository contains a minimal .NET server that exposes a Server-Sent Events (SSE) endpoint.

## Prerequisites

- .NET SDK (the project targets `net9.0` — install the matching SDK/runtime if needed)

## Run the project

1. Open a terminal in the project root (where `MCPServerDemo.csproj` is located).
2. Run the app with:

   dotnet run

3. After the app starts it will print the listening URLs to the console (for example `Now listening on: http://localhost:5112`). The SSE endpoint is available at:

   http://localhost:<port>/sse

   Replace `<port>` with the port number shown in the console output.

## Test the SSE endpoint

- Using curl (keep the connection open for streaming):

  curl http://localhost:<port>/sse -N


## Expose to the internet with ngrok (HTTPS)

You can use ngrok to create a public HTTPS tunnel to your local app so the SSE endpoint is reachable from the internet.

1. Install ngrok from https://ngrok.com and add your authtoken (recommended):

   ngrok config add-authtoken  <YOUR_AUTHTOKEN>

2. Start your app on a known port. For example (PowerShell):

   $env:ASPNETCORE_URLS = "http://localhost:5112"; dotnet run

   Replace 5112 with the port your app is configured to use. If you already see the port in the console output, use that.

3. Start ngrok to forward that port (in a separate terminal):

   ngrok http http://localhost:5112

   ngrok will show a public HTTPS forwarding URL, for example:

   https://abcd-1234.ngrok-free.app -> http://localhost:5112

4. Use the public HTTPS URL plus the `/sse` path to access the SSE endpoint from the internet:

   https://<your-ngrok-host>/sse

Notes:
- If you will be using the endpoint from a webpage served over HTTPS, use the ngrok HTTPS URL (EventSource requires a secure context when loaded from an HTTPS page).
- If your app is running on a different port, replace `5112` with the correct port shown by `dotnet run`.

## Notes

- When running from Visual Studio the port may be defined in `Properties/launchSettings.json` — use whatever port is being used by Kestrel/IIS Express.
- If you need a fixed port, set the `ASPNETCORE_URLS` environment variable before running, or configure the URLs in `appsettings.json` / the host configuration.
