# RobloxNET
 An unofficial asynchronus C# API for interacting with http://api.roblox.com

**Please note, that this is still not finished yet, some features like getting users and more are missing.**

## Features
  - Get group information.
  - Get marketplace product information.
  - Get an users friends information.
  - more to come.

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
## Getting Information of a product in the marketplace
```cs
RobloxMarketplace robloxMarketplace = new RobloxMarketplace();
RProductInfo productInfo = await robloxMarketplace.GetProductInfoAsync(123456789);

Console.WriteLine("AssetId: {0}", productInfo.AssetId);
Console.WriteLine("Price: {0}", productInfo.PriceInRobux);
Console.WriteLine("Creator: {0}", productInfo.Creator.Name);
```
