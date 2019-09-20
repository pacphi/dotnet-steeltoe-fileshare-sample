# Dotnet with Steeltoe File sharing example


## Use cases

Based upon a modified Steeltoe document sample [here](https://steeltoe.io/docs/steeltoe-smb/).

* Dotnet Core (ASP.Net Core), inside `src/AspNetCore/SMBFileShares`
* Dotnet Framework (ASP.Net 4.6.1), inside `src/AspNet4/NetworkFileShares4x/SMBFileShares4x`


## Prerequisites

* Pivotal Application Service for Windows 2.4 or better
* Visual Studio Community Edition 2019 or better
* Dotnet Framework SDK 4.6.1 or better
* Dotnet Core SDK 2.2.401 or better
* CF CLI 6.46.1 or better

## How to clone

Create a top-level folder underneath your `C:` drive named `workspaces`

```
cd C:\workspaces
git clone https://github.com/pacphi/dotnet-steeltoe-fileshare-sample
```


## How to demo

Open Powershell

### Build AspDotNetCore

```
cd C:\workspaces\dotnet-steeltoe-fileshare-sample\src\AspNetCore\SMBFileShares
dotnet publish -f netcoreapp2.2 -r win10-x64
```

### Build AspDotNet Framework

```
cd C:\workspaces\dotnet-steeltoe-fileshare-sample\src\AspNet4\NetworkFileShares4x
```

* Open the `.sln` file in Visual Studio 2019 Community Edition
* Right click on project, then select `Publish`
  * You will need to set the path to `bin/Debug/net461/win10-x64/publish`

### Connect and target a foundation

```
cf login -a {api-endpoint}
cf t -o {org} -s {space}
```

### Create Credhub instance

```
cd C:\workspaces\dotnet-steeltoe-fileshare-sample
.\scripts\cf-create-service.ps1
```
> you will need to pass in arguments to override the defaults in script above

### Push AspDotNetCore

```
cd C:\workspaces\dotnet-steeltoe-fileshare-sample\src\AspNetCore\SMBFileShares
cf push -f manifest-windows.yml -p bin/Debug/netcoreapp2.2/win10-x64/publish
```
> this will push to Windows 2016 stack

### Push ASPDotNet Framework

```
cd C:\workspaces\dotnet-steeltoe-fileshare-sample\src\AspNet4\NetworkFileShares4x\SMBFileShares4x
cf push -f manifest-windows.yml -p bin/Debug/net461/win10-x64/publish
```
> this will push to Windows 2016 stack


### Optional

#### Deployment to windows2012R2 stack (if available)

```
cf push -f manifest-windows.yml -p bin/Debug/net461/win10-x64/publish -s windows2012R2 smbfileshares4x-2012R2
```
