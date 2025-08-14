# Freelancing Portfolio Deployment Script
# Run this script to prepare your application for production deployment

Write-Host "?? Preparing Freelancing Portfolio for Deployment..." -ForegroundColor Green

# Step 1: Clean and Restore
Write-Host "?? Cleaning and restoring packages..." -ForegroundColor Yellow
dotnet clean
dotnet restore

# Step 2: Build in Release mode
Write-Host "?? Building application in Release mode..." -ForegroundColor Yellow
dotnet build --configuration Release

# Step 3: Run tests (if any)
Write-Host "?? Running tests..." -ForegroundColor Yellow
dotnet test --configuration Release --no-build

# Step 4: Publish application
Write-Host "?? Publishing application..." -ForegroundColor Yellow
dotnet publish --configuration Release --output ./publish --no-build

# Step 5: Create web.config for IIS
Write-Host "?? Creating web.config for IIS..." -ForegroundColor Yellow
$webConfig = @"
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <location path="." inheritInChildApplications="false">
    <system.webServer>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
      </handlers>
      <aspNetCore processPath="dotnet" 
                  arguments=".\Freelancing.dll" 
                  stdoutLogEnabled="false" 
                  stdoutLogFile=".\logs\stdout" 
                  hostingModel="inprocess" />
      
      <httpProtocol>
        <customHeaders>
          <add name="X-Content-Type-Options" value="nosniff" />
          <add name="X-Frame-Options" value="DENY" />
          <add name="X-XSS-Protection" value="1; mode=block" />
          <add name="Referrer-Policy" value="strict-origin-when-cross-origin" />
        </customHeaders>
      </httpProtocol>
      
      <rewrite>
        <rules>
          <rule name="Redirect to HTTPS" stopProcessing="true">
            <match url=".*" />
            <conditions>
              <add input="{HTTPS}" pattern="off" ignoreCase="true" />
            </conditions>
            <action type="Redirect" url="https://{HTTP_HOST}/{R:0}" redirectType="Permanent" />
          </rule>
        </rules>
      </rewrite>
    </system.webServer>
  </location>
</configuration>
"@

$webConfig | Out-File -FilePath "./publish/web.config" -Encoding UTF8

# Step 6: Create deployment readme
Write-Host "?? Creating deployment instructions..." -ForegroundColor Yellow
$deploymentReadme = @"
# Freelancing Portfolio - Deployment Instructions

## What's Ready for Deployment:
? Application compiled in Release mode
? Production configuration files included
? Security headers configured
? Database migrations ready
? Web.config for IIS deployment included

## Deployment Options:

### Option 1: Shared Hosting (Recommended - $5-10/month)
1. Choose a provider like SmarterASP.NET, HostGator, or GoDaddy
2. Upload contents of 'publish' folder to your hosting provider
3. Update connection string in hosting control panel
4. Run database migration scripts

### Option 2: Azure App Service ($20-35/month)
1. Create Azure App Service
2. Create Azure SQL Database
3. Deploy using Visual Studio or Azure CLI
4. Configure connection strings in Azure portal

## Database Setup:
1. Create a SQL Server database on your hosting provider
2. Update the connection string in your hosting configuration
3. Run the database migration (hosting provider will handle this)

## Security Notes:
?? IMPORTANT: Change admin password from 'admin123' after deployment!
?? Update connection strings with production database details
?? Ensure SSL certificate is configured on your hosting provider

## Admin Access:
- Email: admin@freelancing.com
- Password: admin123 (CHANGE THIS!)

Your freelancing portfolio is ready for the world! ??
"@

$deploymentReadme | Out-File -FilePath "./publish/DEPLOYMENT-README.md" -Encoding UTF8

Write-Host "? Deployment preparation complete!" -ForegroundColor Green
Write-Host ""
Write-Host "?? Your application is ready in the './publish' folder" -ForegroundColor Cyan
Write-Host "?? Check DEPLOYMENT-README.md for detailed instructions" -ForegroundColor Cyan
Write-Host ""
Write-Host "?? Recommended hosting: SmarterASP.NET Basic Plan (~$5/month)" -ForegroundColor Yellow
Write-Host "?? Your portfolio will be live at: https://yourdomain.com" -ForegroundColor Yellow