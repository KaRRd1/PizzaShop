<template>
  <div class="product-section-item">
    <img
      class="product-section-item__img"
      :src="product.imageSmallUrl"
      alt=""
    />
    <div class="product-section-item__info">
      <h4 class="product-section-item__title">{{ product.name }}</h4>
      <p class="product-section-item__description">
        {{ product.description }}
      </p>
      <div class="product-section-item__footer">
        <base-button class="product-section-item__choose-btn">
          Выбрать
        </base-button>
        <span class="product-section-item__price"> {{ price }} ₽ </span>
      </div>
    </div>
  </div>
</template>

<script setup>
import BaseButton from "@/components/UI/BaseButton.vue";
import { computed } from "vue";

const props = defineProps({
  product: {
    type: Object,
    required: true,
  },
});

const price = computed(() => {
  const { variations } = props.product;

  const minProductPrice = Math.min(...variations.map((x) => x.price));
  return variations.length > 1 ? `от ${minProductPrice}` : minProductPrice;
});
</script>

<style lang="scss">
.product-section-item {
  background-color: white;
  border: 1px solid $light-gray-color;
  border-radius: 12px;
  cursor: pointer;
  transition: 0.2s ease-in-out;

  @include d-flex($direction: column);
  @include respond-to(sm) {
    flex-direction: row;
    width: 100%;
    padding: 20px;
  }

  &:hover {
    border-color: $primary-color;
  }

  &__img {
    width: 100%;
    margin-bottom: 16px;
    border-top-left-radius: inherit;
    border-top-right-radius: inherit;

    @include respond-to(sm) {
      width: 100px;
      height: 100px;
      margin-right: 12px;
      margin-bottom: 0;
      border-radius: 0;
    }
  }

  &__info {
    display: flex;
    flex-direction: column;
    margin-top: auto;
    padding: 0 20px 20px 20px;

    @include respond-to(sm) {
      align-items: flex-start;
      padding: 0;
    }
  }

  &__title {
    margin-bottom: 12px;
    font-weight: 600;
    font-size: 18px;

    @include respond-to(sm) {
      margin-bottom: 8px;
      font-size: 14px;
    }
  }

  &__description {
    display: -webkit-box;
    margin-bottom: 16px;
    overflow: hidden;
    font-size: 16px;
    text-overflow: ellipsis;
    -webkit-line-clamp: 2;
    line-clamp: 2;
    -webkit-box-orient: vertical;

    @include respond-to(sm) {
      margin-bottom: 10px;
      font-size: 12px;
    }
  }

  &__footer {
    display: flex;
    align-items: center;
    justify-content: space-between;

    @include respond-to(xl) {
      flex-direction: column;
    }
  }

  &__choose-btn {
    width: auto;
    padding: 0 32px;

    @include respond-to(xl) {
      width: 100%;
    }
    @include respond-to(sm) {
      display: none;
    }
  }

  &__price {
    color: $primary-color;
    font-weight: 600;
    font-size: 18px;

    @include respond-to(xl) {
      margin-top: 14px;
    }
    @include respond-to(sm) {
      padding: 7px 16px;
      font-size: 14px;
      background-color: lighten($primary-color, 42%);
      border-radius: 6px;
    }
  }
}
</style>
