# LocalIMDS
Runs a local IMDS endpoint emulator which is served by Azure.Identity credentials


## Setup

- Create a dotnet image with an application that relies on `DefaultAzureCredential` for auth.
- Start this web app on the host machine.
- Run the following command to start the container: `docker run -it --rm -e AZURE_POD_IDENTITY_AUTHORITY_HOST="http://host.docker.internal:9292" <your_image_name>`

Note: the port can be configured via `appsettings.json`, it just needs to match the port specified in the `docker run` command.
