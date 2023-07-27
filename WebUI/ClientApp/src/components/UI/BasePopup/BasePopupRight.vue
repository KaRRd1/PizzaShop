<template>
  <base-popup :is-visible="isVisible" class="base-popup-right" @close="onClose">
    <div class="base-popup-right__header">
      <h2 class="base-popup-right__title">{{ title }}</h2>
      <close-cross-icon
        class="base-popup-right__close"
        :width="24"
        :height="24"
        @click="onClose"
      ></close-cross-icon>
    </div>
    <div class="base-popup-right__main">
      <slot name="main"></slot>
    </div>
    <div class="base-popup-right__footer">
      <slot name="footer"></slot>
    </div>
  </base-popup>
</template>

<script setup>
import BasePopup from "./BasePopup.vue";
import CloseCrossIcon from "@/components/UI/Icons/CloseCrossIcon.vue";

defineProps({
  title: {
    type: String,
    default: "",
  },
  isVisible: {
    type: Boolean,
    default: false,
  },
});

const emit = defineEmits(["update:isVisible", "close"]);

const onClose = () => {
  emit("update:isVisible", false);
  emit("close");
}
</script>

<style lang="scss">
.base-popup-right {
  right: 0;
  bottom: 0;
  height: 100%;
  padding: 32px 20px 12px 20px;
  background-color: white;

  @include d-flex($direction: column);

  &__header {
    margin-bottom: 20px;

    @include d-flex(space-between);
  }

  &__close {
    color: $gray-color;
    cursor: pointer;
    transition: 0.2s ease-in-out;

    @include respond-to(sm) {
      display: none;
    }

    &:hover {
      transform: scale(1.2);
    }
  }

  &__main {
    overflow-y: auto;
  }

  &__footer {
    width: 100%;
    margin-top: auto;
    padding-top: 12px;
    border-top: 1px solid #f0f0f0;

    @include d-flex(space-between, center);
  }
}

.popup-transition-enter-active .base-popup-right,
.popup-transition-leave-active .base-popup-right {
  transition: transform 0.3s;
}

.popup-transition-enter-from .base-popup-right,
.popup-transition-leave-to .base-popup-right {
  transform: translateX(100%);

  @include respond-to(sm) {
    transform: translateY(100%);
  }
}
</style>
