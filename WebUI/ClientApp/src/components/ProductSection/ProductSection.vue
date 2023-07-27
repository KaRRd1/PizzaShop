<template>
  <section class="product-section">
    <base-anchor
      :anchor-id="productSection.alias"
      class="product-section__anchor"
      :is-async="true"
    ></base-anchor>
    <div class="product-section__header">
      <h1 class="product-section__title">{{ productSection.name }}</h1>
      <base-button
        v-if="productSection.hasIngredients"
        class="product-section__filter-btn"
        @click="filterPopupIsVisible = true"
      >
        <filter-icon
          :width="18"
          :height="18"
          class="product-section__filter-icon"
        ></filter-icon>
        Фильтры
      </base-button>
    </div>
    <div class="product-section__items">
      <product-section-item
        v-for="product in filteredProducts"
        :key="product.id"
        :product="product"
        @click="emit('productClick', product)"
      ></product-section-item>
    </div>
    <product-section-filter-popup
      v-if="productSection.hasIngredients"
      v-model:is-visible="filterPopupIsVisible"
      :product-category-id="productSection.id"
      @filter="onFilter"
    ></product-section-filter-popup>
  </section>
</template>

<script setup>
import ProductSectionItem from "./ProductSectionItem.vue";
import FilterIcon from "@/components/UI/Icons/FilterIcon.vue";
import ProductSectionFilterPopup from "@/components/ProductSection/ProductSectionFilterPopup.vue";
import BaseButton from "@/components/UI/BaseButton.vue";
import BaseAnchor from "@/components/UI/BaseAnchor.vue";
import { ref } from "vue";

const props = defineProps({
  productSection: {
    type: Object,
    required: true,
  },
});

const emit = defineEmits(["productClick"]);

const filteredProducts = ref(props.productSection.products);
const filterPopupIsVisible = ref(false);

const onFilter = (selectedIngredients) => {
  filteredProducts.value = props.productSection.products.filter(
    ({ ingredients }) =>
      selectedIngredients.every((selIngredient) =>
        ingredients.find((ingredient) => ingredient.id === selIngredient.id)
      )
  );
};
</script>

<style lang="scss">
.product-section {
  position: relative;
  margin-bottom: 48px;

  &__anchor {
    position: absolute;
    top: -64px;
  }

  &__header {
    margin-bottom: 32px;

    @include d-flex(space-between, center);
    @include respond-to(sm) {
      margin-bottom: 20px;
    }
  }

  &__filter-btn {
    height: 40px;
    padding: 0 16px;
    color: black;
    background-color: white;
    border-color: $light-gray-color;

    @include d-flex($align-items: center);

    &:hover {
      color: inherit;
    }
  }

  &__filter-icon {
    margin-right: 8px;
    color: $primary-color;
  }

  &__items {
    display: grid;
    grid-gap: 30px;
    grid-template-columns: repeat(4, 1fr);

    @include respond-to(lg) {
      grid-template-columns: repeat(3, 1fr);
    }
    @include respond-to(sm) {
      grid-gap: 12px;
      grid-template-columns: repeat(1, 1fr);
    }
  }
}
</style>
