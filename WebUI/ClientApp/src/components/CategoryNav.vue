<template>
  <div class="category-nav">
    <router-link
      v-for="(category, index) in categories"
      :key="index"
      :to="{ name: 'Catalog', hash: `#${category.alias}` }"
      class="category-nav__item"
    >
      <component
        :is="category.icon"
        :width="32"
        :height="32"
        class="category-nav__item-img"
      ></component>
      <span class="category-nav__item-title">{{ category.title }}</span>
    </router-link>
  </div>
</template>

<script setup>
import { categories } from "@/staticData/categories";
</script>

<style lang="scss">
.category-nav {
  @include d-flex(space-between);
  @include respond-to(sm) {
    overflow-x: auto;
  }

  &__item {
    width: 135px;
    height: 104px;
    margin-right: 12px;
    background-color: white;
    border: 1px solid #f0f0f0;
    border-radius: $primary-border-radius;
    cursor: pointer;
    transition: 0.2s ease-in-out;

    @include d-flex(center, center, column);
    @include respond-to(sm) {
      flex-direction: row;
      height: 40px;
      padding: 0 12px;
    }

    &:last-child {
      margin-right: 0;
    }

    &:hover {
      border-color: $primary-color;
    }

    &-img {
      margin-bottom: 8px;
      color: $primary-color;

      @include respond-to(sm) {
        width: 24px;
        height: 24px;
        margin-right: 8px;
        margin-bottom: 0;
      }
    }

    &-item {
      font-size: 18px;

      @include respond-to(sm) {
        font-size: 16px;
      }
    }
  }
}
</style>
