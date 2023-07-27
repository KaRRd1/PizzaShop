<template>
  <button class="base-btn" :disabled="disabled">
    <slot />
  </button>
</template>

<script setup>
defineProps({
  disabled: {
    type: Boolean,
    default: false,
  },
});
</script>

<style lang="scss">
.base-btn {
  width: auto;
  height: 48px;
  color: white;
  font-size: 16px;
  background-color: $primary-color;
  border: 1px solid $primary-color;
  border-radius: 4px;
  transition: 0.2s ease-in-out;

  @include d-flex(center, center);
  @include respond-to(sm) {
    font-size: 14px;
  }

  &:hover {
    color: $primary-color;
    background-color: white;
    border-color: $primary-color;
  }

  &:active {
    transform: scale(0.95);
  }
}
</style>
