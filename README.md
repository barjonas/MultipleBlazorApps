### Multiple Blazor Apps sample ###

The project is loosely based on this [Microsoft Learn article](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/multiple-hosted-webassembly?view=aspnetcore-7.0). The article was written for aspnetcore-7.0, but this project is targetted at aspnetcore-8.0. The purpose of the article is to show how one or more Blazor Webassembly project can be hosted within a server project.

## launchsettings.json for reference
Since they don't belong in the git repo, here's the contents of the launchsettings.json file I used for testing:

```
{
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:46492",
      "sslPort": 0
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}",
      "applicationUrl": "http://localhost:5001",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}

```

## What works ##

With the solution loaded and the startup project set to MultipleBlazorApps.Client, *everything* works correctly. Browserlink connects and breakpoints in the client project are bound and hit.

When the startup is switched to MultipleBlazorApps.Server, most things still work, but the breakpoints in the client project are never bound or hit. Eventually a dialog box pops up:

>One or more errors occurred.
>
>Failed to launch debug adapter. Additional information may
>be available in the output window.
>
>Unable to launch browser: "Could not open
>ws://localhost:5001/_framework/debug/ws-proxy?browser=ws
>AFF127.0.0.1A57133FdevtoolsFbrowserF821708ae-b4a5-4a3e-8
>374-682527701ffc"
