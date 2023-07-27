import { API } from "@/api/index.js";

export const getCatalog = async () => {
  return await (await API.get("/catalog")).json();
};

export const getProductSectionIngredients = async (productCategoryId) => {
  return await (
    await API.get(`/ingredients/from?productCategoryId=${productCategoryId}`)
  ).json();
};
