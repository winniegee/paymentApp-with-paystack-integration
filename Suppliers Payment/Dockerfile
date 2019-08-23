FROM microsoft/aspnetcore-build AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build AS build
WORKDIR /src
COPY *.sln ./
COPY Suppliers Payment/Suppliers_Payment_web.csproj Suppliers Payment/
COPY Interfaces/Providers.csproj Interfaces/
COPY Models/Models.csproj Models/
COPY HelperClass/HelperClass.csproj HelperClass/
COPY Infrastructuree.Data/Infrastructuree.Data.csproj Infrastructuree.Data/
COPY Domain.Entities/Domain.Entities.csproj Domain.Entities/
COPY Domain.Interface/Domain.Interface.csproj Domain.Interface/
RUN dotnet restore
COPY . .
WORKDIR /src/Suppliers Payment
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Suppliers_Payment_web.dll"]
 