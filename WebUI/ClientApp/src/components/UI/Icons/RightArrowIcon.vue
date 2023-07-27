<template>
  <base-icon view-box="0 0 9 16" :width="width" :height="height">
    <path
      d="M1.15174 17.7272C1.35323 17.7272 1.55493 17.6497 1.70876 17.4948L9.58746 9.56093C9.89532 9.25091 9.89532 8.74889 9.58746 8.43908L1.70876 0.505217C1.4009 0.195201 0.902374 0.195201 0.59471 0.505217C0.287047 0.815232 0.28685 1.31725 0.59471 1.62706L7.91639 9L0.59471 16.3729C0.28685 16.683 0.28685 17.185 0.59471 17.4948C0.748542 17.6497 0.950238 17.7272 1.15174 17.7272Z"
    />
  </base-icon>
</template>
<script setup>
import BaseIcon from "@/components/UI/Icons/BaseIcon.vue";

defineProps({
  width: {
    type: Number,
    default: 9,
  },
  height: {
    type: Number,
    default: 16,
  },
});
</script>
