# ?? Freelancing Portfolio - Professional Website

A modern, responsive freelancing portfolio website built with ASP.NET Core 8 and Razor Pages. Features a complete admin panel for managing services, payments, and client inquiries.

## ? Features

### ?? Public Website
- **Modern Design**: Clean, professional layout with purple gradient theme
- **Responsive**: Works perfectly on desktop, tablet, and mobile devices
- **Service Showcase**: Display your freelancing services with pricing
- **Contact Forms**: Let clients reach out and request quotes
- **Payment Requests**: Clients can submit payment requests for services

### ??? Admin Dashboard
- **Secure Login**: Cookie-based authentication with security headers
- **Service Management**: Create, edit, delete, and manage your services
- **Payment Tracking**: View and update payment request statuses
- **User Management**: Monitor client registrations and inquiries
- **Analytics**: Real-time business insights and statistics
- **Mobile-Friendly**: Responsive admin panel that works on all devices

### ?? Security Features
- HTTPS enforcement
- Secure cookie configuration
- XSS protection
- CSRF protection
- Security headers (HSTS, X-Frame-Options, etc.)
- Production-ready configuration

## ?? Quick Start

### Prerequisites
- .NET 8 SDK
- SQL Server or SQL Server Express
- Visual Studio 2022 or VS Code

### Local Development
1. **Clone and setup**git clone <your-repo>
cd Freelancing
dotnet restore
2. **Database setup**dotnet ef database update
3. **Run the application**dotnet run
4. **Access the application**
   - Public site: `https://localhost:7xxx`
   - Admin login: `https://localhost:7xxx/Account/Login`
   - Admin credentials: `admin@freelancing.com` / `admin123`

## ?? Deployment

### Ready for Production!
Your application includes everything needed for professional hosting:

### Option 1: Shared Hosting (Recommended - $5-10/month)
**Best for**: Small to medium freelancing businesses  
**Providers**: SmarterASP.NET, HostGator, GoDaddy# Run deployment script
.\deploy.ps1
### Option 2: Azure App Service ($20-35/month)
**Best for**: Growing businesses needing scalability# Deploy to Azure
az webapp up --name your-app-name --resource-group your-rg
### Option 3: VPS/Dedicated Server ($10-50/month)
**Best for**: Full control and customization needs

## ??? Project Structure
Freelancing/
??? Models/
?   ??? User.cs              # User and admin accounts
?   ??? Service.cs           # Freelancing services
?   ??? Payment.cs           # Payment requests
?   ??? FreelancingDbContext.cs
??? Pages/
?   ??? Account/             # Authentication
?   ??? Admin/               # Admin dashboard
?   ?   ??? Services/        # Service management
?   ?   ??? Payments/        # Payment management
?   ?   ??? Users/           # User management
?   ??? Services/            # Public service pages
?   ??? Index.cshtml         # Homepage
?   ??? About.cshtml         # About page
?   ??? Contact.cshtml       # Contact page
??? wwwroot/
?   ??? css/site.css         # Custom styles
?   ??? js/site.js           # Enhanced interactions
??? Migrations/              # Database migrations
??? deploy.ps1               # Deployment script
## ?? Customization

### Branding
- Update `Pages/Shared/_Layout.cshtml` for navigation and footer
- Modify `wwwroot/css/site.css` for colors and styling
- Replace logo and favicon in `wwwroot/` folder

### Services
- Add/edit services through admin panel
- Update service types in create/edit forms
- Customize pricing and descriptions

### Content
- Update About page with your information
- Customize contact information
- Add your portfolio examples

## ?? Sample Services Included
- Custom Web Application ($500)
- E-commerce Store ($1,200)
- Mobile Application ($800)

## ?? Technical Details

### Built With
- **Framework**: ASP.NET Core 8.0
- **UI**: Razor Pages + Bootstrap 5
- **Database**: Entity Framework Core + SQL Server
- **Authentication**: Cookie-based with security enhancements
- **Styling**: Custom CSS with modern gradients and animations

### Performance Features
- Optimized CSS and JavaScript
- Responsive images
- Fast loading times
- SEO-friendly structure

## ?? Support & Customization

This professional portfolio is ready to showcase your freelancing business. For custom modifications or additional features, consider hiring a developer familiar with ASP.NET Core.

## ?? License

This project is for professional portfolio and commercial use.

---

**Ready to launch your freelancing business online?** ??  
Follow the deployment guide and your professional portfolio will be live in minutes!