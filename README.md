## Team name

⟹ Ererenderingdering



## Category

⟹ -   Best enhancement to SXA Headless



## Description

⟹ Write a clear description of your hackathon entry. TO BE DONE.



- Module Purpose

- What problem was solved (if any)

- How does this module solve it



_You can alternately paste a [link here](#docs) to a document within this repo containing the description._



## Video link

⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_



⟹ [Replace this Video link](#video-link)





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

⟹ Provide documentation about your module, how do the users use your module, where are things located, what do the icons mean, are there any secret shortcuts etc.



Include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:



![Hackathon Logo](docs/images/hackathon.png?raw=true  "Hackathon Logo")



You can embed images of different formats too:



![Deal With It](docs/images/deal-with-it.gif?raw=true  "Deal With It")



And you can embed external images too:



![Random](https://thiscatdoesnotexist.com/)



## Comments

If you'd like to make additional comments that is important for your module entry.