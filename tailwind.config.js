/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["**/*.razor", "**/*.cshtml", "**/*.html"],
  darkMode: 'class',
  theme: {
    extend: {
      gridTemplateColumns: {
        'week': '2.5rem, repeat(7, minmax(0, 1fr))',
      }
    },
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('daisyui')
  ],
daisyui: {
  themes: ['light', 'dark']
} 
}

