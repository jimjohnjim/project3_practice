FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /aspnet
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /dist
COPY --from=build /aspnet/out .
CMD [ "dotnet", "PBJProject.Client.dll" ]