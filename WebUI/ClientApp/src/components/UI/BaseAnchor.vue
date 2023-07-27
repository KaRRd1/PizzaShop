<template>
  <div :id="anchorId" ref="anchor" class="base-anchor"></div>
</template>

<script setup>
import { onMounted, ref } from "vue";
import { useRoute } from "vue-router";

const props = defineProps({
  anchorId: {
    type: String,
    required: true,
  },
  isAsync: {
    type: Boolean,
    default: false,
  },
});

const anchor = ref(null);

onMounted(() => {
  if (props.isAsync) {
    const route = useRoute();

    if (route.hash === `#${props.anchorId}`) {
      anchor.value.scrollIntoView({ behavior: "smooth" });
    }
  }
});
</script>
