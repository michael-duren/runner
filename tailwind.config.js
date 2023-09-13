/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["**/*.razor", "**/*.cshtml", "**/*.html"],
  darkMode: 'class',
  theme: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/forms')
  ],
}

