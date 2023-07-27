<template>
  <base-popup :is-visible="isVisible" class="base-popup-center" @close=onClose>
    <slot></slot>
    <close-cross-icon
      :width="32"
      :height="32"
      class="base-popup-center__close"
      @click="onClose"
    ></close-cross-icon>
  </base-popup>
</template>

<script setup>
import BasePopup from "@/components/UI/BasePopup/BasePopup.vue";
import CloseCrossIcon from "@/components/UI/Icons/CloseCrossIcon.vue";

defineProps({
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
.base-popup-center {
  top: 50%;
  left: 50%;
  background-color: white;
  border-radius: $primary-border-radius;
  transform: translate(-50%, -50%);
  @include d-flex();

  @include respond-to(sm) {
    top: auto;
    left: 0;
    padding: 20px !important;
    transform: translate(0);
  }

  &__close {
    position: absolute;
    top: 0;
    right: -50px;
    color: white;
    cursor: pointer;
    transition: 0.2s;

    @include respond-to(sm) {
      display: none;
    }

    &:hover {
      transform: scale(1.2);
    }
  }
}

.popup-transition-enter-active .base-popup-center,
.popup-transition-leave-active .base-popup-center {
  transition: transform 0.3s, opacity 0.3s;
}

.popup-transition-enter-from .base-popup-center,
.popup-transition-leave-to .base-popup-center {
  transform: translateX(-50%);
  opacity: 0;

  @include respond-to(sm) {
    transform: translateY(100%);
  }
}
</style>
