import { defineConfig } from 'vite'
import { ripple } from 'vite-plugin-ripple'

export default defineConfig({
  root: './',
  plugins: [ripple()],
  build: {
    rollupOptions: {
      input: {
        main: 'index.html',
        drift: 'src/drift/index.html',
      }
    }
  }
})
