<template>
  <base-icon view-box="0 0 9 16" :width="width" :height="height">
    <path
      d="M8.84826 17.7272C8.64677 17.7272 8.44507 17.6497 8.29124 17.4948L0.412536 9.56093C0.104676 9.25091 0.104676 8.74889 0.412536 8.43908L8.29124 0.505217C8.5991 0.195201 9.09763 0.195201 9.40529 0.505217C9.71295 0.815232 9.71315 1.31725 9.40529 1.62706L2.08361 9L9.40529 16.3729C9.71315 16.683 9.71315 17.185 9.40529 17.4948C9.25146 17.6497 9.04976 17.7272 8.84826 17.7272Z"
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
