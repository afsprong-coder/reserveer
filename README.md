# Room Reservation Checker

A Blazor Server application that integrates with Google Calendar API to check room availability.

## Prerequisites

- .NET 8.0 SDK
- A Google Cloud Platform account
- Visual Studio 2022 or VS Code (optional)

## Installation

1. Clone this repository
2. Restore the NuGet packages by running: dotnet restore

## Google Calendar API Setup

1. Go to [Google Cloud Console](https://console.cloud.google.com/)
2. Create a new project
3. Enable the Google Calendar API:
   - In the navigation menu, go to "APIs & Services" > "Library"
   - Search for "Google Calendar API"
   - Click "Enable"

4. Create credentials:
   - Go to "APIs & Services" > "Credentials"
   - Click "Create Credentials" and select "OAuth 2.0 Client ID"
   - Select "Desktop Application" as the application type
   - Download the credentials JSON file
   - Rename it to "credentials.json"
   - Place it in your project's root directory
   - In Visual Studio, set the file properties to "Copy to Output Directory: Copy always"

5. Update the Calendar ID:
   - Open `Services/CalendarService.cs`
   - Replace `YOUR_CALENDAR_ID@group.calendar.google.com` with your actual Google Calendar ID
   - You can find your calendar ID in Google Calendar settings under "Integrate calendar"

## Running the Application

1. Make sure all prerequisites are installed
2. Ensure credentials.json is in place
3. Run the application: