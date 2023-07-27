import { defineStore } from "pinia";
import { computed, onMounted, ref, watch } from "vue";
import * as userApi from "@/api/user";
import { useRouter } from "vue-router";

const LS_USER_KEY = "user";

export const useAuthStore = defineStore("authStore", () => {
  const user = ref(JSON.parse(localStorage.getItem(LS_USER_KEY)));

  watch(
    () => user,
    () => localStorage.setItem(LS_USER_KEY, JSON.stringify(user.value)),
    { deep: true }
  );

  onMounted(async () => {
    if (isLoggedIn.value) await updateLoggedInUserInfo();
  });

  const isLoggedIn = computed(() => !!user.value);

  const updateLoggedInUserInfo = async () => {
    user.value = await userApi.tryGetLoggedInUser();
  };

  const login = async (phone) => {
    const loggedInUser = await userApi.login(phone);

    if (loggedInUser) user.value = loggedInUser;

    return !!loggedInUser;
  };

  const logout = async () => {
    if (await userApi.logout()) await localLogout();
  };

  const router = useRouter();

  const localLogout = async () => {
    await router.isReady();

    if (router.currentRoute.value.meta.requiresAuth) {
      await router.push({ name: "Catalog" });
    }

    user.value = null;
  };

  return {
    user,
    isLoggedIn,
    updateLoggedInUserInfo,
    login,
    logout,
    localLogout,
  };
});
