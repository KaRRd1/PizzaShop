<template>
  <base-icon view-box="0 0 32 32" :width="width" :height="height">
    <path
      d="M0.999977 7.5H31C31.552 7.5 32 7.16397 32 6.75C32 6.33597 31.552 6 31 6H0.999977C0.447953 6 0 6.33604 0 6.75C0 7.16397 0.448036 7.5 0.999977 7.5Z"
    />
    <path
      d="M31 15.25H0.999977C0.447953 15.25 0 15.586 0 16C0 16.414 0.448036 16.75 0.999977 16.75H31C31.552 16.75 32 16.414 32 16C32 15.586 31.552 15.25 31 15.25Z"
    />
    <path
      d="M19.0909 24.5H0.90907C0.40723 24.5 0 24.836 0 25.25C0 25.664 0.407305 26 0.90907 26H19.0909C19.5928 26 20 25.664 20 25.25C20.0001 24.836 19.5928 24.5 19.0909 24.5Z"
    />
  </base-icon>
</template>

<script setup>
import BaseIcon from "@/components/UI/Icons/BaseIcon.vue";

defineProps({
  width: {
    type: Number,
    default: 32,
  },
  height: {
    type: Number,
    default: 32,
  },
});
</script>
