const express = require("express");
const { google } = require("googleapis");
const serviceAccount = require("./reservationapp-451619-0ec2cdd53369.json");

const app = express();
const port = 3000;

app.get("/check-availability", async (req, res) => {
  const date = req.query.date;
  if (!date) {
    return res.status(400).send("Date is required");
  }

  try {
    const auth = new google.auth.GoogleAuth({
      credentials: serviceAccount,
      scopes: ["https://www.googleapis.com/auth/calendar.readonly"],
    });

    const calendar = google.calendar({ version: "v3", auth });

    const events = await calendar.events.list({
      calendarId: "primary",
      timeMin: new Date(date).toISOString(),
      timeMax: new Date(new Date(date).setDate(new Date(date).getDate() + 1)).toISOString(),
      showDeleted: false,
      singleEvents: true,
      orderBy: "startTime",
    });

    const isAvailable = events.data.items.length === 0;
    res.json({ available: isAvailable });
  } catch (error) {
    console.error("Error fetching events from Google Calendar:", error);
    res.status(500).send("Internal Server Error");
  }
});

app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});
