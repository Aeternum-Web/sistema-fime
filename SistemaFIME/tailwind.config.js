/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Pages/**/*.{razor,cshtml}",
    "./Views/**/*.{razor,cshtml}",
    "./Components/**/*.{razor,cshtml}",
    "./wwwroot/**/*.{html,js}",
    "./**/*.razor"
  ],
  theme: {
    extend: {
      colors: {
        primary: '#007bff',
        secondary: '#6c757d'
      }
    },
  },
  plugins: [],
}