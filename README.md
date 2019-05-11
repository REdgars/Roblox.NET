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
## Getting Information of a Group
```cs
RobloxGroups robloxGroups = new RobloxGroups();
RGroup rGroup = await robloxGroups.GetGroupInfoAsync(1234567890);

Console.WriteLine(rGroup.Name);
Console.WriteLine(rGroup.Roles[0].Name);
Console.WriteLine(rGroup.Owner.Name);
```
