## Team name

Ererenderingdering

## Category

Best enhancement to SXA Headless

## Description

**The main goal of our submission is the ability to add JSX code to pages on the fly using rendering variants.**

Headless SXA 10.3 introduced new nice feature - rendering variants. It allows to create different variants of the same rendering. But is is not feature equal if we compare with "classic" SXA. There are few differences:

- it is only possible to add code in JSX/TSX files of your FE application. You can't add code in the rendering variant itself.

- it doesn't have ability to use any templates engine like Scriban. Experience Editors are not able to put HTML onto the page. Even small urgent changes require developers involvement.
  
- you can't scaffold new rendering variant only in a browser.

We decided to make rendering variant more feature equal to "classic" SXA. We decided to add templates engine to rendering variants, because it is the most flexible thing. Everything was possible to do with Scriban. But as we already use React on the frontend, we don't need to use Scriban. We can use JSX templates engine.

### How it works

1. Now each rendering variant has JSX field
![Jsx field](docs/images/JsxField.png?raw=true "Jsx field")
1. This field can containt valid JSX code, similar to React components on the frontend project. It may use Sitecore JSS components `jssImage`, `jssLink`, `Text` and `RichText`. Also you can use `props` and `sitecoreContext` variables.
1. If you fill JSX field then layout service output will be modified. You will get `JSX` as a rendering variant name. And you will get additional `VariantJsx` field.
![Layout Service](docs/images/LayoutService.png?raw=true "Layout Service")
1. If custom output is present in layout service output then custom `Jsx` component will be called by component factory.
1. This component will take JSX template and will pass props and Sitecore context to it.
1. Output will be rendered by React.
1. Solution is content resolver agnosticss. It should work with any content resolvers, including GraphQL or your custom one.

#### Flow diagram
![Flow](docs/images/Flow.png?raw=true "Flow")

## Video link

[Sitecore Hackathon 2023. Ererenderingdering team.](https://www.youtube.com/watch?v=aKrZ11SbV78)

## Pre-requisites and Dependencies


In order to be able to set the module up locally you need the following list of depencencies installed:

1. Windows PowerShell 5.1
2. LTS version of Node.js
3. .NET Core 3.1 SDK or higher
4. .NET Framework 4.8 SDK
5. Visual Studio 2019 or higher
6. Docker for Windows with Windows containers enabled

Also make sure you have the following list of ports free- 443, 8984.

1. Check if you have the Internet Information Server running on port 443:
   Get-Process -Id (Get-NetTCPConnection -LocalPort 443).OwningProcess
   If you do, you must stop it:
   iisreset /stop
2. Check if you have Apache Solr or any other service running on port 8984:
   Get-Process -Id (Get-NetTCPConnection -LocalPort 8984).OwningProcess
   If you do, you must stop it:
   Stop-Service -Name "<the name of your service>"



## Installation instructions

1. In Powershell:
   
   cd (repo folder path)/Ererenderingdering/src/rendering
   npm install
2. cd (repo folder path)/Ererenderingdering/
3. .\init.ps1 -InitEnv -LicenseXmlPath "C:\path\to\license.xml" -AdminPassword "(desired password)" -Topology "xm1"
4. .\up.ps1

Sitecore login screen is going to be opened at the end, fill in Sitecore credentials: login ("admin"), and the password you specified at the 3rd step.

In order to stop and remove running containers: ./down.ps1
In order to clean docker data, database files and index files run the following: ./docker/clean.ps1
This assumes you are placed at (repo folder path)/Ererenderingdering/ path.

## Usage instructions

1. Install environment using provided intstructions. It can be ported to any environment, but it will be easier to use provided environment.
1. Create new rendering variant for any rendering (for example for Image)
1. Fill `Jsx` field with valid `Jsx` code
1. Save rendering variant
1. Open any page in Experience Editor
1. Add component that has rendering variant added in step 2.
1. Select newly created rendering variant
1. Save page 

### Supported JSX syntax

#### Supported JSX components

1. `JssImage` - renders an image from Sitecore media library
  Sample of usage `<JssImage field={props.fields.Image} />`
2. `JssLink` - renders a link from Sitecore
  Sample of usage `<JssLink field={props.fields.Link} />`
3. `Text` - renders a text field from Sitecore
  Sample of usage `<Text field={props.fields.Title} />`
4. `RichText` - renders a rich text field from Sitecore
  Sample of usage `<RichText field={props.fields.Description} />`

#### Available bindings

1. `props` - component props. Allows to access Sitecore fields and other data
   Sample of usage `props.fields.Title`
2. `sitecoreContext` - Sitecore context. Allows to access Sitecore context data. Uses `useSitecoreContext` hook.
   Sample of usage `sitecoreContext.pageEditing` - checks if page is in edit mode.
