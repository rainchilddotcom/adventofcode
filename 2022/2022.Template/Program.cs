CopyTemplate(@".\template", "5");

static void CopyTemplate(string templateDir, string day)
{
    var workingDir = new DirectoryInfo(".");
    while (workingDir.FullName.Contains(@"\bin"))
        workingDir = workingDir.Parent;

    var dir = workingDir
        .GetDirectories(templateDir)
        .Single();

    if (!dir.Exists)
        throw new DirectoryNotFoundException($"Template directory not found: {dir.FullName}");

    CopyDirectory(dir.FullName, workingDir.Parent.FullName, day);
}

static void CopyDirectory(string sourceDir, string destDir, string day)
{
    var dir = new DirectoryInfo(sourceDir);
    string destinationDir = destDir.Replace("{X}", day);

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
