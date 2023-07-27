import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import stylelint from "vite-plugin-stylelint";
import eslint from "vite-plugin-eslint";
import { createHtmlPlugin } from "vite-plugin-html";
import path from "path";

export default defineConfig({
  plugins: [
    vue(),
    stylelint({ cache: false }),
    eslint(),
    createHtmlPlugin({
      minify: true,
      inject: {
        data: {
          title: process.env.VITE_APP_TITLE,
        },
      },
    }),
  ],
  server: {
    port: 8080,
  },
  css: {
    preprocessorOptions: {
      scss: {
        additionalData: `
        @import "@/assets/scss/_mixins.scss";
        @import "@/assets/scss/_variables.scss";
        `,
      },
    },
  },
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
    },
  },
});
