import { createRouter, createWebHistory } from "vue-router";
import { authMiddleware } from "@/router/middlewares/authMiddleware.js";

const Catalog = () => import("@/views/Catalog.vue");
const Payment = () => import("@/views/Payment.vue");
const Account = () => import("@/views/Account/Account.vue");
const AccountSettings = () => import("@/views/Account/AccountSettings.vue");
const AccountHistory = () => import("@/views/Account/AccountHistory.vue");
const Default = () => import("@/views/Default.vue");
const Delivery = () => import("@/views/Delivery.vue");
const AboutCompany = () => import("@/views/AboutCompany.vue");
const NotFound = () => import("@/views/NotFound.vue");

const routes = [
  {
    path: "/",
    name: "Catalog",
    component: Catalog,
    meta: {
      title: "Каталог",
    },
  },
  {
    path: "/payment",
    name: "Payment",
    meta: {
      title: "Новый заказ",
    },
    component: Payment,
  },
  {
    path: "/account",
    component: Account,
    redirect: { name: "accountHistory" },
    children: [
      {
        path: "history",
        name: "accountHistory",
        component: AccountHistory,
        meta: { title: "История заказов" },
      },
      {
        path: "settings",
        name: "accountSettings",
        component: AccountSettings,
        meta: { title: "Настройки" },
      },
    ],
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: "/default",
    name: "Default",
    component: Default,
    meta: {
      title: "Страница(нет)",
    },
  },
  {
    path: "/delivery",
    name: "Delivery",
    component: Delivery,
    meta: {
      title: "Доставка",
    },
  },
  {
    path: "/company",
    name: "Company",
    component: AboutCompany,
    meta: {
      title: "О компании",
    },
  },
  {
    path: "/:pathMatch(.*)*",
    name: "NotFound",
    component: NotFound,
  },
];

const router = createRouter({
  routes,
  scrollBehavior(to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition;
    }
    if (to.hash && document.querySelector(to.hash)) {
      return {
        el: to.hash,
        behavior: "smooth",
      };
    }

    return { top: 0 };
  },
  history: createWebHistory(),
});

router.beforeEach(authMiddleware);

router.beforeEach((to) => {
  document.title = to.meta.title ?? import.meta.env.VITE_APP_TITLE;
});

export default router;
