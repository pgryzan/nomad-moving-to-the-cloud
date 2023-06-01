# HashiCups

Unfortunately, we could not use the HashiCups applications provided in it's original state because the application fairly homogeneous and a Nomad demo shows better with hetrogeneous components. 
Therefore we have decided to port several pieces of the application to other technologies / languages. The following code base is a blend of existing an new ported components for the HashiCups application.

- product-api-go (Go / Docker)
- frontend (Go / Docker)
- payments (Java / Redis / Postgres / Podman)
- hashicups-client-go (DynamicSQL)
- infrastructure (Go / Docker)
- public-api (C# / IIS / SQL Server / Windows)
- traffic-simulation (Go / Docker)
