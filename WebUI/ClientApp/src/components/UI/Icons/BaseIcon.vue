<template>
  <svg
    xmlns="http://www.w3.org/2000/svg"
    :width="width"
    :height="height"
    :fill="color"
    :viewBox="viewBox"
  >
    <slot></slot>
  </svg>
</template>

<script setup>
defineProps({
  name: {
    type: String,
    default: "box",
  },
  width: {
    type: [Number, String],
    default: 18,
  },
  height: {
    type: [Number, String],
    default: 18,
  },
  color: {
    type: String,
    default: "currentColor",
  },
  viewBox: {
    type: String,
    default: `0 0 18 18`,
  },
});
</script>
