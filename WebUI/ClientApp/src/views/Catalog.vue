<template>
  <div class="catalog">
    <category-nav
      v-visible="visibilityChanged"
      class="catalog__categories"
    ></category-nav>
    <base-loader :is-loading="!catalogData.length"></base-loader>
    <product-section
      v-for="(category, index) in catalogData"
      :key="index"
      :product-section="category"
      @product-click="onProductClick"
    ></product-section>
    <choose-product-popup
      v-model:is-visible="isChooseProductPopupVisible"
      :product="currentProduct"
    ></choose-product-popup>
  </div>
</template>

<script setup>
import ProductSection from "@/components/ProductSection/ProductSection.vue";
import BaseLoader from "@/components/UI/BaseLoader.vue";
import ChooseProductPopup from "@/components/ChooseProductPopup.vue";
import vVisible from "@/directives/Visible";
import { onMounted, ref } from "vue";
import { getCatalog } from "@/api/catalog";
import CategoryNav from "@/components/CategoryNav.vue";

const catalogData = ref([]);
const currentProduct = ref(null);
const isChooseProductPopupVisible = ref(false);

onMounted(async () => (catalogData.value = await getCatalog()));

const emit = defineEmits(["categoriesVisibilityChanged"]);

const visibilityChanged = (isVisible) =>
  emit("categoriesVisibilityChanged", isVisible);

const onProductClick = (product) => {
  currentProduct.value = product;
  isChooseProductPopupVisible.value = true;
};
</script>

<style lang="scss">
.catalog__categories {
  margin-bottom: 30px;
}
</style>
