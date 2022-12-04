CopyTemplate(@".\template");

static void CopyTemplate(string templateDir)
{
    var workingDir = new DirectoryInfo(".");
    while (workingDir.FullName.Contains(@"\bin"))
        workingDir = workingDir.Parent;

    var dir = workingDir
        .GetDirectories(templateDir)
        .Single();

    if (!dir.Exists)
        throw new DirectoryNotFoundException($"Template directory not found: {dir.FullName}");

    Console.Write("Enter day number: ");
    var day = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(day))
        throw new Exception("Must specify day to continue.");

    CopyDirectory(dir.FullName, workingDir.Parent.FullName, day);

    PatchFile(Path.Combine(workingDir.Parent.FullName, "2022", "MainPage.xaml.cs"), "// new using goes here", $"using _{day};\r\n// new using goes here");
    PatchFile(Path.Combine(workingDir.Parent.FullName, "2022", "MainPage.xaml.cs"), "// new day goes here", $"RegisterDay({day}, new Day{day}());\r\n        // new day goes here");
    PatchFile(Path.Combine(workingDir.Parent.FullName, "2022", "2022.csproj"), "<!-- New ProjectReference Goes Here -->", $"<ProjectReference Include=\"..\\{day}\\{day}.csproj\" />\r\n    <!-- New ProjectReference Goes Here -->");
    PatchFile(Path.Combine(workingDir.Parent.FullName, "2022.sln"), "\r\nGlobal\r\n", $"\r\nProject(\"{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}\") = \"{day}\", \"{day}\\{day}.csproj\", \"{{{Guid.NewGuid().ToString().ToUpper()}}}\"\r\nEndProject\r\nProject(\"{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}\") = \"{day}.Tests\", \"{day}.Tests\\{day}.Tests.csproj\", \"{{{Guid.NewGuid().ToString().ToUpper()}}}\"\r\nEndProject\r\nGlobal\r\n");
}

static void CopyDirectory(string sourceDir, string destDir, string day)
{
    var dir = new DirectoryInfo(sourceDir);
    string destinationDir = destDir.Replace("{X}", day);

    if (destDir.Contains("{X}") && Directory.Exists(destinationDir))
        throw new Exception($"Aborting, files already exist in {destinationDir}");

    Console.WriteLine($"Creating {destinationDir}");
    Directory.CreateDirectory(destinationDir);

    foreach (FileInfo file in dir.GetFiles())
    {
        string targetFilePath = Path.Combine(destinationDir, file.Name.Replace("{X}", day).Replace(@".\template", @".."));
        Console.WriteLine($"Copying template to {targetFilePath}");
        var content = File.ReadAllText(file.FullName);
        content = content.Replace("{X}", day);
        File.WriteAllText(targetFilePath, content);
    }

    DirectoryInfo[] dirs = dir.GetDirectories();
    foreach (DirectoryInfo subDir in dirs)
    {
        string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
        CopyDirectory(subDir.FullName, newDestinationDir, day);
    }
}

static void PatchFile(string fileName, string oldValue, string newValue)
{
    Console.WriteLine($"Updating file {fileName}");
    var content = File.ReadAllText(fileName);
    content = content.Replace(oldValue, newValue);
    File.WriteAllText(fileName, content);
}
