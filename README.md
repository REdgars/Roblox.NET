# [Starting on May 22, 2023, api.roblox.com will be deprecated and no longer be reachable, this means that this project too will not be working anymore.](https://devforum.roblox.com/t/sunsetting-apirobloxcom-on-may-22-2023/2324429)

# RobloxNET
 An unofficial asynchronus C# API for interacting with http://api.roblox.com

[![Nuget][nuget-release]][nuget-url]
[![Downloads][nuget-downloads]][nuget-url]
[![License][github-license]][license-url]

## Features
  - Get group information.
  - Get marketplace product information.
  - Get an user's friends information.
  - Get an user's information.
  - Read the [wiki](https://github.com/oshawott9044/Roblox.NET/wiki) for all features.

## Code Examples
___
## Getting information of a group
```cs
using (RobloxGroups robloxGroups = new RobloxGroups()) 
{
   RGroup rGroup = await robloxGroups.GetGroupInfoAsync(1234567890);

   Console.WriteLine("Name: {0}", rGroup.Name);
   Console.WriteLine("First role: {0}", rGroup.Roles[0].Name);
   Console.WriteLine("Owner: {0}", rGroup.Owner.Name);
}
```
## Getting information of a product in the marketplace
```cs
using (RobloxMarketplace robloxMarketplace = new RobloxMarketplace())
{
   RProductInfo productInfo = await robloxMarketplace.GetProductInfoAsync(123456789);

   Console.WriteLine("AssetId: {0}", productInfo.AssetId);
   Console.WriteLine("Price: {0}", productInfo.PriceInRobux);
   Console.WriteLine("Creator: {0}", productInfo.Creator.Name);
}
```
## Getting an users information
```cs
using (RobloxUsers robloxUsers = new RobloxUsers())
{
   RUser rUser = await robloxUsers.GetUserAsync(123456789);
   RUser rUser2 = await robloxUsers.GetUserAsync("username");

   Console.WriteLine("Username: {0}", rUser.Username);
   Console.WriteLine("Id: {0}", rUser2.Id);
}
```

<!-- Markdown link & img dfn's -->
[github-license]:https://img.shields.io/github/license/oshawott9044/RobloxNET.svg
[license-url]:https://github.com/oshawott9044/RobloxNET/blob/master/LICENSE
[nuget-release]:https://img.shields.io/nuget/v/Roblox.NET.svg
[nuget-url]:https://www.nuget.org/packages/Roblox.NET/
[nuget-downloads]:https://img.shields.io/nuget/dt/Roblox.NET.svg
