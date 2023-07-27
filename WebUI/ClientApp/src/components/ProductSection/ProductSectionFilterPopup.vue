<template>
  <base-popup-right
    title="Фильтры"
    :is-visible="isVisible"
    class="product-section-filter-popup"
    @close="$emit('update:isVisible', false)"
  >
    <template #main>
      <div
        v-for="(ingredientCategory, index) in ingredientCategories"
        :key="index"
        class="product-section-filter-popup__block"
      >
        <span class="product-section-filter-popup__block-title">
          {{ ingredientCategory.name }}
        </span>
        <div class="product-section-filter-popup__block-items">
          <base-checkbox-button
            v-for="ingredient in ingredientCategory.ingredients"
            :key="ingredient.id"
            v-model="selectedIngredients"
            :value="ingredient"
            class="product-section-filter-popup__checkbox"
          >
            {{ ingredient.name }}
          </base-checkbox-button>
        </div>
      </div>
    </template>
    <template #footer>
      <base-button
        class="product-section-filter-popup-footer-btn"
        @click="resetFilter"
      >
        Сбросить
      </base-button>
      <base-button
        class="product-section-filter-popup-footer-btn"
        @click="filter"
      >
        Применить
      </base-button>
    </template>
  </base-popup-right>
</template>

<script setup>
import BasePopupRight from "@/components/UI/BasePopup/BasePopupRight.vue";
import BaseButton from "@/components/UI/BaseButton.vue";
import BaseCheckboxButton from "@/components/UI/BaseCheckboxButton.vue";
import { onMounted, ref, watch } from "vue";
import { getProductSectionIngredients } from "@/api/catalog.js";

const props = defineProps({
  isVisible: {
    type: Boolean,
  },
  productCategoryId: {
    type: Number,
    required: true,
  },
});

const ingredientCategories = ref([]);

onMounted(async () => {
  ingredientCategories.value = await getProductSectionIngredients(
    props.productCategoryId
  );
});

const selectedIngredients = ref([]);
const isFiltered = ref(false);

watch(
  () => props.isVisible,
  () => {
    if (!isFiltered.value) selectedIngredients.value = [];
  }
);

const emit = defineEmits(["filter", "update:isVisible"]);

const filter = () => {
  isFiltered.value = selectedIngredients.value.length > 0;
  emit("filter", selectedIngredients.value);
  emit("update:isVisible", false);
};

const resetFilter = () => {
  selectedIngredients.value = [];
  filter();
};
</script>

<style lang="scss">
.product-section-filter-popup {
  width: 520px;

  &-footer-btn {
    width: 48%;
  }

  &__block {
    margin-bottom: 16px;

    &-title {
      display: block;
      margin-bottom: 12px;
      color: $gray-color;
    }

    &-items {
      display: flex;
      flex-wrap: wrap;
    }
  }

  &__checkbox {
    height: 40px;
    margin: 0 8px 8px 0;
    font-size: 14px;

    &:hover {
      transform: scale(0.95);
    }
  }
}
</style>
