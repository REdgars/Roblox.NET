# RobloxNET
 An unofficial asynchronus C# API for interacting with http://api.roblox.com

[![License][github-license]][license-url]

## Features
  - Get group information.
  - Get marketplace product information.
  - Get an user's friends information.
  - Get an user's information.

## Code Examples
___
## Getting information of a group
```cs
RobloxGroups robloxGroups = new RobloxGroups();
RGroup rGroup = await robloxGroups.GetGroupInfoAsync(1234567890);

Console.WriteLine("Name: {0}", rGroup.Name);
Console.WriteLine("First role: {0}", rGroup.Roles[0].Name);
Console.WriteLine("Owner: {0}", rGroup.Owner.Name);
```
## Getting information of a product in the marketplace
```cs
RobloxMarketplace robloxMarketplace = new RobloxMarketplace();
RProductInfo productInfo = await robloxMarketplace.GetProductInfoAsync(123456789);

Console.WriteLine("AssetId: {0}", productInfo.AssetId);
Console.WriteLine("Price: {0}", productInfo.PriceInRobux);
Console.WriteLine("Creator: {0}", productInfo.Creator.Name);
```
## Getting an users information
```cs
RobloxUsers robloxUsers = new RobloxUsers();
RUser rUser = await robloxUsers.GetUserAsync(123456789);
RUser rUser2 = await robloxUsers.GetUserAsync("username");

Console.WriteLine("Username: {0}", rUser.Username);
Console.WriteLine("Id: {0}", rUser2.Id);
```

<!-- Markdown link & img dfn's -->
[github-license]:https://img.shields.io/github/license/oshawott9044/RobloxNET.svg
[license-url]:https://github.com/oshawott9044/RobloxNET/blob/master/LICENSE
