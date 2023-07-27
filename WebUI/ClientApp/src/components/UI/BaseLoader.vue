<template>
  <div v-if="isLoading" class="base-loader"></div>
</template>

<script setup>
defineProps({
  isLoading: {
    type: Boolean,
    required: true,
  },
});
</script>

<style lang="scss">
.base-loader {
  width: 100%;
  max-width: 48px;
  height: 48px;
  max-height: 100%;
  margin: 25px auto;
  border: 5px solid $primary-color;
  border-bottom-color: transparent;
  border-radius: 50%;
  animation: rotation 1s linear infinite;
}

@keyframes rotation {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
</style>
