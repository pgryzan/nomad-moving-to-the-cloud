**Demo Hackathon 2020 Nomad**

## Folder Descriptions
- .circleci - CircleCI workflow of nightly build and testing of the instruqt track.
- docker - Definitions for the Windows based sqlserver-express and product-db containers.
- hashicups - ASP.NET Legacy Application and Product API projects with Visual Studion Pro solution.
- instruqt - Instruqt track
- packer - Packer build definitions for four images, framework-server, framework-docker, framework-podman and framework-windows. All images are reusable and contain thier own configuration script.
- terraform - Definition of a Terraform / GCP workspace for development and testing before placing into Instruqt.

## Workflow
- Build The images in your environment.
- Fire up the Terraform workspace and develop / test.
- Make changes and possibly rebuild if nessecary.
- Create new images out in Instruqt
- Use images and code from testing with Terraform to create tracks.