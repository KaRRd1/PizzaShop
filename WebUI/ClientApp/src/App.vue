<template>
  <div class="wrapper">
    <AppHeader
      :nav-is-visible="headerNavIsVisible"
      :is-fixed="headerNavIsVisible"
      :is-top-row-hidden-while-fixed="isHomeView"
    />
    <main class="container">
      <router-view
        @categories-visibility-changed="onCategoriesVisibilityChange"
      ></router-view>
    </main>
    <AppFooter />
  </div>
</template>

<script setup>
import AppHeader from "@/components/Header/AppHeader.vue";
import AppFooter from "@/components/AppFooter.vue";
import { computed, ref } from "vue";
import { useRoute } from "vue-router";

const route = useRoute();
const catalogCategoriesIsVisible = ref(true);

const headerNavIsVisible = computed(
  () => !catalogCategoriesIsVisible.value || !isHomeView.value
);

const isHomeView = computed(() => route.path === "/");
const onCategoriesVisibilityChange = (visibility) =>
  (catalogCategoriesIsVisible.value = visibility);
</script>

<style lang="scss">
.wrapper {
  min-height: 100vh;
  background-color: #f9f9f9;

  @include d-flex($direction: column);
}
</style>
