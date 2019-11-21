param($installPath, $toolsPath, $package, $project)
	Write-Output "Parameters :"
	Write-Output $installPath
	Write-Output $toolsPath
	Write-Output $package.Id
	Write-Output $package.Version
	Write-Output $project.Name
	
	Write-Output "Removing old Plugin targets from " $project.Name
	
 
	# Need to load MSBuild assembly if it’s not loaded yet.
	Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
	Write-Output "loaded Microsoft.Build"

	# Grab the loaded MSBuild project for the project
	$msbuildproject = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

	#scan for imports to the plugin framework
	$PluginImports = $msbuildproject.Xml.Imports | Where-Object { $_.Project.Endswith('Sdl.Core.PluginFramework.Build.targets') }
	
	if($PluginImports -isnot [system.array]) { $PluginImports = @($PluginImports)} # cooerce to array type

	foreach ($NotableImport in $PluginImports)
	{
		if (-Not ($NotableImport.Project.Contains($package.Version)))
		{ 
			Write-Output 'Deleting import ' $NotableImport.Project
			$msbuildproject.Xml.RemoveChild($NotableImport) | out-null
		}
	}
	
	$project.Save()
	Write-Output "Complete"