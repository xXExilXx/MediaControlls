using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(MediaControlls.BuildInfo.Description)]
[assembly: AssemblyDescription(MediaControlls.BuildInfo.Description)]
[assembly: AssemblyCompany(MediaControlls.BuildInfo.Company)]
[assembly: AssemblyProduct(MediaControlls.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + MediaControlls.BuildInfo.Author)]
[assembly: AssemblyTrademark(MediaControlls.BuildInfo.Company)]
[assembly: AssemblyVersion(MediaControlls.BuildInfo.Version)]
[assembly: AssemblyFileVersion(MediaControlls.BuildInfo.Version)]
[assembly: MelonInfo(typeof(MediaControlls.MediaControlls), MediaControlls.BuildInfo.Name, MediaControlls.BuildInfo.Version, MediaControlls.BuildInfo.Author, MediaControlls.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]