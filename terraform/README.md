# terraform / gcp

I created this Terraform configuration for development purposes. You have 3 OS' that you can try you ideas out on, Windows, Ubuntu and Centos.

The three clients are connected to an Ubuntu server that has Consul, Vault and Nomad Enterprise running

## Windows Development Environment

General Environment Setup:
- RDP into the Windows client using the credentials you provided in the **"info"** variable of your variables.tfvars flie. Microsoft makes RDP clients for every platform located [here](https://docs.microsoft.com/en-us/windows-server/remote/remote-desktop-services/clients/remote-desktop-clients).
- Install Chrome. I would set Chrome as you default browser when it asks.
- Use git clone to pull down the repo from the command line or powershell. Powershell has more BASH type commands. You can put this anywhere and navigate to it.
- You may have to extend the drive space out especially after installing Visual Studio. An easy way to do so is to type Computer Management in the search box on the taskbar, select and hold (or right-click) Computer Management, and then select Run as administrator > Yes. After Computer Management opens, go to Storage > Disk Management.
- Select and hold (or right-click) the volume that you want to extend, and then select Extend Volume.

### Build and Deploy the SQL Server Express Database

In order to use the SQL Server Express database for the HashiCups application, need to build it in Docker. Those files can be located in the "docker" folder of the GitHub repo you pulled down.

Steps to build the database:
- Open powershell under administrator and navigate over to the "repo/docker/sqlserver-express" folder. In there you will find the docker build files to create a sqlserver-express container.
- Open chrome and take a look at the latest versions of the Windows Containers available [here](https://hub.docker.com/_/microsoft-windows-servercore). The image you select has to match the image of the host machine. I'm currently using the ltsc2019 which pulls the latest match for the Windows 2019 image you are developing with. The pulled version will be in the "dockerfile".
- From the powershell cli, run
```
"docker build -t <your dockerhub name>/sqlserver-express:<tag> .". 
```
My suggestion is to use something like date (20210506) for the tag. That way you can pull down the right version for the product-db build. This will take 5 to 10 minutes to build.
- Login and push this image to you Docker Hub account.
- Next, navigate over to the "repo/docker/product-db" folder.
- Update the dockerfile to the new tagged image you just created.
- From the powershell cli, run
```
"docker build -t <your dockerhub name>/product-db:<tag> .". 
```
- This goes pretty quick. After completion, push the image to your Docker Hub repo.
- Your ready to deploy the new database container. Navigate over the "repo/jobs" folder and open the product-db.nomad file.
- Update the image name in the middle of the job spec to the one you created. In addition, update the "repo/instruqt/nomad-moving-to-the-cloud/redeploy/setup-on-prem-server" and "packer/framework.pkr.hcl files as well.
- Open the Nomad UI located at the url that Terraform output.
- Click on "Run Job" and copy / paste the job specification into the editor and click plan and then run.
- It should fire up pretty fast and Nomad will confirm that it's running and healthy.

### ASP.NET Environment

There two ASP.NET application created that may need to be maintained over time, legacy-app and product-api. The endpoints should look idetical the HashiCups container endpoints when deployed.

The variety of deployment types highlight the power of Nomad.

Steps to setup the environment:
- Install latest version of Visual Studio Professional on the client.
- Before it installs, it will ask you what type of workloads you want to install. Select "ASP.NET and web development" and "Data storage and processing", and start the installation. This takes a bit.
- When it's finished installing , bypass creating an account and select "Open a project or solution" under the "Getting started" menu. You can close the installer.
- Navigate to where you put the repo and open the "hashicups" folder. Select the "hashicups.sln" file to open. The is the workspace or solution file for both projects.
- It's going to ask if you trust the projects, just uncheck the "verify each project" checbox and click OK.
- Before you ca start working you have to install the packages. While this sounds simple it's not straight forward. From the Toolbar at the top, navigate down to "Tools > NuGet Package Manager > Package Manager Settings".
- Click on "Package Sources" and then on the plus sign at the top to add a new package source.
- Next to the "Name" field add "nuget.org". Next to the "Source" field, add "https://api.nuget.org/v3/index.json". Click OK to close.
- To build either project you can right click on the project and click "Build".
- To update the packages to the latest, right click on the project and select "Manage Nuget Packages...". This will take you to a screen to install the updates.
- Once you have made your changes and everything is working the way you want, it time to publish. To publish the project, right click on the project name and select "Publish".
- The complide files you need will to put in a zip file will be located at "repo/hashicups/<project name>/bin/app.publish/"
- Navigate to that directory and zip up all the files in that directory.
- Save the zip files somewhere where they can be accessed by Nomad.
- Before pushing the repo back to GitHub delete the obj and bin folders from each project. Delete the packages and .vs folders from the hashicups directory.
- Push the entire repo back to GitHub