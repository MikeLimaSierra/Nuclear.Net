param (
    [string]$tfm = $null,
    [string]$ns = $null,
    [string]$asm = $null
)

if(!$tfm -or !$ns -or !$asm) {

Write-Host @"
Usage in project

<Target Condition="'`$(Configuration)' == 'Release'" Name="PostBuild" AfterTargets="PostBuildEvent">
    <Exec Command="C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -ExecutionPolicy RemoteSigned -File &quot;..\publish.ps1&quot; &quot;`$(TargetFramework)&quot; &quot;`$(RootNamespace)&quot; &quot;`$(AssemblyName)&quot;" />
</Target>
"@

exit

}

# setup
$CurrentDir = Get-Item $pwd
$BinDir = [System.IO.DirectoryInfo] [System.IO.Path]::Combine($CurrentDir.Parent.Parent.FullName, "bin", $ns, "AnyCPU", "Release", $tfm)
$PublishDir = [System.IO.DirectoryInfo] [System.IO.Path]::Combine($CurrentDir.Parent.Parent.FullName, "publish", $ns, $tfm)
$Assembly = [System.IO.Path]::Combine($BinDir, -join($asm, ".dll"))
$Files = @('dll','xml','pdb','deps.json')

$SnExe = [System.IO.FileInfo] "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\sn.exe"
$SnKey = [System.IO.Path]::Combine($CurrentDir.Parent.FullName, "KeyPair.snk")

# clean publish dir
"Cleaning: $PublishDir"

if($PublishDir.Exists) {
    $PublishDir.Delete($true)
}

$PublishDir.Create()

# resign assembly
& $SnExe @('-Ra', $Assembly, $SnKey)

# publish
"Publishing output to: $PublishDir"

foreach ($File in $Files) {
    $FilePath = [System.IO.FileInfo] [System.IO.Path]::Combine($BinDir, -join($asm, ".", $File))

    if($FilePath.Exists) {
        "  Copying: $FilePath"
        Copy-Item -Path $FilePath -Destination $PublishDir -Recurse

    } else {
        "  Ignoring: $FilePath"
    }
}

# verify assembly
& $SnExe @('-vf', $Assembly)