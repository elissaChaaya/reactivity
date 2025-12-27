import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react-swc'
//mkcert didnt wokr, we ar estill working on http, not https

// https://vite.dev/config/
export default defineConfig({
  server: {
    port:3000
  },
  plugins: [react()],
})
