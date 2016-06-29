[System.Net.WebRequest]::DefaultWebProxy.Credentials = [System.Net.CredentialCache]::DefaultCredentials
$BaseDirectory = $PSScriptRoot + "\..\..\"
$octokitPath = $BaseDirectory + "CodeBlacks\packages\Octokit.0.20.0\lib\net45\Octokit.dll"
Add-Type -Path $octokitPath
$productHeaderValue = New-Object Octokit.ProductHeaderValue -ArgumentList "code-blacks"
$client = New-Object Octokit.GitHubClient -ArgumentList $productHeaderValue
$client.Credentials = New-Object Octokit.Credentials -ArgumentList "580f8cc884af895011cbdf0ce2ab98d59c24e244"
$refTask = $client.Git.Reference.Get("jeremybeavon", "CodeBlacks-Presentation-Release", "heads/master")
$treeTask = $client.Git.Tree.Get("jeremybeavon", "CodeBlacks-Presentation-Release", $refTask.Result.Object.Sha)
$newReleasePackageBlob = New-Object Octokit.NewBlob
$newReleasePackageBlob.Content = [System.Convert]::ToBase64String([System.IO.File]::ReadAllBytes($BaseDirectory + "ReleasePackage.zip"))
$newReleasePackageBlob.Encoding = [Octokit.EncodingType]::Base64
$createReleasePackageBlob = $client.Git.Blob.Create("jeremybeavon", "CodeBlacks-Presentation-Release", $newReleasePackageBlob)
$newPublishPackageBlob = New-Object Octokit.NewBlob
$newPublishPackageBlob.Content = [System.Convert]::ToBase64String([System.IO.File]::ReadAllBytes($BaseDirectory + "PublishPackage.zip"))
$newPublishPackageBlob.Encoding = [Octokit.EncodingType]::Base64
$createPublishPackageBlob = $client.Git.Blob.Create("jeremybeavon", "CodeBlacks-Presentation-Release", $newPublishPackageBlob)
$newReleasePackageTreeItem = New-Object Octokit.NewTreeItem
$newReleasePackageTreeItem.Path = "ReleasePackage.zip"
$newReleasePackageTreeItem.Mode = "100644"
$newReleasePackageTreeItem.Type = "blob"
$newReleasePackageTreeItem.Sha = $createReleasePackageBlob.Result.Sha
$newPulishPackageTreeItem = New-Object Octokit.NewTreeItem
$newPulishPackageTreeItem.Path = "PublishPackage.zip"
$newPulishPackageTreeItem.Mode = "100644"
$newPulishPackageTreeItem.Type = "blob"
$newPulishPackageTreeItem.Sha = $createPublishPackageBlob.Result.Sha
$newTree = New-Object Octokit.NewTree
$newTree.BaseTree = $refTask.Result.Object.Sha
$newTree.Tree.Add($newReleasePackageTreeItem)
$newTree.Tree.Add($newPulishPackageTreeItem)
$createTreeTask = $client.Git.Tree.Create("jeremybeavon", "CodeBlacks-Presentation-Release", $newTree)
$newCommit = New-Object Octokit.NewCommit -ArgumentList "Update release packages", $createTreeTask.Result.Sha, $refTask.Result.Object.Sha
$createCommitTask = $client.Git.Commit.Create("jeremybeavon", "CodeBlacks-Presentation-Release", $newCommit)
$referenceUpdate = New-Object Octokit.ReferenceUpdate -ArgumentList $createCommitTask.Result.Sha
$client.Git.Reference.Update("jeremybeavon", "CodeBlacks-Presentation-Release", "heads/master", $referenceUpdate)