import { API } from "@/api/index";

export async function getUserOrders(page) {
  return await (await API.get(`/orders/me?page=${page}`)).json();
}

export async function createOrder(order) {
  return await (await API.post("/orders/create", order)).json();
}
