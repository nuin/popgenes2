import { resolve } from 'path'
import { defineConfig } from 'vite'

export default defineConfig({
  root: './',
  plugins: [],
  build: {
    rollupOptions: {
      input: {
        main: resolve(__dirname, 'index.html'),
        drift: resolve(__dirname, 'src/drift/index.html'),
      }
    }
  }
})
