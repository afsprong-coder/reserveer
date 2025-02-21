# My Vue.js Calendar App

This project is a Vue.js application that features a date picker and checks the availability of selected dates against Google Calendar.

## Project Structure

```
my-vue-app
├── public
│   ├── index.html          # Main HTML file for the application
├── src
│   ├── components
│   │   └── DatePicker.vue  # Vue component for date selection
│   ├── views
│   │   └── CalendarView.vue # Main view for the calendar
│   ├── App.vue             # Root Vue component
│   ├── main.js             # Entry point for the Vue application
├── package.json            # npm configuration file
├── babel.config.js         # Babel configuration file
├── .gitignore              # Git ignore file
└── README.md               # Project documentation
```

## Installation

1. Clone the repository:
   ```
   git clone <repository-url>
   ```

2. Navigate to the project directory:
   ```
   cd my-vue-app
   ```

3. Install the dependencies:
   ```
   npm install
   ```

## Usage

To run the application, use the following command:
```
npm run serve
```

This will start the development server, and you can access the application at `http://localhost:8080`.

## Features

- Date Picker: Users can select a date using the date picker component.
- Google Calendar Integration: The application checks the availability of the selected date against Google Calendar.

## License

This project is licensed under the MIT License.