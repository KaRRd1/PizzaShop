import { useAuthStore } from "@/stores/authStore.js";

/**
 * SHOULD BE FIRST!!
 */
export const authMiddleware = (to, from, next) => {
  const authStore = useAuthStore();

  if (to.meta.requiresAuth && !authStore.isLoggedIn) {
    next({ name: "NotFound" });
  } else {
    next();
  }
};
