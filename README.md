# 💼 Freelancing Portfolio

A modern freelancing portfolio and business management system built with **ASP.NET Core 8** and **Razor Pages**.

![.NET 8](https://img.shields.io/badge/.NET-8.0-purple) ![Bootstrap](https://img.shields.io/badge/Bootstrap-5.0-purple) ![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-orange)

## ✨ Features

**Public Website:**
- Professional service showcase with pricing
- Responsive design (mobile-friendly)
- Contact forms and payment requests
- Modern purple gradient theme

**Admin Dashboard:**
- Service management (CRUD operations)
- Payment request tracking
- Client management
- Business analytics
- Secure authentication

## 🛠️ Tech Stack

- **ASP.NET Core 8.0** - Web framework
- **Razor Pages** - Page-focused architecture
- **Entity Framework Core 9.0** - Database ORM
- **SQL Server** - Database
- **Bootstrap 5** - CSS framework
- **jQuery** - JavaScript library

## 🚀 Quick Start

1. **Prerequisites:** .NET 8 SDK, SQL Server
2. **Setup:**git clone <repo-url>
cd Freelancing
dotnet restore
dotnet ef database update
   dotnet run3. **Access:**
   - Website: `https://localhost:7xxx`
   - Admin: `https://localhost:7xxx/Account/Login`
   - Login: `admin@freelancing.com` / `admin123`

## 📁 Project Structure
Freelancing/
├── Models/           # Data models (User, Service, Payment)
├── Pages/            # Razor Pages
│   ├── Admin/        # Admin dashboard
│   ├── Services/     # Public service pages
│   └── Account/      # Authentication
├── Migrations/       # Database migrations
├── wwwroot/         # Static files (CSS, JS)
└── deploy.ps1       # Deployment script
## 🌐 Deployment

**Quick Deploy:**.\deploy.ps1
**Hosting Options:**
- **Shared Hosting** ($5-10/month) - SmarterASP.NET, HostGator
- **Azure App Service** ($20-35/month) - Professional scaling
- **VPS** ($10-50/month) - Full control

## 🔒 Security

- HTTPS enforcement
- Secure cookies
- XSS/CSRF protection
- Input validation
- SQL injection protection

## 🎯 Key Files

- `Program.cs` - App configuration
- `appsettings.json` - Database connection
- `Pages/Admin/Index.cshtml` - Admin dashboard
- `Pages/Index.cshtml` - Homepage
- `Models/FreelancingDbContext.cs` - Database context

## 📝 Customization

1. **Change admin password** in `Login.cshtml.cs`
2. **Update branding** in `_Layout.cshtml` and `site.css`
3. **Modify services** through admin panel
4. **Edit content** in About and Contact pages

---

**Ready to launch your freelancing business?** 🚀
