# Script for deploying and configuring a WebJob to execute daily
# Created by: Fernando de Oliveira

# Environment constants
$webAppName = "MyWebAppName"
$location = "West US"
$jobName = "DailyJobTest"
$jobCollectionName = "MyJobCollectionName"

$webApp = Get-AzureWebsite -Name $webAppName;
$webJob = New-AzureWebsiteJob -Name $webApp.Name -JobName $jobName -JobType Triggered -JobFile ~\MyWebJob.zip;
$jobCollection = New-AzureSchedulerJobCollection -Location $location -JobCollectionName $jobCollectionName;

New-AzureSchedulerHttpJob -JobCollectionName $jobCollectionName -JobName $jobName -Method POST -URI "$($webJob.Url)\run" -Location $location -StartTime "2016-09-12" -EndTime "2016-09-30" -Interval 1 0-Frequency Day