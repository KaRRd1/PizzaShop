<template>
  <ul v-show="isVisible" class="header-nav">
    <template v-for="(category, index) in categories" :key="index">
      <li>
        <router-link :to="{ name: 'Catalog', hash: `#${category.alias}` }">
          {{ category.title }}
        </router-link>
      </li>
    </template>
    <base-dropdown-menu>
      <template #title>
        <span class="header-nav__item">Другое</span>
      </template>
      <template #menu>
        <ul>
          <li class="header-nav__item header-nav__other-item">
            <router-link :to="{ name: 'Company' }">О компании </router-link>
          </li>
          <li class="header-nav__item header-nav__other-item">
            <router-link :to="{ name: 'Delivery' }">Доставка </router-link>
          </li>
        </ul>
      </template>
    </base-dropdown-menu>
  </ul>
  <category-nav
    v-show="isVisible"
    class="header-nav__categories"
  ></category-nav>
</template>

<script setup>
import BaseDropdownMenu from "@/components/UI/BaseDropdownMenu.vue";
import CategoryNav from "@/components/CategoryNav.vue";
import { categories } from "@/staticData/categories";

defineProps({
  isVisible: {
    type: Boolean,
    required: true,
  },
});
</script>

<style lang="scss">
.header-nav {
  width: 65%;

  @include d-flex(space-between, center);
  @include respond-to(lg) {
    width: 72%;
  }
  @include respond-to(sm) {
    display: none;
  }

  &__categories {
    display: none;

    @include respond-to(sm) {
      display: flex;
      margin-right: 12px;
    }
  }

  &__item {
    transition: 0.1s ease-in-out;

    &:hover,
    &:focus {
      color: $primary-color;
    }
  }

  &__other-item {
    margin-bottom: 16px;

    &:last-child {
      margin-bottom: 0;
    }
  }
}
</style>
