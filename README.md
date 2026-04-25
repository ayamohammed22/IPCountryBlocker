# IPCountryBlocker

---
# 🌍 IP Country Blocker API

A .NET Core Web API that manages blocked countries and validates IP addresses using the IPGeolocation.io third-party API.  
All data is stored in-memory — no database required.

---

## 📋 Table of Contents

- [Features](#-features)
- [Tech Stack](#-tech-stack)
- [Project Structure](#-project-structure)
- [Getting Started](#-getting-started)
- [Configuration](#️-configuration)
- [Notes](#-notes)

---

## ✨ Features

- Block / unblock countries by country code
- Temporarily block a country for a set duration (auto-expires)
- Look up any IP address to get its country info
- Automatically detect caller's IP and check if their country is blocked
- Log all blocked-access attempts with IP, timestamp, country, and User-Agent
- Paginated + searchable endpoints
- Swagger UI for interactive API documentation
- Background service that cleans up expired temporal blocks every 5 minutes
- Fully thread-safe using `ConcurrentDictionary` and `ConcurrentBag`

---

## 🛠 Tech Stack

| Layer            | Technology                         |
|------------------|------------------------------------|
| Framework        | .NET 8 Web API                     |
| HTTP Client      | Microsoft.Extensions.Http          |
| JSON             | System.Text.Json / Newtonsoft.Json |
| API Docs         | Swagger                            |
| Geolocation      | IPGeolocation.io REST API          |
| Storage          | In-Memory (ConcurrentDictionary)   |
| Background Jobs  | IHostedService / BackgroundService |
| Testing          | xUnit + Moq                        |

---
---

## 🚀 Getting Started

### Prerequisites

- .NET 8 SDK  
- A free API key from IPGeolocation.io  

### 1. Clone the Repository
git clone https://github.com/your-username/IPCountryBlocker.git
cd IPCountryBlocker

### 2. Configure API Key
Open ValidIPandBlockedCountries.API/appsettings.json and add your key:
"IpGeolocation": {
  "ApiKey": "YOUR_API_KEY_HERE",
  "BaseUrl": "https://api.ipgeolocation.io/ipgeo"
}

### 3. Run the Application
cd ValidIPandBlockedCountries.API
dotnet run

### 4. Open Swagger UI
Navigate to:
https://localhost:{port}/swagger

## 📌 Notes

-[All data resets when the application restarts (in-memory only).]
- [The background cleanup service runs every 5 minutes to remove expired temporal blocks.]
- [AddSingleton is used for repositories to keep data alive for the app lifetime.]
- [IServiceScopeFactory is used inside the background service to safely resolve scoped services.]
