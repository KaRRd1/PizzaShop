import { createApp } from "vue";
import { createPinia } from "pinia";
import App from "./App.vue";
import Router from "@/router/router.js";

import "@/assets/scss/index.scss";

const app = createApp(App);

app.use(Router).use(createPinia()).mount("#app");
