<template>
  <button class="base-transparent-btn">
    <slot />
  </button>
</template>

<script>
export default {
  name: "BaseTransparentButton",
};
</script>

<style>
.base-transparent-btn {
  font-size: 16px;
  background-color: transparent;
}
</style>
