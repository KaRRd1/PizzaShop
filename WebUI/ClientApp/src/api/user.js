import { API } from "@/api/index";

export const login = async (phone) => {
  return await (await API.post("/account/login", { phone })).json();
};
export const tryGetLoggedInUser = async () => {
  const response = await API.get("/account/info");
  return response.status === 200 ? await response.json() : null;
};

export const logout = async () => {
  const response = await API.post("/account/logout");
  return response.status === 200;
};

export const updateUserInfo = async (newUserInfo) => {
  const res = await API.post("/account/update", newUserInfo);
  return res.status === 200;
};
