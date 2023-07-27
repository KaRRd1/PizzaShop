import { fetchWrapper } from "@/utils/fetchWrapper";
import { useAuthStore } from "@/stores/authStore";

export const API = fetchWrapper.create({
  baseUrl: "/api",
  headers: {
    Accept: "application/json",
  },
});

API.addResponseHandler(async (response) => {
  const { isLoggedIn, localLogout } = useAuthStore();

  if (response.status === 401 && isLoggedIn) await localLogout();
});
