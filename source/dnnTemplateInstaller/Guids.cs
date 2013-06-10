// Guids.cs
// MUST match guids.h
using System;

namespace DotNetNukeCorp.dnnTemplateInstaller
{
    static class GuidList
    {
        public const string guiddnnTemplateInstallerPkgString = "508b8bba-9532-4d31-b141-e9dc6ef59bae";
        public const string guiddnnTemplateInstallerCmdSetString = "f09483b1-9c4a-40c0-880e-0cb04862ba43";

        public static readonly Guid guiddnnTemplateInstallerCmdSet = new Guid(guiddnnTemplateInstallerCmdSetString);
    };
}