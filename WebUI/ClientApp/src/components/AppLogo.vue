<template>
  <router-link to="/" class="logo">
    <img class="logo__img" src="@/assets/svg/logo.svg" alt="" />
    <span v-if="!isShort" class="logo__label">
      {{ appTitle }}
    </span>
  </router-link>
</template>

<script setup>
const appTitle = import.meta.env.VITE_APP_TITLE;

defineProps({
  isShort: {
    type: Boolean,
    default: false,
  },
});
</script>

<style lang="scss">
.logo {
  cursor: pointer;
  @include d-flex($align-items: center);

  &__img {
    margin-right: 10px;
  }
  &__label {
    width: max-content;
    font-size: 16px;
  }
}
</style>
